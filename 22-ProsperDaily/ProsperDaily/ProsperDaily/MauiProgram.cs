using Microsoft.Extensions.Logging;
using ProsperDaily.MVVM.Models;
using ProsperDaily.Repositories;
using Syncfusion.Maui.Core.Hosting;

namespace ProsperDaily
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Black.ttf", "Strong");
                    fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");

                });



            builder.Services.AddSingleton<BaseRepository<Transaction>>();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
