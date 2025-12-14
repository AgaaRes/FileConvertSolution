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
            // 
            // cbConvertType
            // 
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Items.AddRange(new object[] { ".DOCX -> .PDF", ".TXT -> .PDF", "JPEG / JFIF -> JPG" });
            cbConvertType.Location = new Point(40, 22);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(200, 23);
            cbConvertType.TabIndex = 0;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(12, 69);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(258, 57);
            btnChooseFile.TabIndex = 1;
            btnChooseFile.Text = "Chọn file";
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(40, 180);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(200, 40);
            btnConvert.TabIndex = 3;
            btnConvert.Text = "Convert";
            btnConvert.Click += btnConvert_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(98, 129);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(84, 15);
            lblFile.TabIndex = 2;
            lblFile.Text = "Chưa chọn file";
            // 
            // Form1
            // 
            ClientSize = new Size(300, 260);
            Controls.Add(cbConvertType);
            Controls.Add(btnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(btnConvert);
            Name = "Form1";
            Text = "File Converter";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
