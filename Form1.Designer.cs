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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            table.Controls.Add(lblTitle, 0, 0);
            table.Controls.Add(cbConvertType, 0, 1);
            table.Controls.Add(BtnChooseFile, 0, 2);
            table.Controls.Add(lblFile, 0, 3);
            table.Controls.Add(BtnConvert, 0, 5);
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
            table.Name = "table";
            table.Padding = new Padding(20);
            table.RowCount = 6;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            table.Size = new Size(420, 320);
            table.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(374, 50);
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
            cbConvertType.Location = new Point(23, 73);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(374, 25);
            cbConvertType.TabIndex = 1;
            // 
            // BtnChooseFile
            // 
            BtnChooseFile.Dock = DockStyle.Fill;
            BtnChooseFile.Font = new Font("Segoe UI", 15F);
            BtnChooseFile.Location = new Point(23, 113);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(374, 49);
            BtnChooseFile.TabIndex = 2;
            BtnChooseFile.Text = "Choose File";
            BtnChooseFile.Click += BtnChooseFile_Click;
            // 
            // lblFile
            // 
            lblFile.Dock = DockStyle.Fill;
            lblFile.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
            lblFile.Location = new Point(23, 165);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(374, 30);
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
            BtnConvert.Location = new Point(23, 248);
            BtnConvert.Name = "BtnConvert";
            BtnConvert.Size = new Size(374, 49);
            BtnConvert.TabIndex = 4;
            BtnConvert.Text = "Convert";
            BtnConvert.UseVisualStyleBackColor = false;
            BtnConvert.Click += BtnConvert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 320);
            Controls.Add(table);
            MinimumSize = new Size(420, 320);
            Name = "Form1";
            Text = "File Converter";
            table.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
