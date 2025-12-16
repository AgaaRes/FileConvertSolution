using Spire.Presentation;
using System.IO;

namespace FileConverterGUI.Converters
{
    public class PptToPdfConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            string outFile = Path.Combine(
                outputDir,
                Path.GetFileNameWithoutExtension(inputPath) + ".pdf"
            );

            Presentation ppt = new();
            ppt.LoadFromFile(inputPath);
            ppt.SaveToFile(outFile, FileFormat.PDF);

            return outFile;
        }
    }
}