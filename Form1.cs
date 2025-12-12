using System;
using System.IO;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
                "Word Files (*.docx)|*.docx|Text Files (*.txt)|*.txt|Image Files (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ConvertFile(dialog.FileName);
            }
        }

        private void ConvertFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();

            // Tự tạo thư mục output trong Documents
            string outputFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ConvertedFiles"
            );

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string outputFile = Path.Combine(
                outputFolder,
                Path.GetFileNameWithoutExtension(filePath) + ".pdf"
            );

            try
            {
                switch (ext)
                {
                    case ".docx":
                        ConvertDocxToPdf(filePath, outputFile);
                        break;

                    case ".txt":
                        ConvertTxtToPdf(filePath, outputFile);
                        break;

                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        ConvertImageToPdf(filePath, outputFile);
                        break;

                    default:
                        MessageBox.Show("Loại file không hỗ trợ.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void ConvertDocxToPdf(string filePath, string outFile)
        {
            var doc = new Spire.Doc.Document();
            doc.LoadFromFile(filePath);
            doc.SaveToFile(outFile, Spire.Doc.FileFormat.PDF);
            MessageBox.Show($"Đã tạo PDF tại:\n{outFile}");
        }

        private void ConvertTxtToPdf(string filePath, string outFile)
        {
            string text = File.ReadAllText(filePath);

            var doc = new Spire.Doc.Document();
            var section = doc.AddSection();
            section.AddParagraph().AppendText(text);

            doc.SaveToFile(outFile, Spire.Doc.FileFormat.PDF);
            MessageBox.Show($"Đã tạo PDF tại:\n{outFile}");
        }

        private void ConvertImageToPdf(string filePath, string outFile)
        {
            var pdf = new Spire.Pdf.PdfDocument();
            var page = pdf.Pages.Add();

            var img = Spire.Pdf.Graphics.PdfImage.FromFile(filePath);
            page.Canvas.DrawImage(img, 0, 0, img.Width, img.Height);

            pdf.SaveToFile(outFile);
            MessageBox.Show($"Đã tạo PDF tại:\n{outFile}");
        }
    }
}
