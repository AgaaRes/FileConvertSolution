using System.Drawing;
using System.Windows.Forms;

namespace FileConverterGUI.Converters
{
    partial class Form1
    {
        private Button btnSelectFile;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectFile = new Button();
            this.SuspendLayout();
            //
            // btnSelectFile
            //
            this.btnSelectFile.Location = new Point(30, 30);
            this.btnSelectFile.Size = new Size(200, 50);
            this.btnSelectFile.Text = "Chọn file để chuyển đổi";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            //
            // Form1
            //
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "Form1";
            this.Text = "File Converter";
            this.ResumeLayout(false);
        }
    }
}
