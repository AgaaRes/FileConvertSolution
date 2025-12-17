using System.Drawing;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cbConvertType;
        private Button BtnChooseFile;
        private Button BtnConvert;
        private Label lblFile;
        private Panel panelHeader;
        private Panel panelHeaderShadow;
        private Panel panelCard;
        private Panel panelShadow;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblConvertType;

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
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelHeaderShadow = new Panel();
            panelCard = new Panel();
            lblConvertType = new Label();
            panelShadow = new Panel();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // cbConvertType
            // 
            cbConvertType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbConvertType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvertType.Font = new Font("Segoe UI", 10F);
            cbConvertType.Items.AddRange(new object[] { "IMAGE → JPG", "TXT → PDF", "PDF → DOCX", "PDF → JPG", "PPT → PDF", "WORD → PDF", "EXCEL → PDF" });
            cbConvertType.Location = new Point(25, 55);
            cbConvertType.Name = "cbConvertType";
            cbConvertType.Size = new Size(660, 31);
            cbConvertType.TabIndex = 1;
            // 
            // BtnChooseFile
            // 
            BtnChooseFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnChooseFile.BackColor = Color.Silver;
            BtnChooseFile.FlatAppearance.BorderSize = 0;
            BtnChooseFile.FlatStyle = FlatStyle.Flat;
            BtnChooseFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnChooseFile.Location = new Point(230, 120);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(260, 44);
            BtnChooseFile.TabIndex = 2;
            BtnChooseFile.Text = "📂 Chọn file";
            BtnChooseFile.UseVisualStyleBackColor = false;
            BtnChooseFile.Click += BtnChooseFile_Click;
            // 
            // BtnConvert
            // 
            BtnConvert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnConvert.BackColor = Color.FromArgb(0, 192, 0);
            BtnConvert.FlatAppearance.BorderSize = 0;
            BtnConvert.FlatStyle = FlatStyle.Flat;
            BtnConvert.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnConvert.ForeColor = Color.White;
            BtnConvert.Location = new Point(210, 235);
            BtnConvert.Name = "BtnConvert";
            BtnConvert.Size = new Size(300, 52);
            BtnConvert.TabIndex = 4;
            BtnConvert.Text = "Convert";
            BtnConvert.UseVisualStyleBackColor = false;
            BtnConvert.Click += BtnConvert_Click;
            // 
            // lblFile
            // 
            lblFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFile.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblFile.ForeColor = Color.FromArgb(107, 114, 128);
            lblFile.Location = new Point(25, 175);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(660, 20);
            lblFile.TabIndex = 3;
            lblFile.Text = "Chưa chọn file";
            lblFile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(37, 99, 235);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(24, 14, 24, 14);
            panelHeader.Size = new Size(882, 80);
            panelHeader.TabIndex = 4;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(226, 232, 240);
            lblSubtitle.Location = new Point(72, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(214, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Convert your files in one click";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(70, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(216, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "File Converter";
            // 
            // panelHeaderShadow
            // 
            panelHeaderShadow.BackColor = Color.DodgerBlue;
            panelHeaderShadow.Dock = DockStyle.Top;
            panelHeaderShadow.Location = new Point(0, 80);
            panelHeaderShadow.Name = "panelHeaderShadow";
            panelHeaderShadow.Size = new Size(882, 6);
            panelHeaderShadow.TabIndex = 3;
            // 
            // panelCard
            // 
            panelCard.Anchor = AnchorStyles.Bottom;
            panelCard.BackColor = Color.WhiteSmoke;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(lblConvertType);
            panelCard.Controls.Add(cbConvertType);
            panelCard.Controls.Add(BtnChooseFile);
            panelCard.Controls.Add(lblFile);
            panelCard.Controls.Add(BtnConvert);
            panelCard.Location = new Point(90, 110);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(25);
            panelCard.Size = new Size(720, 340);
            panelCard.TabIndex = 0;
            // 
            // lblConvertType
            // 
            lblConvertType.AutoSize = true;
            lblConvertType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConvertType.Location = new Point(25, 25);
            lblConvertType.Name = "lblConvertType";
            lblConvertType.Size = new Size(114, 23);
            lblConvertType.TabIndex = 0;
            lblConvertType.Text = "Convert type";
            // 
            // panelShadow
            // 
            panelShadow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelShadow.BackColor = Color.FromArgb(220, 225, 231);
            panelShadow.Location = new Point(96, 116);
            panelShadow.Name = "panelShadow";
            panelShadow.Size = new Size(720, 340);
            panelShadow.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(882, 473);
            Controls.Add(panelCard);
            Controls.Add(panelShadow);
            Controls.Add(panelHeaderShadow);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimumSize = new Size(900, 520);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Converter";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}