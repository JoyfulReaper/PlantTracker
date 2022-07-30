namespace PlantTracker.UI.Services.Interfaces;

internal interface IFileService
{
    Task<byte[]> GetFileBytes(string filePath);
}