using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL_Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace IAPL.Map
{
    public enum TType { Black, Grass, Dirt, Sand, Brick }; //TODO add more tile types
    public enum Direction { North, East, South, West };
    
    public class Tile : WorldObject
    {
        private bool jumpable; //whether the tile is jumpable, like a ledge
        private AFrom aDirection; //which directions you may enter the tile from
        private bool anyEvent; //whether any events are on this tile
        private bool randomEncounter; //whether random encounters can occur on this tile
        private bool ramp; //whether the tile is a bike ramp
        private bool occupied;
        private TType tileType;
        private Texture2D tileTexture;

        //Note, X, Y, and Z must be global in relation to all other tiles of the map
        //each tile on the map must have a unique combination of X, Y and Z
        //TODO check if we need these or if we can give this to Zone
        //private int X; //global X coordinate of tile
        //private int Y; //global Y coordinate of tile
        private byte Z; //global Z coordinate of tile

        #region Constructors
        //default is inaccessable tile
        public Tile(string type)
        {
            jumpable = false;
            aDirection = new AFrom(false, false, false, false);
            anyEvent = false;
            randomEncounter = false;
            ramp = false;
            occupied = false;
            setTType(type);

            //MUST BE MADE UNIQUE
            //X = 0;
            //Y = 0;
            Z = 0;
        }

        //constructor with given x,y, and z coords
        //public Tile(int inX, int inY, int inZ)
        public Tile(int inZ)
        {
            jumpable = false;
            aDirection = new AFrom(false, false, false, false);
            anyEvent = false;
            randomEncounter = false;
            ramp = false;
            occupied = false;

            //MUST BE MADE UNIQUE
            //X = inX;
            //Y = inY;
            Z = (byte)inZ;
        }
        #endregion

        #region Setters
        public void setJumpable(bool value)
        {
            jumpable = value;
        }

        public void setAccessible(bool inNorth, bool inEast, bool inSouth, bool inWest)
        {
            aDirection.north = inNorth;
            aDirection.east = inEast;
            aDirection.south = inSouth;
            aDirection.west = inWest;
        }

        public void setEvent(bool value)
        {
            anyEvent = value;
        }

        public void setRandomEncounter(bool value)
        {
            randomEncounter = value;
        }

        public void setRamp(bool value)
        {
            ramp = value;
        }

        public void setOccupied(bool value)
        {
            occupied = value;
        }

        public void setTType(string type)
        {
            switch (type)
            {
                case "Black":
                    tileType = TType.Black;

                    break;
                case "Grass":
                    tileType = TType.Grass;

                    break;
                case "Dirt":
                    tileType = TType.Dirt;

                    break;
                case "Sand":
                    tileType = TType.Sand;

                    break;
                case "Brick":
                    tileType = TType.Brick;

                    break;
            }
        }
        #endregion

        //makes accessible from all directions
        public void setClear()
        {
            aDirection = new AFrom(true, true, true, true);
        }

        #region Getters

        public bool isJumpable()
        {
            return jumpable;
        }

        public bool isAccessibleFrom(Direction dir)
        {
            bool isAc;
            if(dir == Direction.North && !occupied)
            {
                isAc = aDirection.north;
            }
            else if (dir == Direction.East && !occupied)
            {
                isAc = aDirection.east;
            }
            else if (dir == Direction.South && !occupied)
            {
                isAc = aDirection.south;
            }
            else if (dir == Direction.West && !occupied)
            {
                isAc = aDirection.west;
            }
            else
            {
                isAc = false;
            }

            return isAc;
        }

        public bool isAccessibleFrom(String dir)
        {
            bool isAc;
            if (dir == "UP")
            {
                isAc = aDirection.north;
            }
            else if (dir == "RIGHT")
            {
                isAc = aDirection.east;
            }
            else if (dir == "DOWN")
            {
                isAc = aDirection.south;
            }
            else if (dir == "LEFT")
            {
                isAc = aDirection.west;
            }
            else
            {
                isAc = false;
            }

            return isAc;
        }

        public bool hasEvent()
        {
            return anyEvent;
        }

        public bool hasRandomEncounter()
        {
            return randomEncounter;
        }

        public bool isRamp()
        {
            return ramp;
        }
        #endregion

        public bool isOccupied()
        {
            return occupied;
        }

        public bool isClear()
        {
            bool val = false;
            if (aDirection.Equals(new AFrom(true, true, true, true)) && !occupied)
                val = true;
            return val;
        }

        public TType getTType()
        {
            return tileType;
        }

    }

    public struct AFrom
    {
        //if any of these are set to false it means you may not enter the
        //tile from that direction
        //if all are set to false it is an inaccessible tile
        public bool north;
        public bool east;
        public bool south;
        public bool west;

        
        public AFrom(bool inNorth, bool inEast, bool inSouth, bool inWest)
        {
            north = inNorth;
            east = inEast;
            south = inSouth;
            west = inWest;
        }

       
    }
}
