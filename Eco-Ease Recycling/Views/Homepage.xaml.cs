//using Java.Util;
using Firebase.Database;
using Eco_Ease_Recycling.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Maui.Views;
using Firebase.Auth;
using Microsoft.Maui.Controls;

namespace Eco_Ease_Recycling.Views;

public partial class Homepage : ContentPage
{
    private readonly FirebaseClient _firebaseClient;
    private readonly FirebaseAuthClient _authClient;
    public Homepage(FirebaseClient firebaseClient, FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        BindingContext = this;
        _firebaseClient = firebaseClient;
        _authClient = firebaseAuthClient;
        _tipsService = new TipsService();
        BindingContext = new HomePageViewModel(firebaseAuthClient, firebaseClient);
        LoadTipsAsync();



        if (!string.IsNullOrWhiteSpace(_authClient?.User?.Info?.DisplayName))
        {
            UserName.Text = _authClient?.User?.Info?.DisplayName;
        }
        LoadUserProfile();
        //BindingContext = vm;
    }
    private async void OnPlasticButton(object sender, EventArgs e)
    {
        var popup = new Materialpopup();
        await this.ShowPopupAsync(popup);
    }
    private async void OnPaperButton(object sender, EventArgs e)
    {
        var popup = new PaperInfo();
        await this.ShowPopupAsync(popup);
    }
    private async void OnBoxButton(object sender, EventArgs e)
    {
        var popup = new CardboardInfo();
        await this.ShowPopupAsync(popup);
    }
    private async void OnGlassButton(object sender, EventArgs e)
    {
        var popup = new GlassInfo();
        await this.ShowPopupAsync(popup);
    }

    private async void OnMetalButton(object sender, EventArgs e)
    {
        var popup = new MetalInfo();
        await this.ShowPopupAsync(popup);
    }
    //[RelayCommand]
    //      private async Task NavigatetoLocation()
    //      {
    //   	await Shell.Current.GoToAsync("//Location");
    //      }
    //protected override async void OnNavigatedTo(NavigationEventArgs e)
    //{
    //	base.OnNavigatedTo(args);
    //		await LoadTipsAsync();
    //}
    private void ImageButton_Clicked(object sender, EventArgs e)
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

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {

    }

    private void ProfileButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }

    private TipsService _tipsService;
    private List<string> _tips =new List<string>();
    private int _currentTipIndex = 0;
    private const int TipIntervalSeconds = 5;  // Change tip every 5 seconds

    private async Task LoadTipsAsync()
    {
        _tips = await _tipsService.FetchTipsAsync();

        if (_tips.Count > 0)
        {
            StartTipRotation();
        }
        else
        {
            TipsLabel.Text = "No recycling tips available.";
        }
    }

    private void StartTipRotation()
    {
        Microsoft.Maui.Controls.Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(TipIntervalSeconds), () =>
        {
            DisplayNextTip();
            return true;  // Repeat the timer
        });
    }

    private void DisplayNextTip()
    {
        if (_tips == null || _tips.Count == 0)
            return;

        // Show the next tip
        TipsLabel.Text = _tips[_currentTipIndex];

        // Move to the next tip, or go back to the first one
        _currentTipIndex = (_currentTipIndex + 1) % _tips.Count;
    }

    private void Wallet_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Walletpage");
    }

    
    public async void LoadUserProfile()
    {
        if (!string.IsNullOrWhiteSpace(_authClient?.User?.Info?.DisplayName))
        {
            UserName.Text = _authClient?.User?.Info?.DisplayName;
        }
        else
        {
            await DisplayAlert("Error", "User is not logged in", "OK");
        }
    }
}