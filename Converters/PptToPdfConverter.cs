using FileConverterGUI.Converters;
using Spire.Presentation;
using System.IO;

public class PptToPdfConverter : IFileConverter
{
    public string Convert(string inputPath, string outputDir)
    {
        Directory.CreateDirectory(outputDir);

        string outFile = Path.Combine(outputDir,
            Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

        Presentation ppt = new Presentation();
        ppt.LoadFromFile(inputPath);
        ppt.SaveToFile(outFile, FileFormat.PDF);

        return outFile;
    }
}
