using PlantTracker.Library.Data;
using PlantTracker.Library.Models;
using PlantTracker.UI.Services.Interfaces;
using PlantTracker.UI.ViewModels;

namespace PlantTracker.UI.Services;
public class PlantVmService
{
    private readonly PlantData _plantData;
    private readonly PlantPhotoData _plantPhotoData;
    private readonly IImageService _imageService;

    public PlantVmService(PlantData plantData,
        PlantPhotoData plantPhotoData,
        IImageService imageService)
    {
        _plantData = plantData;
        _plantPhotoData = plantPhotoData;
        _imageService = imageService;
    }

    public async Task<IEnumerable<PlantVm>> GetAll(int? size = null)
    {
        var output = new List<PlantVm>();
        var plants = await _plantData.GetAll();

        foreach(var plant in plants)
        {
            PlantVm plantVm = new();
            PlantPhoto plantPhoto = null;

            if (plant.PlantPhotoId.HasValue)
            {
                plantPhoto = await _plantPhotoData.Get(plant.PlantPhotoId.Value);
            }

            plantVm.PlantId = plant.PlantId;
            plantVm.PlantPhotoId = plantPhoto?.PlantPhotoId;
            plantVm.Name = plant.Name;
            plantVm.Location = plant.Location;

            if (size != null && plantPhoto != null)
            {
                plantVm.Photo = _imageService.ResizeImage(size.Value, 75, plantPhoto.Photo);
            }
            else
            {
                plantVm.Photo = plantPhoto?.Photo;
            }

            output.Add(plantVm);
        }

        return output;
    }

    public async Task<PlantVm> Get(int plantId, int? size = null)
    {
        var output = new PlantVm();
        var plant = await _plantData.Get(plantId);
        PlantPhoto plantPhoto = null;

        if (plant.PlantPhotoId.HasValue)
        {
            plantPhoto = await _plantPhotoData.Get(plant.PlantPhotoId.Value);
        }

        output.PlantId = plant.PlantId;
        output.PlantPhotoId = plantPhoto?.PlantPhotoId;
        output.Name = plant.Name;
        output.Location = plant.Location;
        
        if(size != null && plantPhoto != null)
        {
            output.Photo = _imageService.ResizeImage(size.Value, 75, plantPhoto.Photo);
        }
        else
        {
            output.Photo = plantPhoto?.Photo;
        }

        return output;
    }
}
