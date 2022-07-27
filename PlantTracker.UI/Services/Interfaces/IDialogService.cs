using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.UI.Services.Interfaces;
internal interface IDialogService
{
    Task<bool> DisplayConfirm(string title, string message, string accept, string cancel);
    Task DisplayConfirm(string title, string message, string cancel);
}
