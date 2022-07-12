using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library.Models;
public class Plant
{
    public int PlantId { get; set; }
    public string Name { get; set; } = null!;
    public string? Location { get; set; }
}
