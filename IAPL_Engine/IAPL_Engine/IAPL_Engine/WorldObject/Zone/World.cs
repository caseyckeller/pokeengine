using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using IAPL.Map;

namespace IAPL.Map
{
    /// <summary>
    /// A world is a collection of zones
    /// It will handle the loading and unloading of zones from files
    /// and will let you know which zone the user is currently on
    /// it will also show which zones are adjacent to the current zone
    /// This means both the current and adjactent zones need to be in memory, for smooth transitions
    /// </summary>
    public class World
    {
        public String worldName;
        public Zone currentArea;
        public List<Zone> adjacentAreas;
        public SortedList<String, Bounds> zoneLimits;

        /// <summary>
        /// Default constructor, don't use these values, load a map before you use it
        /// </summary>
        public World()
        {
            worldName = "Default Name";
            currentArea = new Zone();
            adjacentAreas = new List<Zone>();
            zoneLimits = new SortedList<string, Bounds>();
        }

        public Zone getCurrentZone()
        {
            return currentArea;
        }

        public void getBounds()
        {
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            string rulesDir = Path.Combine(rootDir, "Zones");

            foreach (string path in Directory.GetFiles(rulesDir))
                if (path.ToLower().EndsWith(".zon"))
                {
                    //deserialize the zone
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Zone tempZone = (Zone)formatter.Deserialize(stream);
                    stream.Close();
                    //add the zone bounds to our list
                    zoneLimits.Add(tempZone.zoneName, new Bounds(tempZone.globalX, tempZone.globalY, tempZone.globalX + tempZone.mapWidth - 1, tempZone.globalY + tempZone.mapHeight - 1));
                    tempZone = null;
                }
        }

        public void changeZone(Zone inZone)
        {
            currentArea = inZone;
            adjacentAreas.Clear();
            Bounds currentBounds = zoneLimits[currentArea.zoneName];

            foreach (KeyValuePair<string, Bounds> pair in zoneLimits)
            {
                if (
                checkUpDownAdjacent(pair.Value, currentBounds) ||
                checkUpDownAdjacent(currentBounds, pair.Value) ||
                checkSideAdjacent(currentBounds, pair.Value) ||
                checkSideAdjacent(pair.Value, currentBounds))
                {
                    addAdjacentZone(pair.Key);
                }

            }
            
        }

        public void changeZone(String zoneName)
        {
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            string zonesDir = Path.Combine(rootDir, "Zones");

            foreach (string path in Directory.GetFiles(zonesDir))
                if (path.ToLower().EndsWith(zoneName.ToLower() + ".zon"))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Zone tempZone = (Zone)formatter.Deserialize(stream);
                    stream.Close();

                    changeZone(tempZone);
                    tempZone = null;                  
                    break;
                }
        }

        #region adjacency_calculations
        /// <summary>
        /// checks if the bottom edge of b is adjacent to the top edge of a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool checkUpDownAdjacent(Bounds a, Bounds b)
        {
            bool isAdjacent = false;
            for (int ax = a.topLeftX; ax <= a.bottomRightX; ax++)
            {
                for (int bx = b.topLeftX; bx <= b.bottomRightX; bx++)
                {
                    if (ax == bx && a.topLeftY + 1 == b.bottomRightY)
                    {
                        isAdjacent = true;
                        break;
                    }
                }

                if (isAdjacent)
                { break; }
            }

            return isAdjacent;
        }

        /// <summary>
        /// checks if the left side of edge b is adjacent to the right side of edge a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool checkSideAdjacent(Bounds a, Bounds b)
        {
            bool isAdjacent = false;
            for (int ay = a.topLeftY; ay <= a.bottomRightY; ay++)
            {
                for (int by = b.topLeftY; by <= b.bottomRightY; by++)
                {
                    if (ay == by && a.bottomRightX + 1 == b.topLeftX)
                    {
                        isAdjacent = true;
                        break;
                    }
                }

                if (isAdjacent)
                { break; }
            }

            return isAdjacent;
        }
        #endregion

        /// <summary>
        /// this loads a zone from a file then adds it to the adjacent zones list
        /// </summary>
        /// <param name="name"></param>
        private void addAdjacentZone(string name)
        {
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            string zonesDir = Path.Combine(rootDir, "Zones");

            foreach (string path in Directory.GetFiles(zonesDir))
                if (path.ToLower().EndsWith(name.ToLower() + ".zon"))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Zone tempZone = (Zone)formatter.Deserialize(stream);
                    stream.Close();

                    adjacentAreas.Add(tempZone);
                    tempZone = null;
                    break;
                }
        }

    }

    public struct Bounds
    {
        public int topLeftX;
        public int topLeftY;
        public int bottomRightX;
        public int bottomRightY;

        public Bounds(int tlx, int tly, int brx, int bry)
        {
            topLeftX = tlx;
            topLeftY = tly;
            bottomRightX = brx;
            bottomRightY = bry;
        }
    }
}
