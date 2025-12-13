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
            label1 = new Label();
            SuspendLayout();
            // 
            // cbConvertType
            // 
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Items.AddRange(new object[] { "DOCX → PDF", "PDF → DOCX", "TXT → PDF" });
            cbConvertType.Location = new Point(135, 6);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(200, 28);
            cbConvertType.TabIndex = 0;
            // 
            // BtnChooseFile
            // 
            BtnChooseFile.Location = new Point(317, 93);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(258, 57);
            BtnChooseFile.TabIndex = 1;
            BtnChooseFile.Text = "Chọn file";
            BtnChooseFile.Click += BtnChooseFile_Click;
            // 
            // BtnConvert
            // 
            BtnConvert.Location = new Point(317, 227);
            BtnConvert.Name = "BtnConvert";
            BtnConvert.Size = new Size(258, 57);
            BtnConvert.TabIndex = 3;
            BtnConvert.Text = "Convert";
            BtnConvert.Click += BtnConvert_Click;
            // 
            // lblFile
            // 
            lblFile.Font = new Font("Segoe UI", 12F);
            lblFile.Location = new Point(373, 170);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(142, 38);
            lblFile.TabIndex = 2;
            lblFile.Text = "Chưa chọn file";
            // 
            // label1
            // 
            label1.Location = new Point(-1, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 33);
            label1.TabIndex = 4;
            label1.Text = "Chọn loại Convert:";
            // 
            // Form1
            // 
            ClientSize = new Size(894, 403);
            Controls.Add(label1);
            Controls.Add(cbConvertType);
            Controls.Add(BtnChooseFile);
            Controls.Add(lblFile);
            Controls.Add(BtnConvert);
            Name = "Form1";
            Text = "File Converter";
            ResumeLayout(false);
        }
        private Label label1;
    }
}
