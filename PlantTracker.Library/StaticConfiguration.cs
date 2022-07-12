using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library;
public static class StaticConfiguration
{
    public static string ConnectionString { get; } = "Data Source=PlantTracker.db;Version=3;";
}
