using System.Drawing;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    partial class Form1
    {
        private ComboBox cbConvertType;
        private Button BtnChooseFile;
        private Button BtnConvert;
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
            BtnChooseFile = new Button();
            BtnConvert = new Button();
            lblFile = new Label();
            SuspendLayout();
             
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Items.AddRange(new object[] { ".DOCX -> .PDF", ".TXT -> .PDF", ".JPEG / .JFIF -> .JPG", ".PPT -> .PDF", ".PDF -> .DOCX" });
            cbConvertType.Location = new Point(40, 22);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(200, 28);
            cbConvertType.TabIndex = 0;
            
            BtnChooseFile.Location = new Point(12, 69);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(258, 57);
            BtnChooseFile.TabIndex = 1;
            BtnChooseFile.Text = "Chọn file";
            BtnChooseFile.Click += BtnChooseFile_Click;
             
            BtnConvert.Location = new Point(40, 180);
            BtnConvert.Name = "BtnConvert";
            BtnConvert.Size = new Size(200, 40);
            BtnConvert.TabIndex = 3;
            BtnConvert.Text = "Convert";
            BtnConvert.Click += BtnConvert_Click;
            
            lblFile.AutoSize = true;
            lblFile.Location = new Point(98, 129);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(104, 20);
            lblFile.TabIndex = 2;
            lblFile.Text = "Chưa chọn file";
            
            ClientSize = new Size(300, 260);
            Controls.Add(cbConvertType);
            Controls.Add(BtnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(BtnConvert);
            Name = "Form1";
            Text = "File Converter";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
