using FileConverterGUI.Converters;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;

public class TextToPdfConverter : IFileConverter
{
    public string Convert(string inputPath, string outputDir)
    {
        if (!File.Exists(inputPath))
            throw new FileNotFoundException("Input file not found.", inputPath);

        Directory.CreateDirectory(outputDir);

        string fileName = Path.GetFileNameWithoutExtension(inputPath);
        string outputFile = Path.Combine(outputDir, fileName + ".pdf");

        // Dùng fully-qualified name để tránh đụng PDFSharp
        using (var writer = new iText.Kernel.Pdf.PdfWriter(outputFile))
        using (var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer))
        using (var document = new Document(pdfDoc))
        {
            string text = File.ReadAllText(inputPath);
            document.Add(new Paragraph(text));
        }

        return outputFile;
    }
}
