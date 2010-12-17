using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IAPL.Map;

namespace IAPL_Engine
{
    class Player : WorldObject
    {
        private string direction = "NONE";

        public bool isMoving = false;
        public int moveCounter = 0;
        public Zone map;
        

        public Player()
        {
            map = null;
            
            currentX = 9;
            currentY = 7;

        }

        public void setPlayerMap(ref Zone theMap)
        {
            map = theMap;
        }


        public void StartMove(string d)
        {
            bool canMove = false;

            switch (d)
            {
                case "LEFT":
                    {
                        if (map.tile[currentX - 1, currentY].isAccessibleFrom(Direction.East))
                        {
                            currentX -= 1;
                            canMove = true;
                        }
                        break;
                    }
                case "RIGHT":
                    {
                        if (map.tile[currentX + 1, currentY].isAccessibleFrom(Direction.West))
                        {
                            currentX += 1;
                            canMove = true;
                        }
                        break;
                    }
                case "UP":
                    {
                        if (map.tile[currentX, currentY - 1].isAccessibleFrom(Direction.South))
                        {
                            currentY -= 1;
                            canMove = true;
                        }
                        break;
                    }
                case "DOWN":
                    {
                        if (map.tile[currentX, currentY + 1].isAccessibleFrom(Direction.North))
                        {
                            currentY += 1;
                            canMove = true;
                        }
                        break;
                    }
                default: break;
            }
            if (canMove)
            {
                direction = d;
                moveCounter = (Texture.Height / 2);
                isMoving = true;
            }
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
         
    }
}
