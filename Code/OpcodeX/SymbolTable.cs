using SICAssembler.Core;
using System.Text;

namespace OpcodeX
{
    public partial class SymbolTable : Form
    {
        public SymbolTable()
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
                if (!File.Exists(Paths.symbTable))
                {
                    MessageBox.Show("File not found: " + Paths.symbTable);
                    return;
                }
                richTextBox1.Text = File.ReadAllText(Paths.symbTable);

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
