using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Eco_Ease_Recycling.Views
{
    public partial class MainPage : ContentPage
    {
        private List<ImageSource> _imageSources = new List<ImageSource>
        {
            GetImageSource("splash1.jpg"),
            GetImageSource("splash2.jpg"),
            GetImageSource("splash3.jpg"),
            GetImageSource("splash4.jpg"),
            GetImageSource("splash5.jpg")
        };
        private int _currentImageIndex = 0;
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(2);
        private System.Timers.Timer _timer;


        public MainPage()
        {
            InitializeComponent();
            StartImageRotation();
        }

        // Method to get image source from embedded resources
        private static ImageSource GetImageSource(string imageName)
        {
            return ImageSource.FromResource($"Eco_Ease_Recycling.Resources.Images.{imageName}", typeof(MainPage).Assembly);
        }

        private void StartImageRotation()
        {
            _timer = new System.Timers.Timer(_interval.TotalMilliseconds);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
            UpdateImage();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _currentImageIndex = (_currentImageIndex + 1) % _imageSources.Count;
            UpdateImage();
        }

        private void UpdateImage()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    SplashImage.Source = _imageSources[_currentImageIndex];
                    Console.WriteLine($"Image updated to: {_imageSources[_currentImageIndex]}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating image: {ex.Message}");
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer.Stop();
            _timer.Dispose();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
