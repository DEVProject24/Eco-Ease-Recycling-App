//using Java.Util;
namespace Eco_Ease_Recycling.Views;

public partial class Editprofile : ContentPage
{
    public Editprofile()
    {
        InitializeComponent();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }
}