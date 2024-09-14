//using Java.Util;
using CommunityToolkit.Mvvm.Input;

namespace Eco_Ease_Recycling.Views;

public partial class SuccessfulLogin : ContentPage
{
    public SuccessfulLogin()
    {
        InitializeComponent();
        BindingContext = this;
    }

    [RelayCommand]

    private async Task NavigatetoLogin()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
    }
}