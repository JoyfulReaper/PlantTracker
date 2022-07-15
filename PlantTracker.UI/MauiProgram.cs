using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;
using PlantTracker.Library.Data;
using PlantTracker.Library.Services;
using System.Reflection;

namespace PlantTracker.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.Services.AddMauiBlazorWebView();
		builder.Services.AddTransient<DatabaseSeederService>();
		builder.Services.AddTransient<PlantData>();
        
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif
		
        
		var app = builder.Build();

		var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<DatabaseSeederService>();
        using var stream = FileSystem.OpenAppPackageFileAsync("PlantTrackerDb.db.sql").GetAwaiter().GetResult();
        using var reader = new StreamReader(stream);
        var sql = reader.ReadToEnd();
		seeder.SeedDatabase(sql).GetAwaiter().GetResult();

        return app;
	}
}
