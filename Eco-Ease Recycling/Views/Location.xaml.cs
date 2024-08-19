//using Java.Util;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
//using Map = Microsoft.Maui.Controls.Maps.Map;

namespace Eco_Ease_Recycling.Views;

public partial class Location : ContentPage
{
    //private object maps;

    public Location()
    {
        InitializeComponent();
    }


    public List<Pin> Pins { get; set; } = new List<Pin>();
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
        //var location = await Geolocation.Default.GetLocationAsync(geolocationRequest);
        var location = new Microsoft.Maui.Devices.Sensors.Location(-26.188594684804833, 28.01623843788264);

        map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(10)));

        Pins.Add(new Pin
        {
            Label = "Mpact Limited",
            Address = "3 Melrose Blvd, Melrose, Johannesburg, 2196",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.135185217668344, 28.068385923194175)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Recycling Newtown (BRJ)",
            Address = "103 Barney Simon st, Newtown, Johannesburg,2113",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.203645136060707, 28.03017930785737)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Plastics Wadeville",
            Address = "Cnr Dekema & Lantern Rd, Wadvillle, Johanenesburg, 1428",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.267008916485555, 28.18370732490792)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Recycling Tulisa Park",
            Address = "17 Brunel Rd, Tulisa Park, Johannesburg, 2136",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.24545805339062, 28.10127365018917)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Plastic Containers Castleview",
            Address = "1Atom Rd Castleview, Wadeville, Germiston, 1422",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.24545805339062, 28.10127365018917)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Roodekop",
            Address = "1 Log Rd,Union Settlement, Germiston, 1401",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.29015580539453, 28.180833752037174)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Recycling Germiston",
            Address = "18 james Bright Ave, Germiston Driehoek, Germiston, 1401",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.21980157875653, 28.14154823669312)
        });

        Pins.Add(new Pin
        {
            Label = "Mpact Paper Springs",
            Address = "82-84 Steel Rd, New Era, Springs, 1559",
            Location = new Microsoft.Maui.Devices.Sensors.Location(-26.25885047207088, 28.40626387959999)
        });

        var pin = new Pin
        {
            Address = "Address",
            Location = location,
            Type = PinType.Place,
            Label = "Home"
        };
        map.Pins.Add(pin);

        map.ItemsSource = Pins;
    }
}