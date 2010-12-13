namespace PokemonEditor
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.baseAttack = new System.Windows.Forms.TextBox();
            this.baseDefense = new System.Windows.Forms.TextBox();
            this.baseSPAtk = new System.Windows.Forms.TextBox();
            this.baseSPDef = new System.Windows.Forms.TextBox();
            this.baseSpeed = new System.Windows.Forms.TextBox();
            this.baseHP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.typeOne = new System.Windows.Forms.ComboBox();
            this.typeTwo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.expTypeBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pdexEntry = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PDexNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPokemonListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePokemonListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.addPokemonButton = new System.Windows.Forms.Button();
            this.pokeListBox = new System.Windows.Forms.ListBox();
            this.debugTest = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(121, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOTE: THIS IS ONLY A SEMI FUNCTIONAL PROTOTYPE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(139, 88);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(143, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.Text = "Enter Name";
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // baseAttack
            // 
            this.baseAttack.Location = new System.Drawing.Point(139, 140);
            this.baseAttack.Name = "baseAttack";
            this.baseAttack.Size = new System.Drawing.Size(60, 20);
            this.baseAttack.TabIndex = 3;
            // 
            // baseDefense
            // 
            this.baseDefense.Location = new System.Drawing.Point(139, 166);
            this.baseDefense.Name = "baseDefense";
            this.baseDefense.Size = new System.Drawing.Size(60, 20);
            this.baseDefense.TabIndex = 4;
            // 
            // baseSPAtk
            // 
            this.baseSPAtk.Location = new System.Drawing.Point(139, 192);
            this.baseSPAtk.Name = "baseSPAtk";
            this.baseSPAtk.Size = new System.Drawing.Size(60, 20);
            this.baseSPAtk.TabIndex = 5;
            // 
            // baseSPDef
            // 
            this.baseSPDef.Location = new System.Drawing.Point(139, 218);
            this.baseSPDef.Name = "baseSPDef";
            this.baseSPDef.Size = new System.Drawing.Size(60, 20);
            this.baseSPDef.TabIndex = 6;
            // 
            // baseSpeed
            // 
            this.baseSpeed.Location = new System.Drawing.Point(139, 244);
            this.baseSpeed.Name = "baseSpeed";
            this.baseSpeed.Size = new System.Drawing.Size(60, 20);
            this.baseSpeed.TabIndex = 7;
            // 
            // baseHP
            // 
            this.baseHP.Location = new System.Drawing.Point(139, 114);
            this.baseHP.Name = "baseHP";
            this.baseHP.Size = new System.Drawing.Size(60, 20);
            this.baseHP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pokemon Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Base HP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Base Attack:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Base Defense:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Base Special Attack:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Base Special Defense:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Base Speed:";
            // 
            // typeOne
            // 
            this.typeOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeOne.FormattingEnabled = true;
            this.typeOne.Items.AddRange(new object[] {
            "Bug",
            "Dark",
            "Dragon",
            "Electric",
            "Fighting",
            "Fire",
            "Flying",
            "Ghost",
            "Grass",
            "Ground",
            "Ice",
            "Normal",
            "Poison",
            "Psychic",
            "Rock",
            "Steel",
            "Water"});
            this.typeOne.Location = new System.Drawing.Point(389, 88);
            this.typeOne.Name = "typeOne";
            this.typeOne.Size = new System.Drawing.Size(121, 21);
            this.typeOne.TabIndex = 8;
            // 
            // typeTwo
            // 
            this.typeTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeTwo.FormattingEnabled = true;
            this.typeTwo.Items.AddRange(new object[] {
            "Blank",
            "Bug",
            "Dark",
            "Dragon",
            "Electric",
            "Fighting",
            "Fire",
            "Flying",
            "Ghost",
            "Grass",
            "Ground",
            "Ice",
            "Normal",
            "Poison",
            "Psychic",
            "Rock",
            "Steel",
            "Water"});
            this.typeTwo.Location = new System.Drawing.Point(389, 115);
            this.typeTwo.Name = "typeTwo";
            this.typeTwo.Size = new System.Drawing.Size(121, 21);
            this.typeTwo.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(312, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Primary Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Secondary Type:";
            // 
            // expTypeBox
            // 
            this.expTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expTypeBox.FormattingEnabled = true;
            this.expTypeBox.Items.AddRange(new object[] {
            "Erratic - 600,000",
            "Fast - 800,000",
            "MedSlow - 1,059,860",
            "MedFast - 1,000,000",
            "Slow - 1,250,000",
            "Fluctuating - 1,640,000"});
            this.expTypeBox.Location = new System.Drawing.Point(389, 142);
            this.expTypeBox.Name = "expTypeBox";
            this.expTypeBox.Size = new System.Drawing.Size(121, 21);
            this.expTypeBox.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Experience Type:";
            // 
            // pdexEntry
            // 
            this.pdexEntry.Location = new System.Drawing.Point(389, 210);
            this.pdexEntry.Multiline = true;
            this.pdexEntry.Name = "pdexEntry";
            this.pdexEntry.Size = new System.Drawing.Size(160, 84);
            this.pdexEntry.TabIndex = 12;
            this.pdexEntry.Text = "Enter PokeDex Entry";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Pokedex Entry:";
            // 
            // PDexNumber
            // 
            this.PDexNumber.Location = new System.Drawing.Point(389, 184);
            this.PDexNumber.Name = "PDexNumber";
            this.PDexNumber.Size = new System.Drawing.Size(100, 20);
            this.PDexNumber.TabIndex = 11;
            this.PDexNumber.Text = "PokeDex Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(293, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Pokedex Number:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPokemonListToolStripMenuItem,
            this.savePokemonListToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPokemonListToolStripMenuItem
            // 
            this.openPokemonListToolStripMenuItem.Name = "openPokemonListToolStripMenuItem";
            this.openPokemonListToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openPokemonListToolStripMenuItem.Text = "Open PokemonList";
            this.openPokemonListToolStripMenuItem.Click += new System.EventHandler(this.openPokemonListToolStripMenuItem_Click);
            // 
            // savePokemonListToolStripMenuItem
            // 
            this.savePokemonListToolStripMenuItem.Name = "savePokemonListToolStripMenuItem";
            this.savePokemonListToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.savePokemonListToolStripMenuItem.Text = "Save PokemonList";
            this.savePokemonListToolStripMenuItem.Click += new System.EventHandler(this.savePokemonListToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pkmn";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pkmn";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // addPokemonButton
            // 
            this.addPokemonButton.Location = new System.Drawing.Point(62, 357);
            this.addPokemonButton.Name = "addPokemonButton";
            this.addPokemonButton.Size = new System.Drawing.Size(75, 23);
            this.addPokemonButton.TabIndex = 13;
            this.addPokemonButton.Text = "Add Pokemon";
            this.addPokemonButton.UseVisualStyleBackColor = true;
            this.addPokemonButton.Click += new System.EventHandler(this.addPokemonButton_Click);
            // 
            // pokeListBox
            // 
            this.pokeListBox.FormattingEnabled = true;
            this.pokeListBox.Location = new System.Drawing.Point(664, 24);
            this.pokeListBox.Name = "pokeListBox";
            this.pokeListBox.Size = new System.Drawing.Size(120, 420);
            this.pokeListBox.Sorted = true;
            this.pokeListBox.TabIndex = 28;
            // 
            // debugTest
            // 
            this.debugTest.AutoSize = true;
            this.debugTest.Location = new System.Drawing.Point(335, 386);
            this.debugTest.Name = "debugTest";
            this.debugTest.Size = new System.Drawing.Size(41, 13);
            this.debugTest.TabIndex = 29;
            this.debugTest.Text = "label14";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.debugTest);
            this.Controls.Add(this.pokeListBox);
            this.Controls.Add(this.addPokemonButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.PDexNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pdexEntry);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.expTypeBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.typeTwo);
            this.Controls.Add(this.typeOne);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baseHP);
            this.Controls.Add(this.baseSpeed);
            this.Controls.Add(this.baseSPDef);
            this.Controls.Add(this.baseSPAtk);
            this.Controls.Add(this.baseDefense);
            this.Controls.Add(this.baseAttack);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Pokemon Editor Prototype";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox baseAttack;
        private System.Windows.Forms.TextBox baseDefense;
        private System.Windows.Forms.TextBox baseSPAtk;
        private System.Windows.Forms.TextBox baseSPDef;
        private System.Windows.Forms.TextBox baseSpeed;
        private System.Windows.Forms.TextBox baseHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox typeOne;
        private System.Windows.Forms.ComboBox typeTwo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox expTypeBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox pdexEntry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PDexNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPokemonListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePokemonListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button addPokemonButton;
        private System.Windows.Forms.ListBox pokeListBox;
        private System.Windows.Forms.Label debugTest;
        private System.Windows.Forms.Button button1;
    }
}

