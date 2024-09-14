//using Java.Util;
using Eco_Ease_Recycling.ViewModels;

namespace Eco_Ease_Recycling.Views;

public partial class CreateAccount : ContentPage
{
    private readonly CreateAccountViewModel _createAccountViewModel;
    public CreateAccount(CreateAccountViewModel createAccountViewModel)
    {
        InitializeComponent();
        BindingContext = _createAccountViewModel = createAccountViewModel;
        //BindingContext = this;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LoginPage");
    }

    private void MainPage_Clicked(object sender, EventArgs e)
    {
       
        Shell.Current.GoToAsync("//MainPage");
      
    }
}