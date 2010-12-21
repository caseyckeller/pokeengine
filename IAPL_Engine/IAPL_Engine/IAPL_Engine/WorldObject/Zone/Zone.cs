using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace IAPL.Map
{
    public class Zone
    {
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

        public String zoneName;  //this is the name of the zone, generally "route xxxx"
        //TODO make way to store adjacent zones
        public Tile[,] tile; //a 2D array of nodes, these are individual tiles of a map
        //starts at 0,0 for bottom left corner and is x,y
        //so tile[1][2] is the second tile from the left, and 3 from the bottom
        //NOT global, relative to zone only
        //global coordinate would be global X and Y plus tile x and y

        public List<int> randomPokemon;
        //private Scenery scenery;

        public int globalX; //global X coordinate of tile [0][0]
        public int globalY; //global Y coordinate of tile [0][0]

        #region Constructors
        //default constructor makes a 50x50 zone
        public Zone()
        {
            zoneName = "Default Name";
            //these must be changed to global unless only one zone exists
            globalX = 0;
            globalY = 0;
            tile = new Tile[50, 50];
            allToDefault();
            randomPokemon = new List<int>();

        }

        //constructor when given size
        public Zone(int inX, int inY)
        {
            zoneName = "Default Name";
            //these must be changed to global unless only one zone exists
            globalX = 0;
            globalY = 0;
            tile = new Tile[inX, inY];
            allToDefault();
            randomPokemon = new List<int>();

        }

        //constructor when given size and name
        public Zone(String name, int inX, int inY)
        {
            zoneName = name;
            //these must be changed to global unless only one zone exists
            globalX = 0;
            globalY = 0;
            tile = new Tile[inX, inY];
            allToDefault();
            randomPokemon = new List<int>();

        }

        //constructor when given global X and Y coordinates and size
        public Zone(int inX, int inY, int inXCoord, int inYCoord)
        {
            zoneName = "Default Name";
            globalX = inXCoord;
            globalY = inYCoord;
            tile = new Tile[inX, inY];
            allToDefault();
            randomPokemon = new List<int>();

        }
        #endregion

        #region Getters
        public int mapWidth
        {
            get { return tile.GetLength(0); }
        }

        public int mapHeight
        {
            get { return tile.GetLength(1); }
        }
        #endregion

        private void allToDefault()
        {
            for (int a = 0; a < mapWidth; a++)
            {
                for (int b = 0; b < mapHeight; b++)
                {
                    tile[a, b] = new Tile();
                }
            }
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

        public void addRandomPokemon(int pDexNo)
        {
            randomPokemon.Add(pDexNo);
        }

        public void removeRandomPokemon(int pDexNo)
        {
            randomPokemon.Remove(pDexNo);
        }

        /*
        public void drawMap(SpriteBatch spriteBatch)
        {

            for (int a = 0; a < mapWidth; a++)
            {
                for (int b = 0; b < mapHeight; b++)
                {
                    Rectangle place = new Rectangle(a * 32, (15 * 32) - (b * 32) - 32, 32, 32);

                    foreach(Tile t in tile)
                    {
                        spriteBatch.Draw(t.getTexture(), place, Color.White); // <--- thx lol
                    }
                }
            }
        }*/

        #region TEST
        public void setMap()
        {
            for (int a = 5; a <= 15; a++)
            {
                for (int b = 5; b <= 10; b++)
                {
                    tile[a, b].setClear();
                    tile[a, b].tileType = "debug_grass_tile.png";
                }
            }
        }
        #endregion
    }
}
