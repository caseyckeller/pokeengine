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
        public static KeyboardState oldState = new KeyboardState();
        public static KeyboardState newState = new KeyboardState();
        public static int cooldownMax = 10;
        public static int coolDown = 0;
        public static bool isCooling = false;

        public static void ProcessKeys()
        {
            Input.updateState();
            /*
             * Example input checks:
             * 
             * if (Input.isKeyPress(Keys.Enter))
             *     do_logic;
             *     coolDown = cooldownMax; <---
                   isCooling = true;       <--- In Menus
             * 
             */
            if (DialogBox.isVisible)
            {
                DialogBox.HandleInput();
            }

            switch (ScreenHandler.activeScreen)
            {
                case ScreenHandler.ActiveScreen.Title:
                    {
                        if (!DialogBox.isVisible) //dialog box rules all, mwahahahaha
                        {
                            TitleScreen.HandleKeys();
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
                                            ScreenHandler.Sounds.Menu_Select.Play();
                                            isCooling = true;
                                        }

                                        

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.New_Game:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Load_Game:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
                                            coolDown = cooldownMax;
                                            isCooling = true;
                                        }

                                        break;
                                    }
                                case TitleScreen.ActiveMenu.Options:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.X))
                                        {
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
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
                                            ScreenHandler.Sounds.Marker_Up.Play();
                                            isCooling = true;
                                        }

                                        if (Keyboard.GetState().IsKeyDown(Keys.Down))
                                        {
                                            TitleScreen.mainMenuSelection++;
                                            coolDown = cooldownMax;
                                            ScreenHandler.Sounds.Marker_Down.Play();
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
                                                        ScreenHandler.Sounds.Menu_Select.Play();
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
                                                        ScreenHandler.Sounds.Menu_Select.Play();
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
                                                        ScreenHandler.Sounds.Menu_Select.Play();
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
                                                        ScreenHandler.Sounds.Menu_Select.Play();
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
                                            TitleScreen.SwitchMenu(TitleScreen.ActiveMenu.Main_Menu);
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
                        //TODO add this
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            //you might want to change the positions of this to the switch statement, I dunno
        }

        public static void updateState()
        {
            oldState = newState;
            newState = Keyboard.GetState();
        }

        public static bool isKeyPress(Keys theKey)
        {
            bool isPress = false;
            if (newState.IsKeyUp(theKey) && oldState.IsKeyDown(theKey))
            {
                isPress = true;
            }
            return isPress;
        }

    }
}
