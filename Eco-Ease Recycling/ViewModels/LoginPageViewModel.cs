//using Java.Util;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.Models;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {

        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly FirebaseClient _firebaseClient;

        [ObservableProperty]
        private LoginPageModel _loginPageModel = new();


        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private CreateAccountModel userModel = new();
        public LoginPageViewModel(FirebaseAuthClient firebaseAuthClient, FirebaseClient firebaseClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            _firebaseClient = firebaseClient;
        }

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                var result = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(LoginPageModel.Email, LoginPageModel.Password);
                if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
                {
                    //Shell.Current.FlyoutHeader = new Profilepage(_firebaseAuthClient);
                    await Shell.Current.GoToAsync($"//{nameof(Homepage)}");

                    var userID = result.User.Uid;

                    var userFromDatabase = await _firebaseClient
                        .Child("User")
                        .Child(userID)
                        .OnceSingleAsync<CreateAccountModel>();

                    if (userFromDatabase != null)
                    {
                        // Store user details in UserModel
                        userModel = new CreateAccountModel
                        {
                            UserID = userID,
                            Email = result.User.Info.Email,

                            UserName = result.User.Info.DisplayName
                        };

                    }
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
