using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IAPL_Engine
{

    /// <summary>
    /// This class will contain the heirarchy for the objects (2D for now) to be placed in the world.
    /// It designates the Texture, the Rectangle, the row and column on the map it should be placed.
    /// </summary>
    class WorldObject
    {
        public Texture2D Texture;
        public Rectangle Rect;
        public int currentX;
        public int currentY;
    }
}
