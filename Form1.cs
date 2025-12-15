using System;
using System.IO;
using System.Windows.Forms;
using FileConverterGUI.Converters;

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
            cbConvertType.Items.Add("TXT → PDF");
            cbConvertType.Items.Add("PDF → DOCX");
            cbConvertType.Items.Add("PPT → PDF");
            cbConvertType.Items.Add("WORD → PDF"); // hoặc Excel → PDF

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

            using OpenFileDialog dialog = new()
            {
                Multiselect = false,
                Filter = convertType switch
                {
                    "IMAGE → JPG" => "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp",
                    "TXT → PDF" => "Text files|*.txt",
                    "PDF → DOCX" => "PDF files|*.pdf",
                    "PPT → PDF" => "PowerPoint files|*.ppt;*.pptx",
                    "WORD → PDF" => "Word files|*.docx",
                    _ => "All files|*.*"
                }
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                lblFile.Text = Path.GetFileName(selectedFile);
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (cbConvertType.SelectedItem is not string convertType)
            {
                MessageBox.Show("Vui lòng chọn loại chuyển đổi.");
                return;
            }

            if (string.IsNullOrEmpty(selectedFile) || !File.Exists(selectedFile))
            {
                MessageBox.Show("Vui lòng chọn file hợp lệ.");
                return;
            }

            string outputDir;
            using (FolderBrowserDialog folderDialog = new())
            {
                folderDialog.Description = "Chọn thư mục lưu file chuyển đổi";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Bạn chưa chọn thư mục lưu file.");
                    return;
                }

                outputDir = folderDialog.SelectedPath;
            }

            try
            {
                IFileConverter converter = convertType switch
                {
                    "IMAGE → JPG" => new ImageToJpgConverter(),
                    "TXT → PDF" => new TextToPdfConverter(),
                    "PDF → DOCX" => new PdfToDocxConverter(),
                    "PPT → PDF" => new PptToPdfConverter(),
                    "WORD → PDF" => new WordToPdfConverter(),
                    _ => throw new InvalidOperationException("Loại convert không hợp lệ")
                };

                string outputFile = converter.Convert(selectedFile, outputDir);
                MessageBox.Show($"Convert thành công!\n{outputFile}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}