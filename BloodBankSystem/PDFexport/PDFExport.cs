using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace BloodBankSystem
{
    class PDFExport
    {
        public static void ExportDataGridViewToPDF(DataGridView dgv, string filePath, string userName,string titles)
        {

            Document doc = new Document(PageSize.A4, 20f, 20f, 40f, 30f);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            //  1.إضافة الشعار إذا كان موجودًا
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string logoPath = Path.Combine(projectPath, "image", "logo.jpg");
                
            if (File.Exists(logoPath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                logo.ScaleAbsolute(100f, 100f);
                logo.Alignment = Element.ALIGN_CENTER;
                doc.Add(logo);
            }
            else
            {
                Console.WriteLine("الشعار غير موجودً" + logoPath);
            }

            //2.عنوان التقرير
            Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            Paragraph title = new Paragraph(titles,fontTitle );
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // 3. معلومات المستخدم والتاريخ
            string dateText = "Date of creation " + DateTime.Now.ToString("yyyy/MM/dd");
            Paragraph meta = new Paragraph($"UserName: {userName}\n{dateText}", new Font(Font.FontFamily.HELVETICA, 12f));
            meta.Alignment = Element.ALIGN_RIGHT;
            meta.SpacingAfter = 20f;
            doc.Add(meta);

            // 4. إنشاء جدول البيانات
            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            table.WidthPercentage = 100;

            // رؤوس الأعمدة
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // بيانات الصفوف
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                    }
                }
            }

            doc.Add(table);

            doc.Close();

            MessageBox.Show("تم إنشاء تقرير المتبرعين بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



       


        
    }
}
