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

        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager content;
        static SpriteFont font;

        public static ActiveMenu activeMenu { get; set; }

        public enum ActiveMenu { Title, Main_Menu, New_Game, Load_Game, Options }

        private static bool logoAnimated;
        private static int logoAnimationNumber;
        private static bool animateVersion;
        private static bool versionAnimated;
        private static int versionAnimationNumber;

        private static double screenWidth = 640.0;

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

        static public void Initialize(GraphicsDeviceManager g, SpriteBatch s, ContentManager c, SpriteFont f)
        {
            graphics = g;
            spriteBatch = s;
            content = c;
            font = f;

            activeMenu = ActiveMenu.Title;
            logoAnimated = false;
            logoAnimationNumber = 120;

            animateVersion = false;
            versionAnimated = false;
            versionAnimationNumber = 120;
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

            Rectangles.PokemonLogo = new Rectangle(320 - (Textures.PokemonLogo.Width / 2), 0 - (Textures.PokemonLogo.Height), Textures.PokemonLogo.Width, Textures.PokemonLogo.Height);
            Rectangles.Version = new Rectangle(640, (Textures.PokemonLogo.Height + 30), Textures.Version.Width, Textures.Version.Height);

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
            }
        }

        /// <summary>
        /// Switches the menu screen, handling transitions
        /// </summary>
        /// <param name="newMenu">The menu to be switched to</param>
        static public void SwitchMenu(ActiveMenu newMenu)
        {
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
    }
}
