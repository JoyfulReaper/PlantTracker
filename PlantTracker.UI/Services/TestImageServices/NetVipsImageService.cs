//using PlantTracker.UI.Services.Interfaces;
//using NetVips;
//using Image = NetVips.Image;

//namespace PlantTracker.UI.Services;
//public  class NetVipsImageService : IImageService
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
//        using var image = Image.Thumbnail(filePath, size, height: size);
//        return image.JpegsaveBuffer();
//    }

//    public byte[] ResizeImage(int size, int quality, byte[] bytes)
//    {
//        using var image = Image.ThumbnailBuffer(bytes, size, height: size);
//        return image.JpegsaveBuffer();
//    }
//}
