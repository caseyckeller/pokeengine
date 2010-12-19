
namespace MapEditor
{
    partial class editorTop
    {
        

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapBox = new System.Windows.Forms.Panel();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameButton = new System.Windows.Forms.Button();
            this.newZoneButton = new System.Windows.Forms.Button();
            this.zoneNameBox = new System.Windows.Forms.TextBox();
            this.xSizeBox = new System.Windows.Forms.TextBox();
            this.ySizeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolBox = new System.Windows.Forms.TabControl();
            this.Floors = new System.Windows.Forms.TabPage();
            this.Scenery = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFloorTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSceneryTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapBox.Location = new System.Drawing.Point(146, 36);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(684, 560);
            this.mapBox.TabIndex = 0;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(836, 58);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(141, 20);
            this.nameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(874, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "World Name";
            // 
            // nameButton
            // 
            this.nameButton.Location = new System.Drawing.Point(902, 84);
            this.nameButton.Name = "nameButton";
            this.nameButton.Size = new System.Drawing.Size(75, 23);
            this.nameButton.TabIndex = 4;
            this.nameButton.Text = "Set";
            this.nameButton.UseVisualStyleBackColor = true;
            this.nameButton.Click += new System.EventHandler(this.nameButton_Click);
            // 
            // newZoneButton
            // 
            this.newZoneButton.Location = new System.Drawing.Point(902, 548);
            this.newZoneButton.Name = "newZoneButton";
            this.newZoneButton.Size = new System.Drawing.Size(78, 47);
            this.newZoneButton.TabIndex = 5;
            this.newZoneButton.Text = "New Zone";
            this.newZoneButton.UseVisualStyleBackColor = true;
            this.newZoneButton.Click += new System.EventHandler(this.newZoneButton_Click);
            // 
            // zoneNameBox
            // 
            this.zoneNameBox.Location = new System.Drawing.Point(853, 420);
            this.zoneNameBox.Name = "zoneNameBox";
            this.zoneNameBox.Size = new System.Drawing.Size(124, 20);
            this.zoneNameBox.TabIndex = 6;
            // 
            // xSizeBox
            // 
            this.xSizeBox.Location = new System.Drawing.Point(917, 447);
            this.xSizeBox.Name = "xSizeBox";
            this.xSizeBox.Size = new System.Drawing.Size(59, 20);
            this.xSizeBox.TabIndex = 7;
            // 
            // ySizeBox
            // 
            this.ySizeBox.Location = new System.Drawing.Point(917, 473);
            this.ySizeBox.Name = "ySizeBox";
            this.ySizeBox.Size = new System.Drawing.Size(59, 20);
            this.ySizeBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(871, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "X Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(871, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(874, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Zone Name:";
            // 
            // toolBox
            // 
            this.toolBox.Controls.Add(this.Floors);
            this.toolBox.Controls.Add(this.Scenery);
            this.toolBox.Location = new System.Drawing.Point(3, 36);
            this.toolBox.Name = "toolBox";
            this.toolBox.SelectedIndex = 0;
            this.toolBox.Size = new System.Drawing.Size(137, 560);
            this.toolBox.TabIndex = 12;
            // 
            // Floors
            // 
            this.Floors.Location = new System.Drawing.Point(4, 22);
            this.Floors.Name = "Floors";
            this.Floors.Padding = new System.Windows.Forms.Padding(3);
            this.Floors.Size = new System.Drawing.Size(129, 534);
            this.Floors.TabIndex = 0;
            this.Floors.Text = "Floors";
            this.Floors.UseVisualStyleBackColor = true;
            // 
            // Scenery
            // 
            this.Scenery.Location = new System.Drawing.Point(4, 22);
            this.Scenery.Name = "Scenery";
            this.Scenery.Padding = new System.Windows.Forms.Padding(3);
            this.Scenery.Size = new System.Drawing.Size(129, 534);
            this.Scenery.TabIndex = 1;
            this.Scenery.Text = "Scenery";
            this.Scenery.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.floorsToolStripMenuItem,
            this.sceneryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // floorsToolStripMenuItem
            // 
            this.floorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFloorTypesToolStripMenuItem});
            this.floorsToolStripMenuItem.Name = "floorsToolStripMenuItem";
            this.floorsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.floorsToolStripMenuItem.Text = "Floors";
            // 
            // sceneryToolStripMenuItem
            // 
            this.sceneryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSceneryTypesToolStripMenuItem});
            this.sceneryToolStripMenuItem.Name = "sceneryToolStripMenuItem";
            this.sceneryToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sceneryToolStripMenuItem.Text = "Scenery";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editFloorTypesToolStripMenuItem
            // 
            this.editFloorTypesToolStripMenuItem.Name = "editFloorTypesToolStripMenuItem";
            this.editFloorTypesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editFloorTypesToolStripMenuItem.Text = "Edit Floor Types";
            // 
            // editSceneryTypesToolStripMenuItem
            // 
            this.editSceneryTypesToolStripMenuItem.Name = "editSceneryTypesToolStripMenuItem";
            this.editSceneryTypesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editSceneryTypesToolStripMenuItem.Text = "Edit Scenery Types";
            // 
            // editorTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 618);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ySizeBox);
            this.Controls.Add(this.xSizeBox);
            this.Controls.Add(this.zoneNameBox);
            this.Controls.Add(this.newZoneButton);
            this.Controls.Add(this.nameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "editorTop";
            this.Text = "Map Editor";
            this.toolBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mapBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nameButton;
        private System.Windows.Forms.Button newZoneButton;
        private System.Windows.Forms.TextBox zoneNameBox;
        private System.Windows.Forms.TextBox xSizeBox;
        private System.Windows.Forms.TextBox ySizeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl toolBox;
        private System.Windows.Forms.TabPage Floors;
        private System.Windows.Forms.TabPage Scenery;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFloorTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sceneryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSceneryTypesToolStripMenuItem;
    }
}

