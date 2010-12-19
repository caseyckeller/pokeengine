using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Drawing;
using IAPL.Map;

namespace IAPL_Engine
{
    class PokeDraw : MSF.Game
    {
        public SpriteBatch spriteBatch;

        //NOTE come up with a  better way to store these
        //public Texture2D grassTexture;
        //public Texture2D blackTexture;
        //public Texture2D dirtTexture;
        //public Texture2D sandTexture;
        //public Texture2D brickTexture;
        //public Texture2D wallTexture;
        public SortedList<String, Texture2D> texture;
        GraphicsDevice graphics;


        public Zone map;

        public PokeDraw(GraphicsDevice graphics)
        {
            this.graphics = graphics;
            texture = new SortedList<string, Texture2D>();
        }

        public void loadTextures()
        {
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            //TEXTURES GO INTO \Content\WorldObject\Zone\Tile and are loaded automatically
            string texturesDir = Path.Combine(rootDir, "Content\\WorldObject\\Zone\\Tile");

            foreach (string path in Directory.GetFiles(texturesDir))
            {
                if (path.ToLower().EndsWith(".png"))
                {
                    Bitmap image = new Bitmap(path);
                    Graphics imageGraphics = Graphics.FromImage(image);
                    String[] temp = path.Split('\\');
                    Texture2D newTex = new Texture2D(graphics, image.Width, image.Height);
                    newTex = Texture2D.FromStream(graphics, new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read));
                    texture.Add(temp[temp.Length - 1], newTex);
                }
            }

        }

        public void setMapAndBatch(ref Zone inMap, ref SpriteBatch inBatch)
        {
            map = inMap;
            spriteBatch = inBatch;
        }

        /// <summary>
        /// This draws the tiles
        /// </summary>
        public void drawTiles()
        {
            for (int x = 0; x < map.mapWidth; x++)
            {
                for (int y = 0; y < map.mapHeight; y++)
                {
                    MSF.Rectangle r = new MSF.Rectangle(x * 32, y * 32, 32, 32);
                    spriteBatch.Draw(texture[map.tile[x,y].tileType], r, MSF.Color.White);
                }
            }
        }

    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IAPL.Map;

namespace IAPL_Engine
{
    class PokeDraw : Game
    {
        public SpriteBatch spriteBatch;

        //NOTE come up with a  better way to store these
        public Texture2D grassTexture;
        public Zone map;

        public PokeDraw()
        {
            
        }

        public void loadTextures()
        {

            grassTexture = Content.Load<Texture2D>("Zone/Tile/Grass");
            //etc

        }

        public void setMap(ref Zone inMap)
        {
            map = inMap;
        }

        public void drawTiles()
        {
            for (int x = 0; x < map.mapWidth; x++)
            {
                for (int y = 0; y < map.mapHeight; y++)
                {
                    Rectangle r = new Rectangle(x * map.mapWidth, y * map.mapHeight, 32, 32);
                    //well, draw the correct texture anyway, probably not grass
                    spriteBatch.Draw(grassTexture, r, Color.White);
                }
            }
        }
    }
}
*/
