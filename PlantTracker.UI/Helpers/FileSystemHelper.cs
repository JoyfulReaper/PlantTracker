using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.UI.Helpers;
internal class FileSystemHelper
{
    public string AppDataDirectory { get => FileSystem.Current.AppDataDirectory; }
}
