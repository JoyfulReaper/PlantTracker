using PlantTracker.Library.Data;
using PlantTracker.Library.Services;
using PlantTracker.UI.Services;
using PlantTracker.UI.Services.Interfaces;


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

        builder.Services.AddTransient(provider => new PlantData(StaticConfiguration.ConnectionString));
        builder.Services.AddTransient(Provider => new PlantPhotoData(StaticConfiguration.ConnectionString));

        builder.Services.AddTransient<IDialogService, DialogService>();
        builder.Services.AddTransient<IMediaService, MediaService>();
        builder.Services.AddTransient<IFileService, FileService>();
        builder.Services.AddTransient<IImageService, ImageService>();

        builder.Services.AddSingleton<IMediaPicker, CustomMediaPicker>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif


        var app = builder.Build();


        SeedDatabase();

        return app;
    }

    private static void SeedDatabase()
    {
        var connectionString = $"Data Source={Path.Combine(FileSystem.Current.AppDataDirectory, "PlantTracker.db")}";
        var seeder = new RawSqlExecuter(connectionString);

        using var stream = FileSystem.OpenAppPackageFileAsync("PlantTrackerDb.db.sql").GetAwaiter().GetResult();
        using var reader = new StreamReader(stream);
        var sql = reader.ReadToEnd();
        seeder.ExecuteSql(sql);
    }
}
