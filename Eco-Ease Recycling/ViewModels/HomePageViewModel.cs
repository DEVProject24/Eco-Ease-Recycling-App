//using Java.Util;
using CommunityToolkit.Mvvm.ComponentModel;
using Eco_Ease_Recycling.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly FirebaseClient _firebaseClient;

        public HomePageViewModel(FirebaseAuthClient firebaseAuthClient, FirebaseClient firebaseClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            _firebaseClient = firebaseClient;
            LoadUserName();
        }

        [ObservableProperty]
        private string _userName;

        private async Task LoadUserName()
        {
            try
            {
                var currentUser = _firebaseAuthClient.User;
                var userId = currentUser?.Uid;

                if (userId != null)
                {
                    var userRef = _firebaseClient.Child("User").Child(userId);
                    var userData = await userRef.OnceSingleAsync<CreateAccountModel>();

                    // Set the UserName property to the retrieved user's name
                    _userName = userData.UserName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user data: {ex.Message}");
            }
        }
    }

}
