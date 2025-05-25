using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           // this.Visible = true;
        }


        private void LoadUserControl(UserControl userControl)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            panel2.Size = userControl.Size;
            panel1.Height = panel2.Height;
            this.Size = panel2.Size;
            this.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new HomeControl());
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DonorControl());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           LoadUserControl(new HomeControl());
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new RequestControl1());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new SignUpControl());
        }

        private void Home_MouseEnter(object sender, EventArgs e)
        {
            Home.BackColor = ColorTranslator.FromHtml("#874548");
        }

        private void Home_MouseLeave(object sender, EventArgs e)
        {
            Home.BackColor = ColorTranslator.FromHtml("#6E2832");
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#874548");
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#6E2832");
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#874548");
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#6E2832");
        }


        private void Button1_MouseEnter_1(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#874548");
        }

        private void Button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#6E2832");

        }

        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#874548");

        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#6E2832");

        }

    }
}
