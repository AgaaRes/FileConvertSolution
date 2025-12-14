using System;
using System.IO;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    public partial class Form1 : Form
    {
        private string? selectedFile;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            cbConvertType.SelectedIndexChanged += cbConvertType_SelectedIndexChanged;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            cbConvertType.Items.Clear();
            cbConvertType.Items.Add("IMAGE → JPG");
            cbConvertType.Items.Add("DOCX → PDF");
            cbConvertType.Items.Add("TXT → PDF");
            cbConvertType.SelectedIndex = 0;

            lblFile.Text = "Chưa chọn file";
        }

        private void cbConvertType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Reset file khi đổi kiểu convert
            selectedFile = null;
            lblFile.Text = "Chưa chọn file";
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = GetDialogFilter(),
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                lblFile.Text = Path.GetFileName(selectedFile);
            }
        }

        private string GetDialogFilter()
        {
            return cbConvertType.SelectedItem!.ToString() switch
            {
                "IMAGE → JPG" => "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp",
                "DOCX → PDF" => "Word files|*.docx",
                "TXT → PDF" => "Text files|*.txt",
                _ => "All files|*.*"
            };
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedFile))
            {
                MessageBox.Show("Vui lòng chọn file trước.");
                return;
            }

            string outputDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ConvertedFiles"
            );

            Directory.CreateDirectory(outputDir);

            try
            {
                string convertType = cbConvertType.SelectedItem!.ToString()!;
                string outputPath;

                switch (convertType)
                {
                    case "IMAGE → JPG":
                        outputPath = Path.Combine(
                            outputDir,
                            Path.GetFileNameWithoutExtension(selectedFile) + ".jpg"
                        );

                        new ImageToJpgConverter()
                            .Convert(selectedFile, outputPath);
                        break;

                    case "DOCX → PDF":
                        outputPath = Path.Combine(
                            outputDir,
                            Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"
                        );

                        ConvertDocxToPdf(selectedFile, outputPath);
                        break;

                    case "TXT → PDF":
                        outputPath = Path.Combine(
                            outputDir,
                            Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"
                        );

                        ConvertTxtToPdf(selectedFile, outputPath);
                        break;

                    default:
                        MessageBox.Show("Kiểu chuyển đổi không hợp lệ.");
                        return;
                }

                MessageBox.Show("Convert thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ConvertDocxToPdf(string inputPath, string outputPath)
        {
            var doc = new Spire.Doc.Document();
            doc.LoadFromFile(inputPath);
            doc.SaveToFile(outputPath, Spire.Doc.FileFormat.PDF);
        }

        private void ConvertTxtToPdf(string inputPath, string outputPath)
        {
            string text = File.ReadAllText(inputPath);

            var doc = new Spire.Doc.Document();
            var section = doc.AddSection();
            section.AddParagraph().AppendText(text);

            doc.SaveToFile(outputPath, Spire.Doc.FileFormat.PDF);
        }
    }
}
