using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IAPL.Map;

namespace MapEditor
{
    public partial class Floors : Form
    {
        FloorsList floors;

        public Floors()
        {
            InitializeComponent();
            floors = new FloorsList();
            addFloors();
        }

        private void addFloors()
        {
            int x = 0;
            int y = 0;
            foreach (KeyValuePair<Tile, Bitmap> pair in floors.floor)
            {
                //floor
            }
        }
    }
}
