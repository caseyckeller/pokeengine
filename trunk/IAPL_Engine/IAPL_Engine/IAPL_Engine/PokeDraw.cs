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
