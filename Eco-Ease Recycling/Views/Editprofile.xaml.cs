//using Java.Util;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Eco_Ease_Recycling.ViewModels;
using Eco_Ease_Recycling.Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Eco_Ease_Recycling.Views;

public partial class Editprofile : ContentPage
{
    private readonly FirebaseClient _firebaseClient;
    //private readonly EditProfileViewModel _editProfileViewModel;
    private readonly FirebaseAuthClient _authClient;
    
    public Editprofile(FirebaseAuthClient firebaseAuthClient, FirebaseClient firebaseClient)
    {
        InitializeComponent();
        
        _authClient = firebaseAuthClient;
        _firebaseClient = firebaseClient;
        
    LoadUserProfile();
    }

    //public Editprofile()
    //{
    //    InitializeComponent ();
    //    LoadUserProfile();
    //}

    private string _userId = string.Empty;
    private async void LoadUserProfile()
    {
        
        try
        {
            // Get the current user from Firebase Auth
            var currentUser = _authClient.User;
            

            if (currentUser != null)
            {
                _userId = currentUser.Uid;

                // Get user data from Firebase Realtime Database
                var userFromDatabase = await _firebaseClient
                    .Child("User")
                    .Child(_userId)
                    .OnceSingleAsync<CreateAccountModel>();

                if (userFromDatabase != null)
                {
                    // Populate UI fields
                    usernameEntry.Text = currentUser.Info.DisplayName;
                    emailEntry.Text = currentUser.Info.Email;
                    passwordEntry.Text = "********"; // Placeholder for the password
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to load profile: " + ex.Message, "OK");
        }
    }

    private async void OnUpdateProfileClicked(object sender, EventArgs e)
    {
        try
        {
            var newUsername = usernameEntry.Text;
            var newEmail = emailEntry.Text;
            var newPassword = passwordEntry.Text;

            // Prompt user to confirm changes
            bool confirm = await DisplayAlert("Confirm Changes", "Do you want to save the changes?", "Yes", "No");

            if (confirm)
            {
                var currentUser = _authClient.User;

                // Update Firebase Authentication (Email and Password)
                if (currentUser != null)
                {
                    if (newPassword != "********")
                    {
                        await currentUser.ChangePasswordAsync(newPassword);
                    }
                }

                if (currentUser != null)
                {
                    if (newUsername != null)
                    {
                        await currentUser.ChangeDisplayNameAsync(newUsername);
                    }
                }
                // Update Realtime Database (Username)
                await _firebaseClient
                    .Child("User")
                    .Child(_userId)
                    .PutAsync(new CreateAccountModel
                    {
                        UserID = _userId,
                        Email = newEmail,
                        UserName = newUsername
                    });

                await DisplayAlert("Success", "Profile updated successfully.", "OK");

                // Optionally, redirect to another page (e.g., home)
                await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to update profile: " + ex.Message, "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Go back to the previous page without saving
        await Shell.Current.GoToAsync("..");
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }

    private void Profile_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }
};

    


