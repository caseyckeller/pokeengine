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

            //you might want to change the positions of this to the switch statement, I dunno
            if (DialogBox.isVisible)
            {
                DialogBox.HandleInput();
            }
            else
            {
                switch (ScreenHandler.activeScreen)
                {
                    case ScreenHandler.ActiveScreen.Title:
                        {
                            TitleScreen.HandleKeys();
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
            }
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
