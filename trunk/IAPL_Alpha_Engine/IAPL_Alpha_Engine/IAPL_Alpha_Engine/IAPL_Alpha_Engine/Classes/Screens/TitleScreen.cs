using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace IAPL_Alpha_Engine.Classes.Screens
{
    static class TitleScreen
    {
        #region Structs
        public struct Textures
        {
            /*
             * Example Texture:
             * 
             * public static Texture2D Background;
             * 
             */

            public static Texture2D PokemonLogo;
            public static Texture2D Version;

        }

        public struct Rectangles
        {
            /*
             * Example Texture:
             * 
             * public static Rectangle Background;
             * 
             */

            public static Rectangle PokemonLogo;
            public static Rectangle Version;
        }

        public struct Options
        {
            /// <summary>
            /// 0 = Fast, 1 = Medium, 2 = Slow
            /// </summary>
            public static byte TextSpeed = 0;

            /// <summary>
            /// 0 = Shift, 1 = Set
            /// </summary>
            public static byte BattleStyle = 0;

            /// <summary>
            /// 0 = Text Speed, 1 = Battle Style, 3 = Cancel
            /// </summary>
            public static byte SubMenu = 0;
        }
        #endregion

        #region Fields
        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager content;
        static SpriteFont font;

        public static ActiveMenu activeMenu { get; set; }

        public enum ActiveMenu { Title, Main_Menu, New_Game, Load_Game, Options, Mystery_Gift }

        /// <summary>
        /// 0 = New Game, 1 = Load Game, 2 = Options, 3 = Mystery Gift
        /// </summary>
        public static int mainMenuSelection = 0;

        private static bool logoAnimated;
        private static int logoAnimationNumber;
        private static bool animateVersion;
        private static bool versionAnimated;
        private static int versionAnimationNumber;
        #endregion


        static public void Initialize(GraphicsDeviceManager g, SpriteBatch s, ContentManager c, SpriteFont f)
        {
            graphics = g;
            spriteBatch = s;
            content = c;
            font = f;

            activeMenu = ActiveMenu.Title;
        }

        static public void LoadContent()
        {
            /*
             * Example use:
             * 
             * Texture.Background = content.Load<Texture2D>("titleBackground");
             * 
             */

            Textures.PokemonLogo = content.Load<Texture2D>(@"Textures\Title\pokemon_logo");
            Textures.Version = content.Load<Texture2D>(@"Textures\Title\pokemon_version");

            ResetAnimations();
        }

        /// <summary>
        /// This method is called once per frame (60fps is desired) to update logic.
        /// </summary>
        static public void Update()
        {
            switch (activeMenu)
            {
                case ActiveMenu.Title:
                    UpdateTitleMenu();
                    break;
                case ActiveMenu.Main_Menu:
                    UpdateMainMenu();
                    break;
            }
        }

        /// <summary>
        /// This method is called once per frame (60fps is desired) to draw.
        /// </summary>
        static public void Draw()
        {
            switch (activeMenu)
            {
                case ActiveMenu.Title:
                    DrawTitleMenu();
                    break;
                case ActiveMenu.Main_Menu:
                    DrawMainMenu();
                    break;
            }
        }

        /// <summary>
        /// Switches the menu screen, handling transitions
        /// </summary>
        /// <param name="newMenu">The menu to be switched to</param>
        static public void SwitchMenu(ActiveMenu newMenu)
        {
            if (newMenu == ActiveMenu.Title)
                ResetAnimations();


            activeMenu = newMenu;
        }

        static private void DrawTitleMenu()
        {

            spriteBatch.Draw(Textures.PokemonLogo, Rectangles.PokemonLogo, Color.White);
            spriteBatch.Draw(Textures.Version, Rectangles.Version, Color.White);
        }

        static private void UpdateTitleMenu()
        {
            if (!logoAnimated)
            {
                LogoAnimation();
            }
            if (animateVersion)
            {
                if (!versionAnimated)
                {
                    VersionAnimation();
                }
            }
        }

        static private void DrawMainMenu()
        {

        }

        static private void UpdateMainMenu()
        {
            if (mainMenuSelection > 3)
                mainMenuSelection = 0;

            if (mainMenuSelection < 0)
                mainMenuSelection = 3;
        }

        static private void LogoAnimation()
        {
            if (logoAnimationNumber > 0)
            {
                Rectangles.PokemonLogo.Y++;
                logoAnimationNumber--;
            }
            else if (logoAnimationNumber <= 0)
            {
                logoAnimated = true;
                animateVersion = true;
            }
        }

        static private void VersionAnimation()
        {
            if (versionAnimationNumber > 0)
            {
                Rectangles.Version.X = (int)(640.0 - (120.0 - (double)versionAnimationNumber) * 4.55);
                versionAnimationNumber--;
            }
            else if (versionAnimationNumber <= 0)
            {
                versionAnimated = true;
            }
        }

        static private void ResetAnimations()
        {
            logoAnimated = false;
            logoAnimationNumber = 120;

            animateVersion = false;
            versionAnimated = false;
            versionAnimationNumber = 120;

            Rectangles.PokemonLogo = new Rectangle(320 - (Textures.PokemonLogo.Width / 2), 0 - (Textures.PokemonLogo.Height), Textures.PokemonLogo.Width, Textures.PokemonLogo.Height);
            Rectangles.Version = new Rectangle(640, (Textures.PokemonLogo.Height + 30), Textures.Version.Width, Textures.Version.Height);
        }
    }
}
