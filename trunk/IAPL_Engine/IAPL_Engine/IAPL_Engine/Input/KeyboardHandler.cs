using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace IAPL_Engine
{
    class KeyboardHandler
    {

        Player player;

        public KeyboardHandler(Player inPlayer)
        {
            player = inPlayer;
        }

        /// <summary>
        /// Handles all key events upon player input (ran each time update is called in Game1
        /// </summary>
        public void ProcessKeyboard()
        {

            //  if (Keyboard.GetState().IsKeyDown(Keys.Enter)) <-- Enter/Exit Menu

            //  if (Keyboard.GetState().IsKeyDown(Keys.Space)) <-- Interact/Select

            if (Keyboard.GetState().IsKeyDown(Keys.Up)) //move up
                if (!player.isMoving)
                        player.StartMove("UP");

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) //move down
                if (!player.isMoving)
                        player.StartMove("DOWN");

            if (Keyboard.GetState().IsKeyDown(Keys.Left)) //move left
                if (!player.isMoving)
                        player.StartMove("LEFT");

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) // move right
                if (!player.isMoving)
                        player.StartMove("RIGHT");

            /* if (keyboard.getstate().iskeydown(keys.rightshift)) //Right shift. equivalent of 'select' in the games. -bigplrbear
                    if (!keyitem.registered) //Also, some example usage. herp derp
                        console.writeline "Nothing is registered for the shift key \n";
             *      else if (keyitem.registered)
             *          [insert over 9000 while/if/for loops here for key items]
             * */

            player.ProcessMovements();
        }

    }
}
