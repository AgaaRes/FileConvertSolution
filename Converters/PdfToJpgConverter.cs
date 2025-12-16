using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class PdfToJpgConverter : IFileConverter
    {
        public string Convert(string pdfPath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            using PdfDocument doc = PdfDocument.Load(pdfPath);

            string firstImage = "";

            for (int i = 0; i < doc.PageCount; i++)
            {
                using Image img = doc.Render(i, 200, 200, true);

                string outputFile = Path.Combine(
                    outputDir,
                    $"page_{i + 1}.jpg"
                );

                img.Save(outputFile, ImageFormat.Jpeg);

                if (i == 0)
                    firstImage = outputFile;
            }

            return firstImage;
        }
    }
}