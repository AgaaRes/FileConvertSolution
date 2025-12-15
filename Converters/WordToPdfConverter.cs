using FileConverterGUI.Converters;
using Spire.Xls;

namespace FileConverterGUI.Converters
{
    public class WordToPdfConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputPath)
        {
            Workbook wb = new();
            wb.LoadFromFile(inputPath);
            wb.SaveToFile(outputPath, Spire.Xls.FileFormat.PDF);

            return outputPath;
        }
    }
}
