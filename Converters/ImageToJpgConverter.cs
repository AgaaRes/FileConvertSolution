using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using ImageSharpImage = SixLabors.ImageSharp.Image;

namespace FileConverterGUI.Converters
{
    public class ImageToJpgConverter
    {
        public void Convert(string inputPath, string outputPath)
        {
            using Image<Rgba32> image = ImageSharpImage.Load<Rgba32>(inputPath);

            var encoder = new JpegEncoder
            {
                Quality = 90
            };

            if (!outputPath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                outputPath = Path.ChangeExtension(outputPath, ".jpg");

            image.Save(outputPath, encoder);
        }
    }
}
