using Spire.Doc;
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

            Document doc = new Document();
            doc.LoadFromFile(inputPath);
            doc.SaveToFile(outputFile, FileFormat.PDF);

            return outputFile;
        }
    }
}
