using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IAPL.Map;

namespace MapEditor
{
    /// <summary>
    /// This displays and retrieves information about floor types
    /// </summary>
    public partial class floorControl : UserControl
    {
        Tile tile;

        public floorControl(Tile inTile, Bitmap inImage)
        {
            InitializeComponent();
            pictureBox1.Image = inImage;
            tile = inTile;
        }
    }
}
