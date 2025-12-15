using System.IO;
using Spire.Pdf;

namespace FileConverterGUI.Converters
{
    public class PdfToDocxConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            string outputFile = Path.Combine(outputDir,
                Path.GetFileNameWithoutExtension(inputPath) + ".docx");

            PdfDocument pdf = new();
            pdf.LoadFromFile(inputPath);
            pdf.SaveToFile(outputFile, Spire.Pdf.FileFormat.DOCX);

            return outputFile;
        }
    }
}
