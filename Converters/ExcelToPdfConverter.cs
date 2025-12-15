using Spire.Xls;

namespace FileConverterGUI.Converters
{
    public class ExcelToPdfConverter
    {
        public void Convert(string inputPath, string outputPath)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(inputPath);

            workbook.SaveToFile(outputPath, FileFormat.PDF);
        }
    }
}
