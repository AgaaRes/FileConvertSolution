using Spire.Pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class PdfToJpgConverter : IFileConverter
    {
        public string Convert(string inputPdf, string outputDir)
        {
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using PdfDocument pdf = new();
            pdf.LoadFromFile(inputPdf);

            string baseName = Path.GetFileNameWithoutExtension(inputPdf);
            string firstImage = "";

            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                using Image image = pdf.SaveAsImage(i);

                string outputPath = Path.Combine(
                    outputDir,
                    $"{baseName}_page_{i + 1}.jpg"
                );

                image.Save(outputPath, ImageFormat.Jpeg);

                if (i == 0)
                    firstImage = outputPath;
            }

            return firstImage; // giữ đúng contract của cách 1
        }
    }
}