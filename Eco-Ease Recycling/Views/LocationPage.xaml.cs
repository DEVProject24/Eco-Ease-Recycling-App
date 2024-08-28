using Java.Util;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
//using Map = Microsoft.Maui.Controls.Maps.Map;

namespace Eco_Ease_Recycling.Views;

public partial class Location : ContentPage
{
    private object maps;

    public Location()
    {
        InitializeComponent();
    }



    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
        var location = await Geolocation.GetLocationAsync(geolocationRequest);

        maps.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(10)));
    }
}