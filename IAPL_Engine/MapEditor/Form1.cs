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
    public partial class editorTop : Form
    {
        World theWorld;
        Tile currentSelection;
        Zone tempZone;
        Floors editFloors;
        public editorTop()
        {
            theWorld = new World();
            editFloors = new Floors();
            editFloors.Hide();
            InitializeComponent();
        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            theWorld.worldName = nameBox.Text;
        }

        private void newZoneButton_Click(object sender, EventArgs e)
        {
            try
            {
                tempZone = new Zone(zoneNameBox.Text, Convert.ToInt32(xSizeBox.Text), Convert.ToInt32(ySizeBox.Text));
                for (int x = 0; x < tempZone.mapWidth; x++)
                {
                    for (int y = 0; y < tempZone.mapHeight; y++)
                    {
                        editableTile tempET = new editableTile(ref tempZone.tile[x,y]);
                        tempET.Location = new Point(x * 32, y * 32);
                        tempET.Show();
                        mapBox.CreateControl();
                        mapBox.Controls.Add(tempET);                       
                    }
                }
            }
            catch (FormatException) { };
           
        }

        private void editFloorTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editFloors.Show();
        }

    }
}
