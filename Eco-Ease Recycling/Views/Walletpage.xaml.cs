//using Java.Util;
namespace Eco_Ease_Recycling.Views;
using Firebase.Database;
using Eco_Ease_Recycling.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Firebase.Auth;
using Application = Application;

public partial class Walletpage : ContentPage
{
    public Walletpage()
    {
        InitializeComponent();
        _tipsService = new TipsService();
        LoadTipsAsync();
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
        Shell.Current.GoToAsync("//Walletpage");
    }

    private void HistoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//HistoryPage");
    }

    private TipsService _tipsService;
    private List<string> _tips = new List<string>();
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
        App.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(TipIntervalSeconds), () =>
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
}