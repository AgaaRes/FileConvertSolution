using Spire.Xls;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class WordToPdfConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            string outputFile = Path.Combine(
                outputDir,
                Path.GetFileNameWithoutExtension(inputPath) + ".pdf"
            );

            Workbook wb = new();
            wb.LoadFromFile(inputPath);
            wb.SaveToFile(outputFile, FileFormat.PDF);

            return outputFile;
        }
    }
}