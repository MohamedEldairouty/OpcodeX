using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class Pass2 : Form
    {
        public Pass2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new Pass1();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }


        private void OBJ_Click(object sender, EventArgs e)
        {
            var x = new Out_Pass2();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

        private void HTME_Click(object sender, EventArgs e)
        {
            var x = new HTME();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }

        private void END_Click(object sender, EventArgs e)
        {
            var x = new HomePage();
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
        }
    }
}
