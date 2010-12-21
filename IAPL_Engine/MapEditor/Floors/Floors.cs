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
            floors = new FloorsList(); //populates itself
            addFloors();
        }

        private void addFloors()
        {
            int x = 0;
            int y = 0;
            foreach (FloorData fl in floors.floor)
            {
                floorControl temp = new floorControl(fl.tile, fl.image);
                temp.Location = new Point(x, y);
                floorsPanel.Controls.Add(temp);
                x += 32;
                if(x>448)
                {
                    x = 0;
                    y+= 32;
                }

            }
        }
    }
}
