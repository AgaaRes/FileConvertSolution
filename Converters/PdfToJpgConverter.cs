using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class PdfToJpgConverter
    {
        public static void Convert(string pdfPath, string outputFolder)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            using PdfDocument doc = PdfDocument.Load(pdfPath);

            for (int i = 0; i < doc.PageCount; i++)
            {
                using Image img = doc.Render(i, 200, 200, true);
                img.Save(
                    Path.Combine(outputFolder, $"page_{i + 1}.jpg"),
                    ImageFormat.Jpeg
                );
            }
        }
    }
}