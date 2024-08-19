using CommunityToolkit.Mvvm.Input;

namespace Eco_Ease_Recycling.Views;

public partial class EnableNotification : ContentPage
{
	public EnableNotification()
	{
		InitializeComponent();
        BindingContext = this;
	}

    [RelayCommand]

    private async Task NavigatetoSignIn()
    {
        await Shell.Current.GoToAsync($"//{nameof(SuccessfulLogin)}", true);
    }
}