using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

using Spire.Doc;
using Spire.Pdf;
using Spire.Presentation;
using Spire.Xls;

namespace FileConverterGUI.Converters
{
    public partial class Form1 : Form
    {
        private string? selectedFile;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            cbConvertType.SelectedIndexChanged += CbConvertType_SelectedIndexChanged;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            cbConvertType.Items.Clear();

            cbConvertType.Items.Add("IMAGE → JPG");
            cbConvertType.Items.Add("DOCX → PDF");
            cbConvertType.Items.Add("TXT → PDF");
            cbConvertType.Items.Add("PDF → DOCX");
            cbConvertType.Items.Add("PPT → PDF");
            cbConvertType.Items.Add("PDF → JPG");
            cbConvertType.Items.Add("EXCEL → PDF");

            cbConvertType.SelectedIndex = -1;
            lblFile.Text = "Chưa chọn file";
        }

        private void CbConvertType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            selectedFile = null;
            lblFile.Text = "Chưa chọn file";
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            if (cbConvertType.SelectedItem is not string convertType)
            {
                MessageBox.Show("Vui lòng chọn loại chuyển đổi trước.");
                return;
            }

            using OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = GetDialogFilter(convertType)
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                lblFile.Text = Path.GetFileName(selectedFile);
            }
        }

        private static string GetDialogFilter(string convertType)
        {
            return convertType switch
            {
                "IMAGE → JPG" => "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp",
                "DOCX → PDF" => "Word files|*.docx",
                "TXT → PDF" => "Text files|*.txt",
                "PDF → DOCX" => "PDF files|*.pdf",
                "PPT → PDF" => "PowerPoint files|*.ppt;*.pptx",
                "PDF → JPG" => "PDF files|*.pdf",
                "EXCEL → PDF" => "Excel files|*.xls;*.xlsx",
                _ => "All files|*.*"
            };
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (cbConvertType.SelectedItem is not string convertType)
            {
                MessageBox.Show("Vui lòng chọn loại chuyển đổi.");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedFile) || !File.Exists(selectedFile))
            {
                MessageBox.Show("Vui lòng chọn file hợp lệ.");
                return;
            }

            string outputDir;
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục lưu file sau khi chuyển đổi";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu.");
                    return;
                }

                outputDir = folderDialog.SelectedPath;
            }

            string outputPath = convertType switch
            {
                "IMAGE → JPG" => Path.Combine(
                    outputDir,
                    Path.GetFileNameWithoutExtension(selectedFile) + ".jpg"
                ),

                "DOCX → PDF" or "TXT → PDF" or "PPT → PDF" or "EXCEL → PDF" => Path.Combine(
                    outputDir,
                    Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"
                ),

                "PDF → DOCX" => Path.Combine(
                    outputDir,
                    Path.GetFileNameWithoutExtension(selectedFile) + ".docx"
                ),

                "PDF → JPG" => outputDir,

                _ => throw new InvalidOperationException("Loại chuyển đổi không hợp lệ")
            };

            try
            {
                switch (convertType)
                {
                    case "IMAGE → JPG":
                        new ImageToJpgConverter().Convert(selectedFile, outputPath);
                        break;

                    case "DOCX → PDF":
                        ConvertDocxToPdf(selectedFile, outputPath);
                        break;

                    case "TXT → PDF":
                        ConvertTxtToPdf(selectedFile, outputPath);
                        break;

                    case "PDF → DOCX":
                        ConvertPdfToDocx(selectedFile, outputPath);
                        break;

                    case "PPT → PDF":
                        ConvertPptToPdf(selectedFile, outputPath);
                        break;

                    case "PDF → JPG":
                        ConvertPdfToJpg(selectedFile, outputPath);
                        break;

                    case "EXCEL → PDF":
                        ConvertExcelToPdf(selectedFile, outputPath);
                        break;
                }

                MessageBox.Show("Convert thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private static void ConvertDocxToPdf(string input, string output)
        {
            var doc = new Spire.Doc.Document();
            doc.LoadFromFile(input);
            doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
        }

        private static void ConvertTxtToPdf(string input, string output)
        {
            string text = File.ReadAllText(input);

            var doc = new Spire.Doc.Document();
            var section = doc.AddSection();
            section.AddParagraph().AppendText(text);

            doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
        }

        private static void ConvertPdfToDocx(string input, string output)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);
            pdf.SaveToFile(output, Spire.Pdf.FileFormat.DOCX);
        }

        private static void ConvertPptToPdf(string input, string output)
        {
            var presentation = new Spire.Presentation.Presentation();
            presentation.LoadFromFile(input);
            presentation.SaveToFile(output, Spire.Presentation.FileFormat.PDF);
        }

        private static void ConvertPdfToJpg(string inputPdf, string outputDir)
        {
            using PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(inputPdf);

            string baseName = Path.GetFileNameWithoutExtension(inputPdf);

            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                using Image image = pdf.SaveAsImage(i);
                string outputPath = Path.Combine(
                    outputDir,
                    $"{baseName}_page_{i + 1}.jpg"
                );

                image.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private static void ConvertExcelToPdf(string input, string output)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(input);
            workbook.SaveToFile(output, Spire.Xls.FileFormat.PDF);
        }
    }
}
