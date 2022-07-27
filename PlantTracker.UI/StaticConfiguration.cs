using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.UI;
internal class StaticConfiguration
{
    public static string DatabaseFile { get; } = Path.Combine(FileSystem.Current.AppDataDirectory, "PlantTracker.db");
    public static string ConnectionString { get; } = $"Data Source={DatabaseFile};";
}
