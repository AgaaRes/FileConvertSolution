namespace FileConverterGUI.Converters
{
    public interface IFileConverter
    {
       string Convert(string inputPath, string outputPath);
    }
}
