namespace PlantTracker.UI.Services.Interfaces;

public interface IImageService
{
    string DecodeImage(byte[] data, string type, int? size = null, int quality = 75);
    string DecodeImage(string path, string type, int? size = null, int quality = 75);
    byte[] ResizeImage(int size, int quality, string filePath);
    byte[] ResizeImage(int size, int quality, byte[] bytes);
}