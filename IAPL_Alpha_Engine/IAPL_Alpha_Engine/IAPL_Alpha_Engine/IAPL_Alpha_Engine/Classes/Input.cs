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

        public static int cooldownMax = 10;
        public static int coolDown = 0;
        public static bool isCooling = false;

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
                        if (isCooling)
                        {
                            coolDown--;

                            if (coolDown <= 0)
                                isCooling = false;
                        }
                        else
                        {
                            switch (TitleScreen.activeMenu)
                            {
                                case TitleScreen.ActiveMenu.Title:
                                    {

                                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Z))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.New_Game:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Load_Game:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Options:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }


                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Main_Menu:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                                        {
                                            TitleScreen.mainMenuSelection--;
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        if (Keyboard.GetState().IsKeyDown(Keys.Down))
                                        {
                                            TitleScreen.mainMenuSelection++;
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        switch (TitleScreen.mainMenuSelection)
                                        {
                                            case 0:
                                                {
                                                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Z))
                                                    {
                                                        TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.New_Game);
                                                        coolDown = cooldownMax;
                                                        isCooling = true;
                                                    }

                                                    break;
                                                }
                                            case 1:
                                                {
                                                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Z))
                                                    {
                                                        TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Load_Game);
                                                        coolDown = cooldownMax;
                                                        isCooling = true;
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Z))
                                                    {
                                                        TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Options);
                                                        coolDown = cooldownMax;
                                                        isCooling = true;
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Z))
                                                    {
                                                        TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Mystery_Gift);
                                                        coolDown = cooldownMax;
                                                        isCooling = true;
                                                    }
                                                    break;
                                                }
                                        }

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Mystery_Gift:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Title);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        break;
                                    }
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
