namespace MapEditor
{
    partial class Floors
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
            this.floorsPanel = new System.Windows.Forms.Panel();
            this.aFromAbove = new System.Windows.Forms.CheckBox();
            this.aFromLeft = new System.Windows.Forms.CheckBox();
            this.aFromRight = new System.Windows.Forms.CheckBox();
            this.aFromBelow = new System.Windows.Forms.CheckBox();
            this.jumpable = new System.Windows.Forms.CheckBox();
            this.ramp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // floorsPanel
            // 
            this.floorsPanel.AutoScroll = true;
            this.floorsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floorsPanel.Location = new System.Drawing.Point(4, 5);
            this.floorsPanel.Name = "floorsPanel";
            this.floorsPanel.Size = new System.Drawing.Size(493, 320);
            this.floorsPanel.TabIndex = 0;
            // 
            // aFromAbove
            // 
            this.aFromAbove.AutoSize = true;
            this.aFromAbove.Location = new System.Drawing.Point(75, 350);
            this.aFromAbove.Name = "aFromAbove";
            this.aFromAbove.Size = new System.Drawing.Size(80, 17);
            this.aFromAbove.TabIndex = 1;
            this.aFromAbove.Text = "checkBox1";
            this.aFromAbove.UseVisualStyleBackColor = true;
            // 
            // aFromLeft
            // 
            this.aFromLeft.AutoSize = true;
            this.aFromLeft.Location = new System.Drawing.Point(30, 403);
            this.aFromLeft.Name = "aFromLeft";
            this.aFromLeft.Size = new System.Drawing.Size(80, 17);
            this.aFromLeft.TabIndex = 2;
            this.aFromLeft.Text = "checkBox2";
            this.aFromLeft.UseVisualStyleBackColor = true;
            // 
            // aFromRight
            // 
            this.aFromRight.AutoSize = true;
            this.aFromRight.Location = new System.Drawing.Point(129, 403);
            this.aFromRight.Name = "aFromRight";
            this.aFromRight.Size = new System.Drawing.Size(80, 17);
            this.aFromRight.TabIndex = 3;
            this.aFromRight.Text = "checkBox3";
            this.aFromRight.UseVisualStyleBackColor = true;
            // 
            // aFromBelow
            // 
            this.aFromBelow.AutoSize = true;
            this.aFromBelow.Location = new System.Drawing.Point(75, 449);
            this.aFromBelow.Name = "aFromBelow";
            this.aFromBelow.Size = new System.Drawing.Size(80, 17);
            this.aFromBelow.TabIndex = 4;
            this.aFromBelow.Text = "checkBox4";
            this.aFromBelow.UseVisualStyleBackColor = true;
            // 
            // jumpable
            // 
            this.jumpable.AutoSize = true;
            this.jumpable.Location = new System.Drawing.Point(338, 380);
            this.jumpable.Name = "jumpable";
            this.jumpable.Size = new System.Drawing.Size(71, 17);
            this.jumpable.TabIndex = 5;
            this.jumpable.Text = "Jumpable";
            this.jumpable.UseVisualStyleBackColor = true;
            // 
            // ramp
            // 
            this.ramp.AutoSize = true;
            this.ramp.Location = new System.Drawing.Point(338, 403);
            this.ramp.Name = "ramp";
            this.ramp.Size = new System.Drawing.Size(54, 17);
            this.ramp.TabIndex = 6;
            this.ramp.Text = "Ramp";
            this.ramp.UseVisualStyleBackColor = true;
            // 
            // Floors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 507);
            this.Controls.Add(this.ramp);
            this.Controls.Add(this.jumpable);
            this.Controls.Add(this.aFromBelow);
            this.Controls.Add(this.aFromRight);
            this.Controls.Add(this.aFromLeft);
            this.Controls.Add(this.aFromAbove);
            this.Controls.Add(this.floorsPanel);
            this.Name = "Floors";
            this.Text = "Floors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel floorsPanel;
        private System.Windows.Forms.CheckBox aFromAbove;
        private System.Windows.Forms.CheckBox aFromLeft;
        private System.Windows.Forms.CheckBox aFromRight;
        private System.Windows.Forms.CheckBox aFromBelow;
        private System.Windows.Forms.CheckBox jumpable;
        private System.Windows.Forms.CheckBox ramp;
    }
}