using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using IAPL.Map;

namespace MapEditor
{
    public class FloorsList
    {
        public List<FloorData> floor;

        public FloorsList()
        {
            floor = new List<FloorData>();
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            string floorsDir = Path.Combine(rootDir, "Resources\\Floors");

            foreach (string path in Directory.GetFiles(floorsDir))
            {
                if(path.EndsWith(".png"))
                {
                    FloorData temp;
                    temp.image = new Bitmap(path);
                    temp.tile = new Tile();
                    floor.Add(temp);
                }
            }
        }
    }

    public struct FloorData
    {
        public Tile tile;
        public Bitmap image;
    }
}
