
﻿using Eco_Ease_Recycling.ViewModels;
using Eco_Ease_Recycling.Views;
﻿using Eco_Ease_Recycling.Views;
using Location = Eco_Ease_Recycling.Views.Location;


namespace Eco_Ease_Recycling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new  AppShell();
        }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//Homepage");

            base.OnStart();
        }
    }
}
