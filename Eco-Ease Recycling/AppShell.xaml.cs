using Eco_Ease_Recycling.Views;

namespace Eco_Ease_Recycling
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CreateAccount), typeof(CreateAccount));
           
           Routing.RegisterRoute(nameof(Homepage), typeof(Homepage));
           Routing.RegisterRoute(nameof(Views.Location), typeof(Views.Location));
        }
    }
}
