using PlantTracker.Library.Models;

namespace PlantTracker.UI.Services.Interfaces;
internal interface IMediaService
{
    Task<FileDetails> TakePhoto();
    public double GetScreenWidth();
    public double GetScreenHeight();
}