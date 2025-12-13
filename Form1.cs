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
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All supported files|*.docx;*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                lblFile.Text = Path.GetFileName(selectedFile);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("Vui lòng chọn file trước.");
                return;
            }

            string outputDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ConvertedFiles"
            );

            Directory.CreateDirectory(outputDir);

            string outputFile = Path.Combine(
                outputDir,
                Path.GetFileNameWithoutExtension(selectedFile) + ".pdf"
            );

            try
            {
                switch (cbConvertType.SelectedItem!.ToString())
                {
                    case "DOCX → PDF":
                        ConvertDocxToPdf(selectedFile, outputFile);
                        break;

                    case "TXT → PDF":
                        ConvertTxtToPdf(selectedFile, outputFile);
                        break;
                }

                MessageBox.Show($"Convert thành công!\n{outputFile}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ConvertDocxToPdf(string input, string output)
        {
            var doc = new Spire.Doc.Document();
            doc.LoadFromFile(input);
            doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
        }

        private void ConvertTxtToPdf(string input, string output)
        {
            string text = File.ReadAllText(input);

            var doc = new Spire.Doc.Document();
            var section = doc.AddSection();
            section.AddParagraph().AppendText(text);

            doc.SaveToFile(output, Spire.Doc.FileFormat.PDF);
        }
    }
}
