using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Map;

namespace IAPL.Map
{
    class Zone
    {
        private String zoneName;  //this is the name of the zone, generally "route xxxx"
        //TODO make way to store adjacent zones
        private Tile[,] tile; //a 2D array of nodes, these are individual tiles of a map
        //starts at 0,0 for bottom left corner and is x,y
        //so tile[1][2] is the second tile from the left, and 3 from the bottom
        //NOT global, relative to zone only
        //global coordinate would be global X and Y plus tile x and y

        private int globalX; //global X coordinate of tile [0][0]
        private int globalY; //global Y coordinate of tile [0][0]
        private int mapWidth
        {
            get { return tile.GetLength(0); }
        }

        private int mapHeight
        {
            get { return tile.GetLength(1); }
        }

        //default constructor makes a 50x50 zone
        public Zone()
        {
            zoneName = "Default Name";
            //these must be changed to global unless only one zone exists
            globalX = 0;
            globalY = 0;
            allToDefault();

        }

        //constructor when given global X and Y coordinates
        public Zone(int inX, int inY)
        {
            zoneName = "Default Name";
            globalX = inX;
            globalY = inY;

        }

        //returns global coords of tile x y
        public point convertToGlobal(int x, int y)
        {
            point xy = new point(x + globalX, y + globalY);
            return xy;
        }

        //returns local coords of tile x y
        //returns -1,-1 if not on this zone
        public point convertToLocal(int x, int y)
        {
            point xy = new point(-1, -1);
            if(x < (globalX+mapWidth) && (x >= globalX))
            {
                if(y < (globalY+mapHeight) && (y >= globalY))
                {
                    xy.X = x - globalX;
                    xy.Y = y - globalY;
                }
            }
            return xy;
        }

        private void allToDefault()
        {
            for( int a = 0; a < mapWidth; a++)
            {
                for (int b = 0; b < mapHeight; b++)
                {
                    tile[a, b] = new Tile();
                }
            }
        }
    }

    
    public struct point
    {
        public int X;
        public int Y;

        public point(int inX, int inY)
        {
            X = inX;
            Y = inY;
        }
    }
    
}
