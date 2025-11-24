using Microsoft.Extensions.Logging;

namespace MAUI_Piemers
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

            builder.Services.AddTransient<ViewModel.IRectangleViewModel, ViewModel.RectanglesViewModelLite>();
            //  builder.Services.AddTransient<ViewModel.IRectangleViewModel, ViewModel.RectanglesViewModelEF>();
            builder.Services.AddTransient<Views.RectangleView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
