using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.ViewModels;

namespace Eco_Ease_Recycling.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginPageViewModel _loginPageViewModel;
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
        InitializeComponent();
        BindingContext = _loginPageViewModel = loginPageViewModel;
	}

	//[RelayCommand]
 //   private async Task Submit()
 //   {
	//	await Shell.Current.GoToAsync("//CreateAccount");
 //   }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //     Shell.Current.GoToAsync("//CreateAccount");
    //}

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Homepage");
    }
}