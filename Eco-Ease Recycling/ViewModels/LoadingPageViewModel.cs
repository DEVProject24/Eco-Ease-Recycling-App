using CommunityToolkit.Mvvm.ComponentModel;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class LoadingPageViewModel:ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public LoadingPageViewModel(FirebaseAuthClient firebaseAuthClient)
        { _firebaseAuthClient = firebaseAuthClient;
            CheckUserLoginDetails();

        
        }

        private async void CheckUserLoginDetails()
        {
            if (string.IsNullOrWhiteSpace(_firebaseAuthClient?.User?.Info?.Email))
            {
               if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    AppShell.Current.Dispatcher.Dispatch(async () =>
                    {
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

                    });
                }
               else
                {
                    await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
                }
            }
        }
    }
}
