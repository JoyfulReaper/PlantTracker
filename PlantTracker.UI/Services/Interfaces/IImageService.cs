namespace PlantTracker.UI.Services.Interfaces;

public interface IImageService
{
    string DecodeImage(byte[] data, string type);
    public byte[] ResizeImage(int size, int quality, string filePath);
    public byte[] ResizeImage(int size, int quality, byte[] bytes);
}