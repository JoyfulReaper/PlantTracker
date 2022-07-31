//using FreeImageAPI;
//using PlantTracker.UI.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlantTracker.UI.Services;
//public class FreeImageImageService : IImageService
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
//        using var original = FreeImageBitmap.FromFile(filePath);

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
//        var resized = new FreeImageBitmap(original, width, height);
//        // JPEG_QUALITYGOOD is 75 JPEG.
//        // JPEG_BASELINE strips metadata (EXIF, etc.)
//        //resized.Save(OutputPath(path, outputDirectory, FreeImage), FREE_IMAGE_FORMAT.FIF_JPEG,
//        //    FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYGOOD |
//        //    FREE_IMAGE_SAVE_FLAGS.JPEG_BASELINE);

//        using var ms = new MemoryStream();
//        resized.Save(ms, FREE_IMAGE_FORMAT.FIF_JPEG, FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYGOOD | FREE_IMAGE_SAVE_FLAGS.JPEG_BASELINE);
//        return ms.ToArray();
//    }

//    public byte[] ResizeImage(int size, int quality, byte[] bytes)
//    {
//        using var original = FreeImageBitmap.FromStream(new MemoryStream(bytes));

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
//        var resized = new FreeImageBitmap(original, width, height);
//        // JPEG_QUALITYGOOD is 75 JPEG.
//        // JPEG_BASELINE strips metadata (EXIF, etc.)
//        //resized.Save(OutputPath(path, outputDirectory, FreeImage), FREE_IMAGE_FORMAT.FIF_JPEG,
//        //    FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYGOOD |
//        //    FREE_IMAGE_SAVE_FLAGS.JPEG_BASELINE);

//        using var ms = new MemoryStream();
//        resized.Save(ms, FREE_IMAGE_FORMAT.FIF_JPEG, FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYGOOD | FREE_IMAGE_SAVE_FLAGS.JPEG_BASELINE);
//        return ms.ToArray();
//    }
//}
