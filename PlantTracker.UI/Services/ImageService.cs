using PlantTracker.UI.Services.Interfaces;

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
}
