//using Java.Util;
using Eco_Ease_Recycling.ViewModels;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;
//using Windows.Devices.Spi.Provider;
using Firebase.Auth.Providers;
using Firebase.Database;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Graphics;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using ZXing.Net.Maui.Controls;
using Location = Eco_Ease_Recycling.Views.Location;
//using System.Windows.Networking.NetworkOperators;


namespace Eco_Ease_Recycling
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiMaps()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Anybody-Regular.ttf", "AnybodyRegular");
                    fonts.AddFont("AlikeAngular-Regular.ttf", "Alike");
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

            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Argb(0, 0, 0, 0));
#endif
            });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CreateAccount>();
            builder.Services.AddSingleton<CreateAccountViewModel>();
            builder.Services.AddSingleton<Homepage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<Homepage>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<LoadingPageViewModel>();
            builder.Services.AddSingleton<EnableNotification>();
            builder.Services.AddSingleton<SuccessfulLogin>();
            builder.Services.AddSingleton<Location>();
            builder.Services.AddSingleton<QRScan>();
            builder.Services.AddSingleton<Splashpage1>();
            builder.Services.AddSingleton<Splashpage2>();
            builder.Services.AddSingleton<Splashpage3>();
            builder.Services.AddSingleton<Splashpage4>();
            builder.Services.AddSingleton<Splashpage5>();
            builder.Services.AddSingleton<Profilepage>();
            builder.Services.AddSingleton<HistoryPage>();
            builder.Services.AddSingleton<Walletpage>();
            builder.Services.AddSingleton<AddCard>();
            builder.Services.AddSingleton<Editprofile>();
            builder.Services.AddSingleton<EditProfileViewModel>();
            builder.Services.AddSingleton<ActivityDetailsPage>();






            return builder.Build();

        }
    }
}
