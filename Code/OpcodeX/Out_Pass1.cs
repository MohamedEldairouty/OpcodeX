using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class Out_Pass1 : Form
    {
        public Out_Pass1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            LoadPass1();
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

        private void LoadPass1()
        {
            try
            {
                if (!File.Exists(Paths.OutPass1))
                {
                    MessageBox.Show("File not found: " + Paths.OutPass1);
                    return;
                }
                richTextBox1.Text = File.ReadAllText(Paths.OutPass1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading input file: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new Pass1();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

    }
}
