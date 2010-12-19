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
    public partial class editableTile : UserControl
    {
        Tile theTile;
        public editableTile(ref Tile inTile)
        {
            theTile = inTile;
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
