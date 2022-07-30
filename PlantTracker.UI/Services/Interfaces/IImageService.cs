namespace PlantTracker.UI.Services.Interfaces;

public interface IImageService
{
    string DecodeImage(byte[] data, string type);
}