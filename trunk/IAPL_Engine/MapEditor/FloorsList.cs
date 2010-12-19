using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using IAPL.Map;

namespace MapEditor
{
    public class FloorsList
    {
        public SortedList<Tile, Bitmap> floor;

        public FloorsList()
        {
            floor = new SortedList<Tile, Bitmap>();
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
            string floorsDir = Path.Combine(rootDir, "Resources\\Floors");

            foreach (string path in Directory.GetFiles(floorsDir))
            {
                if(path.EndsWith(".png"))
                {
                    floor.Add(new Tile(), new Bitmap(path));
                }
            }
        }
    }
}
