using CommunityToolkit.Mvvm.Input;
using Eco_Ease_Recycling.ViewModels;

namespace Eco_Ease_Recycling.Views;

public partial class Homepage : ContentPage
{
	public Homepage()
	{
		InitializeComponent();
		//BindingContext = vm;
	}

	//[RelayCommand]
 //      private async Task NavigatetoLocation()
 //      {
 //   	await Shell.Current.GoToAsync("//Location");
 //      }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Location");
    }
}