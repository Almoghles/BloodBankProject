using System;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class RequestControl1 : UserControl
    {
        public RequestControl1()
        {
            InitializeComponent();
            LoadRequest();
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form_UserControl form = new Form_UserControl(new AddRequestControl1());
            form.ShowDialog();
            LoadRequest();
        }

        private void LoadRequest()
        {
            dataGridView1.DataSource = RequestModel.GetRequest();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = RequestModel.SearchRequest(textBox1.Text); ;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                LoadRequest();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string userName = LoginModel.GetUsername(); 
            string title = "Request Data Report";

            SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "تقرير_الطلبات.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PDFExport pDFExport = new PDFExport();
                    PDFExport.ExportDataGridViewToPDF(dataGridView1, sfd.FileName, userName,title);

                }
            
        }
    }
}
