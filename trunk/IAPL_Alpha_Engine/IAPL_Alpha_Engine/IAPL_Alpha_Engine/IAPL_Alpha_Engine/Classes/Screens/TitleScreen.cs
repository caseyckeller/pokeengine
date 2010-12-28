using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
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

        public struct Sounds
        {

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
            switch (newMenu)
            {
                case ActiveMenu.Title:
                    {
                        ResetAnimations();
                        ScreenHandler.Visible.TitleMenuBox = false;
                        ScreenHandler.Visible.Marker = false;
                        break;
                    }
                case ActiveMenu.Load_Game:
                    {
                        ScreenHandler.Visible.TitleMenuBox = false;
                        ScreenHandler.Visible.Marker = false;
                        break;
                    }
                case ActiveMenu.New_Game:
                    {
                        ScreenHandler.Visible.TitleMenuBox = false;
                        ScreenHandler.Visible.Marker = false;
                        break;
                    }
                case ActiveMenu.Mystery_Gift:
                    {
                        ScreenHandler.Visible.TitleMenuBox = false;
                        ScreenHandler.Visible.Marker = false;
                        break;
                    }
                case ActiveMenu.Options:
                    {
                        ScreenHandler.Visible.TitleMenuBox = false;
                        break;
                    }
            }


            activeMenu = newMenu;
        }

        /// <summary>
        /// Handles keystrokes for the title menu
        /// </summary>
        /// <param name="isCooling"></param>
        /// <param name="coolDown"></param>
        /// <param name="cooldownMax"></param>
        public static void HandleKeys()
        {
            /*
            if (Input.isCooling)
            {
                Input.coolDown--;

                if (Input.coolDown <= 0)
                    Input.isCooling = false;
            }
            else
            {*/
                switch (TitleScreen.activeMenu)
                {
                    case TitleScreen.ActiveMenu.Title:
                        {

                            if (Input.isKeyPress(Keys.Enter) || Input.isKeyPress(Keys.Z))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }



                            break;
                        }
                    case TitleScreen.ActiveMenu.New_Game:
                        {
                            if (Input.isKeyPress(Keys.RightShift) || Input.isKeyPress(Keys.X))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }

                            break;
                        }
                    case TitleScreen.ActiveMenu.Load_Game:
                        {
                            if (Input.isKeyPress(Keys.RightShift) || Input.isKeyPress(Keys.X))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }

                            break;
                        }
                    case TitleScreen.ActiveMenu.Options:
                        {
                            if (Input.isKeyPress(Keys.RightShift) || Input.isKeyPress(Keys.X))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }


                            break;
                        }
                    case TitleScreen.ActiveMenu.Main_Menu:
                        {
                            if (Input.isKeyPress(Keys.RightShift) || Input.isKeyPress(Keys.X))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }

                            if (Input.isKeyPress(Keys.Up))
                            {
                                TitleScreen.mainMenuSelection--;
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }

                            if (Input.isKeyPress(Keys.Down))
                            {
                                TitleScreen.mainMenuSelection++;
                                Input.coolDown = Input.cooldownMax;
                                ScreenHandler.Sounds.Marker_Down.Play();
                                Input.isCooling = true;
                            }

                            switch (TitleScreen.mainMenuSelection)
                            {
                                case 0:
                                    {
                                        if (Input.isKeyPress(Keys.Z) || Input.isKeyPress(Keys.Enter))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.New_Game);
                                            Input.coolDown = Input.cooldownMax;
                                            ScreenHandler.Sounds.Marker_Down.Play();
                                            Input.isCooling = true;
                                            if(Input.isKeyPress(Keys.Z))
                                                DialogBox.showDialog("Hello you crazy cats, dude this is awesome");
                                        }

                                        break;
                                    }
                                case 1:
                                    {
                                        if (Input.isKeyPress(Keys.Enter) || Input.isKeyPress(Keys.Z))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Load_Game);
                                            Input.coolDown = Input.cooldownMax;
                                            ScreenHandler.Sounds.Marker_Down.Play();
                                            Input.isCooling = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if (Input.isKeyPress(Keys.Enter) || Input.isKeyPress(Keys.Z))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Options);
                                            Input.coolDown = Input.cooldownMax;
                                            ScreenHandler.Sounds.Marker_Down.Play();
                                            Input.isCooling = true;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (Input.isKeyPress(Keys.Enter) || Input.isKeyPress(Keys.Z))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Mystery_Gift);
                                            Input.coolDown = Input.cooldownMax;
                                            ScreenHandler.Sounds.Marker_Down.Play();
                                            Input.isCooling = true;
                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case TitleScreen.ActiveMenu.Mystery_Gift:
                        {
                            if (Input.isKeyPress(Keys.RightShift) || Input.isKeyPress(Keys.X))
                            {
                                TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                Input.coolDown = Input.cooldownMax;
                                Input.isCooling = true;
                            }

                            break;
                        }
                }
            //}
        }

        #region TitleMenu

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

        #endregion

        #region MainMenu

        static private void DrawMainMenu()
        {
            ScreenHandler.Visible.TitleMenuBox = true;
            ScreenHandler.Visible.Marker = true;

            spriteBatch.DrawString(font, "NEW GAME", new Vector2(58, 43), Color.Black);
            spriteBatch.DrawString(font, "CONTINUE", new Vector2(58, 87), Color.Black);
            spriteBatch.DrawString(font, "OPTIONS", new Vector2(58, 130), Color.Black);
            spriteBatch.DrawString(font, "MYSTERY GIFT", new Vector2(58, 173), Color.Black);

            switch (mainMenuSelection)
            {
                case 0:
                    {
                        ScreenHandler.Rectangles.Marker = new Rectangle(38, 43, ScreenHandler.Textures.Marker.Width, ScreenHandler.Textures.Marker.Height);
                        break;
                    }
                case 1:
                    {
                        ScreenHandler.Rectangles.Marker = new Rectangle(38, 87, ScreenHandler.Textures.Marker.Width, ScreenHandler.Textures.Marker.Height);
                        break;
                    }
                case 2:
                    {
                        ScreenHandler.Rectangles.Marker = new Rectangle(38, 130, ScreenHandler.Textures.Marker.Width, ScreenHandler.Textures.Marker.Height);
                        break;
                    }
                case 3:
                    {
                        ScreenHandler.Rectangles.Marker = new Rectangle(38, 173, ScreenHandler.Textures.Marker.Width, ScreenHandler.Textures.Marker.Height);
                        break;
                    }
            }
        }

        static private void UpdateMainMenu()
        {
            if (mainMenuSelection > 3)
                mainMenuSelection = 0;

            if (mainMenuSelection < 0)
                mainMenuSelection = 3;
        }

        #endregion

        #region OptionsMenu



        #endregion
    }
}
