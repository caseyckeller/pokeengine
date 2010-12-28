using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace IAPL_Alpha_Engine.Classes.Screens
{
    static class ScreenHandler
    {

        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager content;
        static SpriteFont font;

        public static ActiveScreen activeScreen { get; set; }

        public enum ActiveScreen { Title, Game }

        /// <summary>
        /// Initializes the Screen handler and starts the game.
        /// </summary>
        static public void Initialize(GraphicsDeviceManager g, SpriteBatch s, ContentManager c, SpriteFont f)
        {
            graphics = g;
            spriteBatch = s;
            content = c;
            font = f;

            activeScreen = ActiveScreen.Title;
            TitleScreen.Initialize(g,s,c,f);
            TitleScreen.LoadContent();
        }

        /// <summary>
        /// Calls the active screen's update function
        /// </summary>
        static public void Update()
        {
            switch (activeScreen)
            {
                case ActiveScreen.Title:
                    TitleScreen.Update();
                    break;

                case ActiveScreen.Game:
                    GameScreen.Update();
                    break;
            }
        }

        /// <summary>
        /// Calls the active screen's draw function
        /// </summary>
        static public void Draw()
        {
            switch (activeScreen)
            {
                case ActiveScreen.Title:
                    TitleScreen.Draw();
                    break;

                case ActiveScreen.Game:
                    GameScreen.Draw();
                    break;
            }
        }
    }
}
