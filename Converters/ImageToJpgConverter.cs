using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using ImageSharpImage = SixLabors.ImageSharp.Image;

namespace FileConverterGUI.Converters
{
    public class ImageToJpgConverter : IFileConverter
    {
        public string Convert(string inputPath, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            string outputFile = Path.Combine(outputDir,
                Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

            using Image<Rgba32> image = ImageSharpImage.Load<Rgba32>(inputPath);

            var encoder = new JpegEncoder { Quality = 90 };
            image.Save(outputFile, encoder);

            return outputFile; // trả về đường dẫn file đã convert
        }
    }
}