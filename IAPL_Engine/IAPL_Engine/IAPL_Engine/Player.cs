using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IAPL_Engine
{
    class Player
    {
        private string direction = "NONE";

        public Texture2D Texture;
        public Rectangle Rect;
        public bool isMoving = false;
        public int moveCounter = 0;


        public void StartMove(string d)
        {
            direction = d;
            moveCounter = (Texture.Height / 2);
            isMoving = true;
        }

        public void ProcessMovements()
        {
            if (moveCounter > 0)
            {
                switch (direction)
                {
                    case "LEFT":
                        {
                            Rect.X -= 2;
                            break;
                        }

                    case "RIGHT":
                        {
                            Rect.X += 2;
                            break;
                        }

                    case "UP":
                        {
                            Rect.Y -= 2;
                            break;
                        }
                    case "DOWN":
                        {
                            Rect.Y += 2;
                            break;
                        }
                }

                moveCounter--;
            }
            else if(moveCounter <= 0)
            {
                isMoving = false;
                direction = "NONE";
            }
        }

        //  true -> There is a collision
        //  false -> There is no collision
        public bool CheckCollisions(string d, int mapWidth, int mapHeight)
        {
            switch (d)
            {
                case "LEFT":
                    {
                        if(Rect.Left > 0)
                            return false;

                        return true;
                    }
                case "RIGHT":
                    {
                        if (Rect.Right < mapWidth)
                            return false;

                        return true;
                    }
                case "UP":
                    {
                        if (Rect.Top > 0)
                            return false;

                        return true;
                    }
                case "DOWN":
                    {
                        if (Rect.Bottom < mapHeight)
                            return false;

                        return true;
                    }
            }

            return false;
        }
    }
}
