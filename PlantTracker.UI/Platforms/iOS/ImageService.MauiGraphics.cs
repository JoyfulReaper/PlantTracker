using PlantTracker.UI.Services.Interfaces;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

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
        using var inputStream = File.OpenRead(filePath);
        IImage image = PlatformImage.FromStream(inputStream);
        using var
            resized = image.Downsize(size, true);

        var outputStream = new MemoryStream();
        resized.Save(outputStream);

        return outputStream.ToArray();
    }

    public byte[] ResizeImage(int size, int quality, byte[] bytes)
    {
        using var inputStream = new MemoryStream(bytes);
        IImage image = PlatformImage.FromStream(inputStream);
        using var resized = image.Downsize(size, true);

        var outputStream = new MemoryStream();
        resized.Save(outputStream);

        return outputStream.ToArray();
    }
}
