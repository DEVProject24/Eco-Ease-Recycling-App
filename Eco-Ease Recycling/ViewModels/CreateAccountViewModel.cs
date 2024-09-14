using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.Models;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class CreateAccountViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public CreateAccountViewModel(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
        }

        [ObservableProperty]
        private CreateAccountModel createAccountModel = new();

        [RelayCommand]

        private async Task SignUp()
        {
            try
            {
                var result = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(
                 CreateAccountModel.Email, CreateAccountModel.Password, CreateAccountModel.Username);

                if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
                {
                    await Shell.Current.GoToAsync($"//{nameof(EnableNotification)}", true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //var result = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(
            //     createAccountModel.Email, createAccountModel.Password, createAccountModel.Username);
            //if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
            //{
            //    await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
            //}


        }

        [RelayCommand]

        private async Task NavigateSignIn()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
        }
    }

}
