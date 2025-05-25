using System;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class Form_UserControl : Form
    {
        public Form_UserControl(UserControl uc)
        {
            InitializeComponent();
            this.Size = uc.Size;
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void Form_UserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
