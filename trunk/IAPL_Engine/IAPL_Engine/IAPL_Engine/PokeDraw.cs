<<<<<<< .mine
﻿using System;
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
        public Texture2D blackTexture;
        public Texture2D dirtTexture;
        public Texture2D sandTexture;
        public Texture2D brickTexture;
        public Texture2D wallTexture;


        public Zone map;

        public PokeDraw()
        {
            
        }

        public void loadTextures()
        {
            blackTexture = null;
            grassTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_grass_tile");
            blackTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_black_tile");
            dirtTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_dirt_tile");
            sandTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_sand_tile");
            brickTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_brick_tile");
            wallTexture = Content.Load<Texture2D>("WorldObject/Zone/Tile/debug_wall_tile");

            //etc

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
                    Rectangle r = new Rectangle(x * 32, y * 32, 32, 32);
                    switch (map.tile[x,y].getTType())
                    {
                        case TType.Grass:
                            spriteBatch.Draw(grassTexture, r, Color.White);
                            break;
                        case TType.Black:
                            spriteBatch.Draw(blackTexture, r, Color.White);
                            break;
                        case TType.Dirt:
                            spriteBatch.Draw(dirtTexture, r, Color.White);
                            break;
                        case TType.Sand:
                            spriteBatch.Draw(sandTexture, r, Color.White);
                            break;
                        case TType.Wall:
                            spriteBatch.Draw(wallTexture, r, Color.White);
                            break;
                        case TType.Brick:
                            spriteBatch.Draw(brickTexture, r, Color.White);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}
=======
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
>>>>>>> .r46
