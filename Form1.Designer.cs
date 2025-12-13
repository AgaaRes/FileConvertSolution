using System.Drawing;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    partial class Form1
    {
        private ComboBox cbConvertType;
        private Button btnChooseFile;
        private Button btnConvert;
        private Label lblFile;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbConvertType = new ComboBox();
            btnChooseFile = new Button();
            btnConvert = new Button();
            lblFile = new Label();

            SuspendLayout();

            // ComboBox
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Items.AddRange(new object[]
            {
                "DOCX → PDF",
                "TXT → PDF"
            });
            cbConvertType.SelectedIndex = 0;
            cbConvertType.Location = new Point(30, 30);
            cbConvertType.Size = new Size(200, 30);

            // Button Choose File
            btnChooseFile.Text = "Chọn file";
            btnChooseFile.Location = new Point(30, 80);
            btnChooseFile.Size = new Size(200, 40);
            btnChooseFile.Click += btnChooseFile_Click;

            // Label
            lblFile.Text = "Chưa chọn file";
            lblFile.AutoSize = true;
            lblFile.Location = new Point(30, 140);

            // Button Convert
            btnConvert.Text = "Convert";
            btnConvert.Location = new Point(30, 180);
            btnConvert.Size = new Size(200, 40);
            btnConvert.Click += btnConvert_Click;

            // Form
            ClientSize = new Size(300, 260);
            Controls.Add(cbConvertType);
            Controls.Add(btnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(btnConvert);
            Text = "File Converter";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
