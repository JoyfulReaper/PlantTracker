
namespace PlantTracker.UI.ViewModels;
public class PlantVm
{
    public int PlantId { get; set; }
    public int? PlantPhotoId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public byte[] Photo { get; set; }
}
