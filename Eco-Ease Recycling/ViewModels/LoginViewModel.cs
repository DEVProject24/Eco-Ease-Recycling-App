//using Java.Util;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Eco_Ease_Recycling.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task Submit()
        {
            await Shell.Current.GoToAsync("//CreateAccount");

        }

        [RelayCommand]
        private async Task GoHome()
        {
            await Shell.Current.GoToAsync("//Homepage");

        }
    }


}








