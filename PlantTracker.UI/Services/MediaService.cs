using PlantTracker.Library.Models;
using PlantTracker.UI.Services.Interfaces;

namespace PlantTracker.UI.Services;
internal class MediaService : IMediaService
{
    private readonly IMediaPicker _mediaPicker;

    public MediaService(IMediaPicker mediaPicker)
    {
        _mediaPicker = mediaPicker;
        
    }
    
    public double GetScreenWidth()
    {
        return DeviceDisplay.Current.MainDisplayInfo.Width;
    }

    public double GetScreenHeight()
    {
        return DeviceDisplay.Current.MainDisplayInfo.Height;
    }

    public async Task<FileDetails> TakePhoto()
    {
        if (!_mediaPicker.IsCaptureSupported)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Camera not available", "OK");
            return null;
        }

        try
        {
            FileResult file = await _mediaPicker.CapturePhotoAsync();

            if (file != null)
            {
                FileDetails output = new FileDetails
                {
                    FilePath = file.FullPath,
                    ContentType = file.ContentType
                };
                return output;
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }

        return null;
    }
}