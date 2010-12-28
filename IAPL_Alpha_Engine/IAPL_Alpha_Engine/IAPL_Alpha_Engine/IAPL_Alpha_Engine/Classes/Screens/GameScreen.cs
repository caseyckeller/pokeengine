using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace IAPL_Alpha_Engine.Classes.Screens
{
    static class GameScreen
    {

        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager content;

        

        public struct Textures
        {
            /*
             * Example Texture:
             * 
             * public static Texture2D Player;
             * 
             */



        }

        static public void Initialize(GraphicsDeviceManager g, SpriteBatch s, ContentManager c)
        {
            graphics = g;
            spriteBatch = s;
            content = c;

            
        }

        static public void LoadContent()
        {
            /*
             * Example Use:
             * 
             * Textures.Player = content.Load<Texture2D>("playerTexture");
             * 
             */



        }

        /// <summary>
        /// This method is called once per frame (60fps is desired) to update logic.
        /// </summary>
        static public void Update()
        {

        }

        /// <summary>
        /// This method is called once per frame (60fps is desired) to draw.
        /// </summary>
        static public void Draw()
        {

        }

    }
}
