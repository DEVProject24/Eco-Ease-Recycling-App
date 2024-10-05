//using Java.Util;
using Firebase.Auth;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
//using Windows.Devices.Spi.Provider;
using Firebase.Auth.Providers;
using Firebase.Database;
using Eco_Ease_Recycling.ViewModels;
//using Windows.System;


namespace Eco_Ease_Recycling.Views;

public partial class Profilepage : ContentPage
{

    private readonly FirebaseAuthClient _authClient;
    private readonly FirebaseClient _firebaseClient;
    //private readonly LoginPageViewModel _loginPageViewModel;
    public Profilepage(FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        _authClient = firebaseAuthClient;
        if (!string.IsNullOrWhiteSpace(_authClient?.User?.Info?.Email))
        {
            UserEmailLabel.Text = _authClient?.User?.Info?.Email;
        }
         LoadUserProfile();
        //BindingContext = _loginPageViewModel = loginPageViewModel;
    }

    public Profilepage()
    {
        InitializeComponent();
        
        LoadUserProfile();
    }

    public async void LoadUserProfile()
    {
        if (!string.IsNullOrWhiteSpace(_authClient?.User?.Info?.Email))
        {
            UserEmailLabel.Text = _authClient?.User?.Info?.Email;
        }
        else
        {
            await DisplayAlert("Error", "User is not logged in", "OK");
        }
    }

    private void Profile_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Editprofile");
    }

    private void Wallet_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Walletpage");
    }

    private void History_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//HistoryPage");
    }

    private void LocationButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Location");
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Homepage");
    }

    private void ScanButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//QRScan");
    }


    private void ProfileButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }

    private void WalletButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddCard");
    }
}