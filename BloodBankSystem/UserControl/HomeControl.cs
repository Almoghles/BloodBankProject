using System;
using System.Data;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class HomeControl : UserControl
    {
       

        public HomeControl()
        {
            InitializeComponent();
            LoadDashboard();
        }


        private void LoadDashboard()
        {
            totaldon.Text = HomeModel.GetDonorCount().ToString();
            totalreq.Text = HomeModel.GetRequestCount().ToString();
            totalblo.Text = HomeModel.GetActualBloodStock().ToString();

            // تحديث مخزون الدم
            DataTable bloodStock = HomeModel.GetBloodStock();
            foreach (DataRow row in bloodStock.Rows)
            {
                string bloodType = row["blood_type"].ToString();
                int stock = Convert.ToInt32(row["stock"]);

                switch (bloodType)
                {
                    case "A+":
                        label11.Text = stock.ToString();
                        break;
                    case "A-":
                        label17.Text = stock.ToString();
                        break;
                    case "B+":
                        label8.Text = stock.ToString();
                        break;
                    case "B-":
                        label14.Text = stock.ToString();
                        break;
                    case "O+":
                        label2.Text = stock.ToString();
                        break;
                    case "O-":
                        label21.Text = stock.ToString();
                        break;
                    case "AB+":
                        label5.Text = stock.ToString();
                        break;
                    case "AB-":
                        label24.Text = stock.ToString();
                        break;
                }
            }
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}