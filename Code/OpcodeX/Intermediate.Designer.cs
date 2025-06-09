namespace OpcodeX
{
    partial class Intermediate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Intermediate));
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            Run = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.power_64;
            pictureBox1.Location = new Point(750, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Consolas", 10F);
            richTextBox1.ForeColor = Color.FromArgb(200, 200, 200);
            richTextBox1.Location = new Point(114, 135);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(570, 241);
            richTextBox1.TabIndex = 20;
            richTextBox1.Text = "";
            // 
            // Run
            // 
            Run.BackColor = Color.Black;
            Run.BackgroundImageLayout = ImageLayout.Center;
            Run.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Run.ForeColor = Color.Cornsilk;
            Run.Location = new Point(268, 411);
            Run.Name = "Run";
            Run.Size = new Size(255, 50);
            Run.TabIndex = 22;
            Run.Text = "Run Pass 1";
            Run.UseVisualStyleBackColor = false;
            Run.Click += Run_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.Back;
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // Intermediate
            // 
            AutoScaleDimensions = new SizeF(20F, 43F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.Inter;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(794, 525);
            Controls.Add(pictureBox3);
            Controls.Add(Run);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Blue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8, 6, 8, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Intermediate";
            Text = "OpcodeX";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Button Run;
        private PictureBox pictureBox3;
    }
}
