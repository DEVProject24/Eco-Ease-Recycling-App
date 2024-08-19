using Eco_Ease_Recycling.ViewModels;
using Eco_Ease_Recycling.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Firebase.Database;
using Firebase.Auth;
//using Windows.Devices.Spi.Provider;
using Firebase.Auth.Providers;
using ZXing.Net.Maui.Controls;

namespace Eco_Ease_Recycling
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
                    fonts.AddFont("Anybody-Regular.ttf","AnybodyRegular");
                    fonts.AddFont("AlikeAngular-Regular.ttf","Alike");
                    fonts.AddFont("AnekBangla-SemiBold", "Aneksemi");
                })
                .UseBarcodeReader();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(new FirebaseClient("https://eco-ease-5e1f9-default-rtdb.firebaseio.com/"));
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {

                ApiKey = "AIzaSyB3Tzx-BUz15FmXd2fDEyr7YuPUB6HbmMU",
                AuthDomain = "eco-ease-5e1f9.firebaseapp.com",
                Providers = [new EmailProvider()]
                
            }));

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CreateAccount>();
            builder.Services.AddSingleton<CreateAccountViewModel>();
            builder.Services.AddSingleton<Homepage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<Homepage>();
            builder .Services.AddSingleton<LoadingPage>();
            builder .Services.AddSingleton<LoadingPageViewModel>();

            



            return builder.Build();

        }
    }
}
