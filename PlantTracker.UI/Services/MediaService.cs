using PlantTracker.Library.Models;
using PlantTracker.UI.Models;
using PlantTracker.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.UI.Services;
internal class MediaService : IMediaService
{
    public async Task<FileContentType> TakePhoto()
    {
        var output = new FileContentType();

        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                output.FilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                output.ContentType = photo.ContentType;

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(output.FilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
            else
            {
                throw new Exception("Unable to capture photo.");
            }
        }

        return output;
    }

    //public async Task<PlantPhoto> TakePlantPhoto()
    //{
    //    var output = new PlantPhoto();

    //    if (MediaPicker.Default.IsCaptureSupported)
    //    {
    //        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

    //        if (photo != null)
    //        {
    //            var photoStream = await photo.OpenReadAsync();
    //            if (photoStream.Length > int.MaxValue)
    //            {
    //                throw new Exception("Photo is to large");
    //            }

    //            using MemoryStream ms = new MemoryStream((int)photoStream.Length);
    //            (await photo.OpenReadAsync()).CopyTo(ms);

    //            output.PhotoContentType = photo.ContentType;
    //            output.Photo = ms.ToArray();
    //        }
    //        else
    //        {
    //            throw new Exception("Unable to capture photo");
    //        }
    //    }

    //    return output;
    //}
}
