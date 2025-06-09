using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class Intermediate : Form
    {
        public Intermediate()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            LoadInter();
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

        private void LoadInter()
        {
            try
            {
                if (!File.Exists(Paths.Intermediate))
                {
                    MessageBox.Show("File not found: " + Paths.Intermediate);
                    return;
                }
                richTextBox1.Text = File.ReadAllText(Paths.Intermediate);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading input file: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new InputEditor();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            var x = new Pass1();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

    }
}
