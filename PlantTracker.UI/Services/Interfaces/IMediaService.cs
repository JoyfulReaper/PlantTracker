using PlantTracker.Library.Models;

namespace PlantTracker.UI.Services.Interfaces;
internal interface IMediaService
{
    Task<FileDetails> TakePhoto();
}