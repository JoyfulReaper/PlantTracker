using PlantTracker.UI.Services.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Image = System.Drawing.Image;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace PlantTracker.UI.Platforms;

public partial class ImageService : IImageService
{
    public string DecodeImage(byte[] data, string type, int? size = null, int quality = 75)
    {
        if (data is null || type is null)
        {
            return null;
        }

        if (size != null)
        {
            data = ResizeImage(size.Value, quality, data);
        }

        return $"data:image/{type};base64,{Convert.ToBase64String(data)}";
    }

    public string DecodeImage(string path, string type, int? size = null, int quality = 75)
    {
        if (string.IsNullOrWhiteSpace(path) || type is null)
        {
            return null;
        }
        var data = File.ReadAllBytes(path);

        return DecodeImage(data, type, size);
    }

    public byte[] ResizeImage(int size, int quality, string filePath)
    {
        Image image = Image.FromFile(filePath);
        var resized = ResizeImage(image, size, size);

        using var outputStream = new MemoryStream();
        resized.Save(outputStream, ImageFormat.Jpeg);
        return outputStream.ToArray();
    }

    public byte[] ResizeImage(int size, int quality, byte[] bytes)
    {
        using var inputStream = new MemoryStream(bytes);
        Image image = Image.FromStream(inputStream);
        var resized = ResizeImage(image, size, size);
        inputStream?.Dispose();

        using var outputStream = new MemoryStream();
        resized.Save(outputStream, ImageFormat.Jpeg);
        return outputStream.ToArray();
    }

    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    private Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}
