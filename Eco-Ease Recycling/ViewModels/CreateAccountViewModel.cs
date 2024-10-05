using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.Models;
using Eco_Ease_Recycling.Views;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class CreateAccountViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly FirebaseClient _firebaseClient;

        public CreateAccountViewModel(FirebaseAuthClient firebaseAuthClient, FirebaseClient firebaseClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            _firebaseClient = firebaseClient;
        }

        [ObservableProperty]
        private CreateAccountModel createAccountModel = new();

        [RelayCommand]

        private async Task SignUp()
        {
            try
            {
                var result = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(
                 CreateAccountModel.Email, CreateAccountModel.Password, CreateAccountModel.UserName);

                var UserID = result.User.Uid;

                var userData = new
                {
                    email = CreateAccountModel.Email,
                    password = CreateAccountModel.Password,
                    userID = UserID
                };

                // Store the user data in the "Users" table in the Realtime Database
                var usersRef = _firebaseClient.Child("User").Child(UserID);
                await usersRef.PutAsync(JsonConvert.SerializeObject(userData));

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
