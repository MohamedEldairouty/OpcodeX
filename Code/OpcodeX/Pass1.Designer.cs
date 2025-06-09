namespace OpcodeX
{
    partial class Pass1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pass1));
            pictureBox1 = new PictureBox();
            LOCCTR = new Button();
            pictureBox3 = new PictureBox();
            SYMB = new Button();
            pass2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.power_64;
            pictureBox1.Location = new Point(598, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // LOCCTR
            // 
            LOCCTR.BackColor = Color.Transparent;
            LOCCTR.BackgroundImageLayout = ImageLayout.Stretch;
            LOCCTR.FlatAppearance.BorderSize = 0;
            LOCCTR.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LOCCTR.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LOCCTR.FlatStyle = FlatStyle.Flat;
            LOCCTR.Location = new Point(109, 170);
            LOCCTR.Name = "LOCCTR";
            LOCCTR.Size = new Size(425, 59);
            LOCCTR.TabIndex = 26;
            LOCCTR.UseVisualStyleBackColor = false;
            LOCCTR.Click += LOCCTR_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.back__1_;
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(43, 42);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // SYMB
            // 
            SYMB.BackColor = Color.Transparent;
            SYMB.BackgroundImageLayout = ImageLayout.Stretch;
            SYMB.FlatAppearance.BorderSize = 0;
            SYMB.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SYMB.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SYMB.FlatStyle = FlatStyle.Flat;
            SYMB.Location = new Point(109, 265);
            SYMB.Name = "SYMB";
            SYMB.Size = new Size(425, 59);
            SYMB.TabIndex = 27;
            SYMB.UseVisualStyleBackColor = false;
            SYMB.Click += SYMB_Click;
            // 
            // pass2
            // 
            pass2.BackColor = Color.Transparent;
            pass2.BackgroundImageLayout = ImageLayout.Stretch;
            pass2.FlatAppearance.BorderSize = 0;
            pass2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            pass2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            pass2.FlatStyle = FlatStyle.Flat;
            pass2.Location = new Point(109, 359);
            pass2.Name = "pass2";
            pass2.Size = new Size(425, 59);
            pass2.TabIndex = 28;
            pass2.UseVisualStyleBackColor = false;
            pass2.Click += pass2_Click;
            // 
            // Pass1
            // 
            AutoScaleDimensions = new SizeF(20F, 43F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.Passs1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(642, 525);
            Controls.Add(pass2);
            Controls.Add(SYMB);
            Controls.Add(pictureBox3);
            Controls.Add(LOCCTR);
            Controls.Add(pictureBox1);
            Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Blue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8, 6, 8, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Pass1";
            Text = "OpcodeX";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button LOCCTR;
        private PictureBox pictureBox3;
        private Button SYMB;
        private Button pass2;
    }
}
