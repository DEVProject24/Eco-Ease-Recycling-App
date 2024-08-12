using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.Models;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        [ObservableProperty]
        private LoginPageModel _loginPageModel = new();

        [ObservableProperty]
        private string _errorMessage;
        public LoginPageViewModel(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
        }

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                var result = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(
               _loginPageModel.Email, _loginPageModel.Password);
                if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
                {
                    await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
                }
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;  
            }
           
        }

        [RelayCommand]
        private async Task NavigateCreateAccount()
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateAccount)}");
        }
    }
}
