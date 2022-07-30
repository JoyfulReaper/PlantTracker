using PlantTracker.UI.Services.Interfaces;
using SkiaSharp;

namespace PlantTracker.UI.Services;
public class ImageService : IImageService
{
    public string DecodeImage(byte[] data, string type)
    {
        if (data is null || type is null)
        {
            return null;
        }

        return $"data:image/{type};base64,{Convert.ToBase64String(data)}";
    }

    public byte[] ResizeImage(int size, int quality, string filePath)
    {
        //https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp?view=skiasharp-2.88
        using var input = File.OpenRead(filePath);
        using var inputStream = new SKManagedStream(input);
        using var original = SKBitmap.Decode(inputStream);

        int width, height;
        if (original.Width > original.Height)
        {
            width = size;
            height = original.Height * size / original.Width;
        }   
        else
        {
            width = original.Width * size / original.Height;
            height = size;
        }

        using var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);

        using var image = SKImage.FromBitmap(resized);
        return image.Encode(SKEncodedImageFormat.Jpeg, quality).ToArray();
    }
    
    public byte[] ResizeImage(int size, int quality, byte[] bytes)
    {
        //https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp?view=skiasharp-2.88
        using var original = SKBitmap.Decode(bytes);

        int width, height;
        if (original.Width > original.Height)
        {
            width = size;
            height = original.Height * size / original.Width;
        }
        else
        {
            width = original.Width * size / original.Height;
            height = size;
        }

        using var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);

        using var image = SKImage.FromBitmap(resized);
        return image.Encode(SKEncodedImageFormat.Jpeg, quality).ToArray();
    }
}
