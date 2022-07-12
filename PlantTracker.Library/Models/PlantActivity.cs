using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library.Models;
public class PlantActivity
{
    public int PlantActivityId { get; set; }
    public int PlantId { get; set; }
    public int ActivityId { get; set; }
    public DateTime ActivityDate { get; set; }
}
