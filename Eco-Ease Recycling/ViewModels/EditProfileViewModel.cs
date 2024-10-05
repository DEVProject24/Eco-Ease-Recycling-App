using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class EditProfileViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly FirebaseClient _firebaseClient;

        // User properties to bind in XAML
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public EditProfileViewModel(FirebaseAuthClient firebaseAuthClient, FirebaseClient firebaseClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            _firebaseClient = firebaseClient;

            LoadUserProfile();
        }

        // Load user profile data from the Firebase Database
        private async void LoadUserProfile()
        {
            try
            {
                var currentUser = _firebaseAuthClient.User;
                var userId = currentUser?.Uid;

                if (userId != null)
                {
                    var userRef = _firebaseClient.Child("User").Child(userId);
                    var userData = await userRef.OnceSingleAsync<CreateAccountModel>();

                    // Bind the user data to the properties
                    UserName = userData.UserName;
                    Email = userData.Email;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user profile: {ex.Message}");
            }
        }

        // Save command to update profile data in Firebase
        [RelayCommand]
        private async Task Save()
        {
            var currentUser = _firebaseAuthClient.User;
            var userId = currentUser?.Uid;

            if (userId != null)
            {
                var confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Would you like to save the changes?", "Yes", "No");
                if (confirm)
                {
                    try
                    {
                        // Update user profile in Realtime Database
                        var userRef = _firebaseClient.Child("Users").Child(userId);
                        await userRef.PutAsync(JsonConvert.SerializeObject(new CreateAccountModel
                        {
                            UserName = _userName,
                            Email = _email
                        }));

                        // Optionally, update email/password in Firebase Authentication
                        //if (!string.IsNullOrWhiteSpace(email) && email != currentUser.Info.Email)
                        //{
                        //    await currentUser.UpdateEmailAsync(email);
                            
                            
                        //}

                        if (!string.IsNullOrWhiteSpace(_password))
                        {
                            await currentUser.ChangePasswordAsync(_password);
                        }

                        await App.Current.MainPage.DisplayAlert("Success", "Your profile has been updated!", "OK");
                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", $"Failed to update profile: {ex.Message}", "OK");
                    }
                }
            }
        }

        // Command to handle cancel operation
        [RelayCommand]
        private async Task Cancel()
        {
            var confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Would you like to discard the changes?", "Yes", "No");
            if (confirm)
            {
                // Navigate back or clear the fields
                await Shell.Current.GoToAsync("..");
            }
        }


    }

}

