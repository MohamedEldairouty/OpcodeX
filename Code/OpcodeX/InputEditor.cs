using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class InputEditor : Form
    {
        public InputEditor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            LoadInput();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string currentText = richTextBox1.Text.Replace("\r\n", "\n").Trim();
                string fileText = File.ReadAllText(Paths.InputFile).Replace("\r\n", "\n").Trim();

                if (currentText != fileText)
                {
                    LoadInput();
                    MessageBox.Show("Input file has been updated successfully.");
                }
                else
                {
                    MessageBox.Show("Input file is up to date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading input file: " + ex.Message);
            }
        }
        private void LoadInput()
        {
            try
            {
                if (!File.Exists(Paths.InputFile))
                {
                    MessageBox.Show("File not found: " + Paths.InputFile);
                    return;
                }
                richTextBox1.Text = File.ReadAllText(Paths.InputFile);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading input file: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", Paths.InputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file in Notepad: " + ex.Message);
            }
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            try
            {
                var pass1 = new SICAssembler.Core.Pass1();
                pass1.Run(Paths.InputFile);
                var pass2 = new SICAssembler.Core.Pass2();
                pass2.Run();

                var x = new Intermediate();
                x.StartPosition = FormStartPosition.Manual;
                x.Location = this.Location;
                x.Show();
                Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Run Pass 1: " + ex.Message);  
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new HomePage();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }
    }
}
