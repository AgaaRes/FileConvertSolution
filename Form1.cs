using System;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;

namespace FileConverterGUI.Converters
{
    public partial class Form1 : Form
    {
        private string? selectedFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            dialog.Filter = "All supported files|*.docx;*.txt;*.pdf";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                lblFile.Text = Path.GetFileName(selectedFile);
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("Vui lòng chọn file trước.");
                return;
            }
            if (!File.Exists(selectedFile))
            {
                MessageBox.Show("File không tồn tại.");
                return;
            }
            string outputDir;
            using (FolderBrowserDialog folderDialog = new ())
            {
                folderDialog.Description = "Chọn thư mục lưu file chuyển đổi";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    outputDir = folderDialog.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu file.");
                    return;
                }
            }
            if (cbConvertType.SelectedItem is not string convertType || string.IsNullOrEmpty(convertType))
            {
                MessageBox.Show("Vui lòng chọn loại chuyển đổi.");
                return;
            }

            string outputFile = convertType switch
            {
                "DOCX → PDF" => Path.Combine(outputDir, Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"),
                "TXT → PDF" => Path.Combine(outputDir, Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"),
                "PDF → DOCX" => Path.Combine(outputDir, Path.GetFileNameWithoutExtension(selectedFile) + ".docx"),
                _ => throw new InvalidOperationException("Loại convert không hợp lệ")
            };
            try
            {
                switch (convertType)
                {
                    case "DOCX → PDF":
                        ConvertDocxToPdf(selectedFile, outputFile);
                        break;
                    case "PDF → DOCX":
                         ConvertPdfToDocx(selectedFile, outputFile);
                        break;
                    case "TXT → PDF":
                        ConvertTxtToPdf(selectedFile, outputFile);
                        break;
                    default:
                        MessageBox.Show("Loại Chuyển đổi không hợp lệ.");
                        return;
                }
                MessageBox.Show($"Convert thành công!\n{outputFile}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private static void ConvertDocxToPdf(string input, string output)
        {
            try
            {
                var doc = new Spire.Doc.Document();
                doc.LoadFromFile(input);
                doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi convert DOCX → PDF: " + ex.Message);
            }        
        }

        private static void ConvertTxtToPdf(string input, string output)
        {
            try
            {
                string text = File.ReadAllText(input);
                var doc = new Spire.Doc.Document();
                var section = doc.AddSection();
                section.AddParagraph().AppendText(text);
                doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi convert TXT → PDF: " + ex.Message);
            }
            
        }
        private static void ConvertPdfToDocx(string input, string output)
        {
            try
            {
                // Load PDF
                PdfDocument pdf = new();
                pdf.LoadFromFile(input);

                // Lưu sang DOCX
                pdf.SaveToFile(output, FileFormat.DOCX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi convert PDF → DOCX: " + ex.Message);
            }
        }
    }
}
