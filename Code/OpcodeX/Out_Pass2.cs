using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class Out_Pass2 : Form
    {
        public Out_Pass2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            LoadPass2();
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

        private void LoadPass2()
        {
            try
            {
                if (!File.Exists(Paths.OutPass2))
                {
                    MessageBox.Show("File not found: " + Paths.OutPass2);
                    return;
                }
                richTextBox1.Text = File.ReadAllText(Paths.OutPass2);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading input file: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new Pass2();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

    }
}
