//using Java.Util;
namespace Eco_Ease_Recycling.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
        
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
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

    private void Overview_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Walletpage");
    }
}