namespace TranslatorApp;
using TranslatorApp.Models;
using TranslatorApp.ViewModels;
using TranslatorApp.Services;
using TranslatorApp.Views;

using SQLite;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

       // string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");

        string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "words.db3");

        builder.Services.AddSingleton<LocalDbServices>(s => ActivatorUtilities.CreateInstance<LocalDbServices>(s, dbPath));

        builder.Services.AddSingleton<ApiServices>();

        builder.Services.AddSingleton<DetailsViewModel>();
        builder.Services.AddSingleton<TranslationHistoryViewModel>();
        builder.Services.AddSingleton<TranslationViewModel>();

        builder.Services.AddSingleton<Details>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<TranslationHistory>();


        return builder.Build();
	}
}
