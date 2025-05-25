using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class AddRequestControl1 : UserControl
    {
        public AddRequestControl1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            parentForm.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            bool hasError = false;
            if (textBox1.Text == "Enter full name")
            {
                label8.Text = "Name is required";
                label8.Visible = true;
                hasError = true;
            }
            if (textBox2.Text == "Enter age")
            {
                label9.Text = "Age is required";
                label9.Visible = true;
                hasError = true;
            }
            if (comboBox1.Text == "Select blood type")
            {
                label10.Visible = true;
                label10.Text = "Blood type is required";
                hasError = true;
            }
            if (textBox3.Text == "Enter quantity")
            {
                label11.Visible = true;
                label11.Text = "Quantity is required";
                hasError = true;
            }
            if (textBox4.Text == "Enter phone number")
            {
                label12.Visible = true;
                label12.Text = "Phone number is required";
                hasError = true;
            }
            if (!hasError)
            {
                bool success = RequestModel.AddRequest(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, dateTimePicker1.Value, textBox4.Text);
                if (success)
                {
                    MessageBox.Show("The request has been added successfully");
                }
                else
                {
                    MessageBox.Show("An error occurred while adding");
                }
            }
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter full name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Enter full name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void TextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter age")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void TextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "Enter age";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void ComboBox1_MouseEnter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select blood type")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void ComboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.Text = "Select blood type";
                comboBox1.ForeColor = Color.Gray;
            }
        }

        private void TextBox3_MouseEnter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter quantity")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox3_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "Enter quantity";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void TextBox4_MouseEnter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter phone number")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void TextBox4_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "Enter phone number";
                textBox4.ForeColor = Color.Gray;
            }
        }
    }
}
