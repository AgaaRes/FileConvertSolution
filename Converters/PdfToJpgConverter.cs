using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class PdfToJpgConverter : IFileConverter
    {
        public string Convert(string pdfPath, string outputFolder)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            using PdfDocument doc = PdfDocument.Load(pdfPath);

            for (int i = 0; i < doc.PageCount; i++)
            {
                using Image img = doc.Render(i, 200, 200, true);

                string outputFile = Path.Combine(
                    outputFolder,
                    $"page_{i + 1}.jpg"
                );

                img.Save(outputFile, ImageFormat.Jpeg);
            }

            // TRẢ VỀ thư mục chứa kết quả
            return outputFolder;
        }
    }
}
