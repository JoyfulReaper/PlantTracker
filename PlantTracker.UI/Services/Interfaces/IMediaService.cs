using PlantTracker.Library.Models;
using PlantTracker.UI.Models;

namespace PlantTracker.UI.Services.Interfaces;
internal interface IMediaService
{
    Task<FileDetails> TakePhoto();
}