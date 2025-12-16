using System.Drawing;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    partial class Form1
    {
        private TableLayoutPanel table;
        private Label lblTitle;
        private ComboBox cbConvertType;
        private Button BtnChooseFile;
        private Label lblFile;
        private Button BtnConvert;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            table = new TableLayoutPanel();
            lblTitle = new Label();
            cbConvertType = new ComboBox();
            BtnChooseFile = new Button();
            lblFile = new Label();
            BtnConvert = new Button();
            table.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 1;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            table.Controls.Add(lblTitle, 0, 0);
            table.Controls.Add(cbConvertType, 0, 1);
            table.Controls.Add(BtnChooseFile, 0, 2);
            table.Controls.Add(lblFile, 0, 3);
            table.Controls.Add(BtnConvert, 0, 5);
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(3, 4, 3, 4);
            table.Name = "table";
            table.Padding = new Padding(23, 27, 23, 27);
            table.RowCount = 6;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
            table.Size = new Size(480, 427);
            table.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(26, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(428, 67);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "File Converter";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbConvertType
            // 
            cbConvertType.Dock = DockStyle.Fill;
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Font = new Font("Segoe UI", 10F);
            cbConvertType.Items.AddRange(new object[] { "IMAGE → JPG", "DOCX → PDF", "TXT → PDF", "PDF → DOCX", "PPT → PDF", "PDF → JPG", "EXCEL → PDF" });
            cbConvertType.Location = new Point(26, 98);
            cbConvertType.Margin = new Padding(3, 4, 3, 4);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(428, 31);
            cbConvertType.TabIndex = 1;
            // 
            // BtnChooseFile
            // 
            BtnChooseFile.Dock = DockStyle.Fill;
            BtnChooseFile.Font = new Font("Segoe UI", 15F);
            BtnChooseFile.Location = new Point(26, 151);
            BtnChooseFile.Margin = new Padding(3, 4, 3, 4);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(428, 65);
            BtnChooseFile.TabIndex = 2;
            BtnChooseFile.Text = "Choose File";
            BtnChooseFile.Click += BtnChooseFile_Click;
            // 
            // lblFile
            // 
            lblFile.Dock = DockStyle.Fill;
            lblFile.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            lblFile.Location = new Point(26, 220);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(428, 40);
            lblFile.TabIndex = 3;
            lblFile.Text = "No file selected";
            lblFile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnConvert
            // 
            BtnConvert.BackColor = Color.FromArgb(0, 120, 215);
            BtnConvert.Dock = DockStyle.Fill;
            BtnConvert.FlatAppearance.BorderSize = 0;
            BtnConvert.FlatStyle = FlatStyle.Flat;
            BtnConvert.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            BtnConvert.ForeColor = Color.White;
            BtnConvert.Location = new Point(26, 331);
            BtnConvert.Margin = new Padding(3, 4, 3, 4);
            BtnConvert.Name = "BtnConvert";
            BtnConvert.Size = new Size(428, 65);
            BtnConvert.TabIndex = 4;
            BtnConvert.Text = "Convert";
            BtnConvert.UseVisualStyleBackColor = false;
            BtnConvert.Click += BtnConvert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnConvert;
            ClientSize = new Size(480, 427);
            Controls.Add(table);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(477, 411);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Converter";
            table.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
