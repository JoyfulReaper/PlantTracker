using PlantTracker.UI.Models;
using PlantTracker.UI.Services.Interfaces;

namespace PlantTracker.UI.Services;
internal class MediaService : IMediaService
{
    private readonly IMediaPicker _mediaPicker;

    public MediaService(IMediaPicker mediaPicker)
    {
        _mediaPicker = mediaPicker;
        
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