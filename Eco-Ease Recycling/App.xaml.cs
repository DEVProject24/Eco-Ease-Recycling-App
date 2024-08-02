using Eco_Ease_Recycling.Views;

namespace Eco_Ease_Recycling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new  Homepage();
        }
    }
}
