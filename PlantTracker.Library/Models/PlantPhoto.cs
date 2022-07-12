using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library.Models;
public class PlantPhoto
{
    public int PlantPhotoId { get; set; }
    public int PlantId { get; set; }
    public byte[] Photo { get; set; } = null!;
    public string PhotoContentType { get; set; } = null!;
    public DateTime DateAdded { get; set; }
}
