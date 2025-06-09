namespace OpcodeX
{
    partial class Pass2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pass2));
            pictureBox1 = new PictureBox();
            OBJ = new Button();
            pictureBox3 = new PictureBox();
            HTME = new Button();
            END = new Button();
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
            // OBJ
            // 
            OBJ.BackColor = Color.Transparent;
            OBJ.BackgroundImageLayout = ImageLayout.Stretch;
            OBJ.FlatAppearance.BorderSize = 0;
            OBJ.FlatAppearance.MouseDownBackColor = Color.Transparent;
            OBJ.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OBJ.FlatStyle = FlatStyle.Flat;
            OBJ.Location = new Point(52, 281);
            OBJ.Name = "OBJ";
            OBJ.Size = new Size(171, 124);
            OBJ.TabIndex = 26;
            OBJ.UseVisualStyleBackColor = false;
            OBJ.Click += OBJ_Click;
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
            // HTME
            // 
            HTME.BackColor = Color.Transparent;
            HTME.BackgroundImageLayout = ImageLayout.Stretch;
            HTME.FlatAppearance.BorderSize = 0;
            HTME.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HTME.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HTME.FlatStyle = FlatStyle.Flat;
            HTME.Location = new Point(241, 281);
            HTME.Name = "HTME";
            HTME.Size = new Size(163, 124);
            HTME.TabIndex = 27;
            HTME.UseVisualStyleBackColor = false;
            HTME.Click += HTME_Click;
            // 
            // END
            // 
            END.BackColor = Color.Transparent;
            END.BackgroundImageLayout = ImageLayout.Stretch;
            END.FlatAppearance.BorderSize = 0;
            END.FlatAppearance.MouseDownBackColor = Color.Transparent;
            END.FlatAppearance.MouseOverBackColor = Color.Transparent;
            END.FlatStyle = FlatStyle.Flat;
            END.Location = new Point(425, 281);
            END.Name = "END";
            END.Size = new Size(163, 124);
            END.TabIndex = 28;
            END.UseVisualStyleBackColor = false;
            END.Click += END_Click;
            // 
            // Pass2
            // 
            AutoScaleDimensions = new SizeF(20F, 43F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.Passs2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(642, 525);
            Controls.Add(END);
            Controls.Add(HTME);
            Controls.Add(pictureBox3);
            Controls.Add(OBJ);
            Controls.Add(pictureBox1);
            Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Blue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8, 6, 8, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Pass2";
            Text = "OpcodeX";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button OBJ;
        private PictureBox pictureBox3;
        private Button HTME;
        private Button pass2;
        private Button END;
    }
}
