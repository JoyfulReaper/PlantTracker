//using PlantTracker.UI.Services.Interfaces;
//using SkiaSharp;

//namespace PlantTracker.UI.Services;
//public class SkiaImageService : IImageService
//{
//    public string DecodeImage(byte[] data, string type, int? size = null, int quality = 75)
//    {
//        if (data is null || type is null)
//        {
//            return null;
//        }

//        if (size != null)
//        {
//            data = ResizeImage(size.Value, quality, data);
//        }
        
//        return $"data:image/{type};base64,{Convert.ToBase64String(data)}";
//    }

//    public string DecodeImage(string path, string type, int? size = null, int quality = 75)
//    {
//        if (string.IsNullOrWhiteSpace(path) || type is null)
//        {
//            return null;
//        }
//        var data = File.ReadAllBytes(path);

//        return DecodeImage(data, type, size);
//    }

//    public byte[] ResizeImage(int size, int quality, string filePath)
//    {
//        //https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp?view=skiasharp-2.88
//        using var input = File.OpenRead(filePath);
//        using var inputStream = new SKManagedStream(input);
//        using var original = SKBitmap.Decode(inputStream);

//        int width, height;
//        if (original.Width > original.Height)
//        {
//            width = size;
//            height = original.Height * size / original.Width;
//        }   
//        else
//        {
//            width = original.Width * size / original.Height;
//            height = size;
//        }

//        using var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);

//        using var image = SKImage.FromBitmap(resized);
//        return image.Encode(SKEncodedImageFormat.Jpeg, quality).ToArray();
//    }
    
//    public byte[] ResizeImage(int size, int quality, byte[] bytes)
//    {
//        //https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp?view=skiasharp-2.88
//        using var original = SKBitmap.Decode(bytes);

//        int width, height;
//        if (original.Width > original.Height)
//        {
//            width = size;
//            height = original.Height * size / original.Width;
//        }
//        else
//        {
//            width = original.Width * size / original.Height;
//            height = size;
//        }

//        using var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.High);

//        using var image = SKImage.FromBitmap(resized);
//        return image.Encode(SKEncodedImageFormat.Png, quality).ToArray();
//    }
//}
