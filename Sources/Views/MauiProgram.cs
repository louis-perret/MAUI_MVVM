using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ViewModel;
using StubLib;
using Views.Pages;
using Model;

namespace Views;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<IDataManager, StubData>();
        builder.Services.AddSingleton<ChampionManagerVM>();
        builder.Services.AddSingleton<AppVM>();
        builder.Services.AddSingleton<CharactersLibraryPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}