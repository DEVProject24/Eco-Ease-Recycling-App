//using Java.Util;
namespace Eco_Ease_Recycling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//MainPage");

            base.OnStart();
        }
    }
}
