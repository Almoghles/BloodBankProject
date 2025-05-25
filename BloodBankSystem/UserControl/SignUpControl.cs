using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class SignUpControl : UserControl
    {
        public SignUpControl()
        {
            InitializeComponent();
            LoadUser();
        }

        private void LoadUser()
        {
            dataGridView1.DataSource = LoginModel.GetUsers();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {

                bool success = LoginModel.addUsers(textBox1.Text, textBox2.Text,textBox3.Text);
                if (success)
                {
                    MessageBox.Show("User added successfully");
                    LoadUser();
                }
                else
                {
                    MessageBox.Show(" An error occurred while adding", "Invalid adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please full all fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                dataGridView1.DataSource = LoginModel.SearchUser(textBox4.Text);
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                LoadUser();
            }
               
        }
    }
}
