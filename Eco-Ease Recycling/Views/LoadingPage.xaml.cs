using Eco_Ease_Recycling.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace Eco_Ease_Recycling.Views;

public partial class LoadingPage : ContentPage
{
	private readonly LoadingPageViewModel _loadingPageViewModel;
	public LoadingPage(LoadingPageViewModel loadingPageViewModel)
	{
		InitializeComponent();
		BindingContext = _loadingPageViewModel = loadingPageViewModel;
	}
}