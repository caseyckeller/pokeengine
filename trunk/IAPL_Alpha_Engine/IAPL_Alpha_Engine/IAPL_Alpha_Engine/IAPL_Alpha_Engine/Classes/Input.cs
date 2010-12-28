using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using IAPL_Alpha_Engine.Classes;
using IAPL_Alpha_Engine.Classes.Screens;

namespace IAPL_Alpha_Engine.Classes
{
    static class Input
    {

        public static void ProcessKeys()
        {
            /*
             * Example input checks:
             * 
             * if (Keyboard.GetState().IsKeyDown(Keys.Enter))
             *     do_logic;
             * 
             */

            switch (ScreenHandler.activeScreen)
            {
                case ScreenHandler.ActiveScreen.Title:
                    {
                        switch (TitleScreen.activeMenu)
                        {
                            case TitleScreen.ActiveMenu.Title:
                                {

                                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                                        TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);

                                    break;
                                }
                            case TitleScreen.ActiveMenu.New_Game:
                                {

                                    break;
                                }
                            case TitleScreen.ActiveMenu.Load_Game:
                                {

                                    break;
                                }
                            case TitleScreen.ActiveMenu.Options:
                                {

                                    break;
                                }
                        }
                        break;
                    }
                case ScreenHandler.ActiveScreen.Game:
                    {

                        break;
                    }
            }
        }

    }
}
