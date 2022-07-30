using PlantTracker.Library.Data;
using PlantTracker.Library.Models;


namespace PlantTracker.Library.Services;

public class PlantService
{
    private readonly PlantData _plantData;
    private readonly PlantActivityData _plantActivityData;
    private readonly ActivityData _activityData;
    private readonly PlantPhotoData _plantPhotoData;

    public PlantService(PlantData plantData,
        PlantActivityData plantActivityData,
        ActivityData activityData,
        PlantPhotoData plantPhotoData)
    {
        _activityData = activityData;
        _plantData = plantData;
        _plantActivityData = plantActivityData;
        _plantPhotoData = plantPhotoData;
    }

    public async Task AddPlant(Plant plant, FileDetails photo)
    {
        await _plantData.Insert(plant);

        PlantActivity plantActivity = new()
        {
            PlantId = plant.PlantId,
            PlantActivityId = (await _activityData.Get("Created")).ActivityId
        };

        await _plantActivityData.Insert(plantActivity);

        if (photo != null)
        {
            PlantPhoto plantPhoto = new()
            {
                PlantId = plant.PlantId,
                Photo = await File.ReadAllBytesAsync(photo.FilePath),
                PhotoContentType = photo.ContentType
            };

            await _plantPhotoData.Insert(plantPhoto);
            plant.PlantPhotoId = plantPhoto.PlantPhotoId;
            await _plantData.Update(plant);
        }
    }
}
