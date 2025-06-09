namespace OpcodeX
{
    partial class InputEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputEditor));
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            Refresh = new Button();
            Clean = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.power_64;
            pictureBox1.Location = new Point(749, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 42);
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
            richTextBox1.Location = new Point(12, 101);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(769, 314);
            richTextBox1.TabIndex = 20;
            richTextBox1.Text = "";
            // 
            // Refresh
            // 
            Refresh.BackColor = Color.Green;
            Refresh.BackgroundImageLayout = ImageLayout.Center;
            Refresh.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Refresh.ForeColor = Color.Transparent;
            Refresh.Location = new Point(132, 421);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(237, 42);
            Refresh.TabIndex = 21;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = false;
            Refresh.Click += Refresh_Click;
            // 
            // Clean
            // 
            Clean.BackColor = Color.Blue;
            Clean.BackgroundImageLayout = ImageLayout.Center;
            Clean.Font = new Font("Algerian", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Clean.ForeColor = Color.Transparent;
            Clean.Location = new Point(471, 421);
            Clean.Name = "Clean";
            Clean.Size = new Size(237, 42);
            Clean.TabIndex = 22;
            Clean.Text = "Clean Code";
            Clean.UseVisualStyleBackColor = false;
            Clean.Click += Clean_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.clipart323541;
            pictureBox2.Location = new Point(12, 59);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.back__1_;
            pictureBox3.Location = new Point(12, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(43, 42);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 24;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // InputEditor
            // 
            AutoScaleDimensions = new SizeF(20F, 43F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.Pic;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(793, 475);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(Clean);
            Controls.Add(Refresh);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Blue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8, 6, 8, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputEditor";
            Text = "OpcodeX";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Button Refresh;
        private Button Clean;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
