using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantTracker.UI.Services.Interfaces;

namespace PlantTracker.UI.Services;
internal class FileService : IFileService
{
    public async Task<byte[]> GetFileBytes(string filePath)
    {
        var bytes = await File.ReadAllBytesAsync(filePath);
        return bytes;
    }

    public string GetContentType(string fileName)
    {
        return "";
    }
}
