using Spire.Xls;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class ExcelToPdfConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputPath)
        {
            Workbook workbook = new();
            workbook.LoadFromFile(inputPath);
            string outputFile = Path.Combine(
                outputPath,
                Path.GetFileNameWithoutExtension(inputPath) + ".pdf"
            );

            workbook.SaveToFile(outputFile, FileFormat.PDF);
            return outputFile;
        }
    }
}