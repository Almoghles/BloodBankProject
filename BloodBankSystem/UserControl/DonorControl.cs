using System;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace BloodBankSystem
{
    public partial class DonorControl : UserControl
    {
      //  private Timer timer = new Timer();
        public DonorControl()
        {
            InitializeComponent();
             LoadDonor();
          //  AddButton();0uiopo'

           
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Form_UserControl form = new Form_UserControl(new AddDonorControl1());
            form.ShowDialog();
            LoadDonor();
        }


        private void LoadDonor()
        {
            dataGridView1.DataSource = DonorModel.GetDonor();
           
        }


        private void Button1_Click(object sender, EventArgs e)
         {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = DonorModel.SearchDonor(textBox1.Text);
            }
         }
       

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                LoadDonor();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            string userName = LoginModel.GetUsername();
           
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "تقرير_المتبرعين.pdf";
                string title = "Donor Data Report";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PDFExport.ExportDataGridViewToPDF(dataGridView1, sfd.FileName, userName,title);

                }
           
        }

    }
}
