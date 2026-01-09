using Microsoft.Extensions.Logging;
using ProGymMobile.Services;
using ProGymMobile.ViewModels;

namespace ProGymMobile
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ClasaFitnessService>();
            builder.Services.AddSingleton<ClaseFitnessViewModel>();
            builder.Services.AddSingleton<Views.ClaseFitnessPage>();
            builder.Services.AddSingleton<Views.HomePage>();

            return builder.Build();
        }
    }
}
