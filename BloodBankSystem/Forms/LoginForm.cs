using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label4.Visible = false;
            bool hasError = false;
            if (textBox1.Text == "")
            {
                label1.Text = "username is required";
                label1.Visible = true;
                hasError = true;
            }
            if (textBox2.Text == "")
            {
                label4.Text = "password is required";
                label4.Visible = true;
                hasError = true;
            }
             if (!hasError)
              {

                 bool success= LoginModel.checkLoginUser(textBox1.Text, textBox2.Text);
                  if (success)
                  {
                      MainForm mainForm = new MainForm();
                      mainForm.Show();

                      this.Hide();

                  }
                  else
                  {
                      MessageBox.Show(" Please check your usernamer or password", "Invalid credentials",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  }
              }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
