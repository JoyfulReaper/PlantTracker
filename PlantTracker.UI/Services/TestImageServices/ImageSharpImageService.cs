//using PlantTracker.UI.Services.Interfaces;
//using SixLabors.ImageSharp;
//using SixLabors.ImageSharp.Formats.Jpeg;
//using SixLabors.ImageSharp.Processing;
//using Image = SixLabors.ImageSharp.Image;

//namespace PlantTracker.UI.Services;
//public class ImageSharpImageService : IImageService
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
//        using Image image = Image.Load(filePath);
//        image.Mutate(x =>
//            x.Resize(size, size, KnownResamplers.Lanczos3));

//        var outStream = new MemoryStream();
//        image.Save(outStream, new JpegEncoder());

//        return outStream.ToArray();
//    }


//    public byte[] ResizeImage(int size, int quality, byte[] bytes)
//    {
//        try
//        {
//            using Image image = Image.Load(bytes);
//            image.Mutate(x =>
//                x.Resize(size, size, KnownResamplers.Lanczos3));

//            var outStream = new MemoryStream();
//            image.Save(outStream, new JpegEncoder());

//            return outStream.ToArray();
//        }catch (Exception e)
//        {
//            var t = e.Message;
//        }
//        return null;
//    }
//}
