//using Java.Util;
namespace Eco_Ease_Recycling.Views;

public partial class Walletpage : ContentPage
{
    public Walletpage()
    {
        InitializeComponent();
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
}