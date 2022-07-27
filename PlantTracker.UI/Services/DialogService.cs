using PlantTracker.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.UI.Services;
internal class DialogService : IDialogService
{
    public async Task<bool> DisplayConfirm(string title, string message, string accept, string cancel)
    {
        return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }
    
    public async Task DisplayConfirm(string title, string message, string cancel)
    {
        await Application.Current.MainPage.DisplayAlert(title, message, cancel);
    }
}
