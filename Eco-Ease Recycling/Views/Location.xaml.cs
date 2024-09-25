//using Java.Util;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.ObjectModel;
//using Microsoft.UI.Xaml.Controls;
//using Map = Microsoft.Maui.Controls.Maps.Map;

namespace Eco_Ease_Recycling.Views;

public partial class Location : ContentPage
{
    public ObservableCollection<Pin> _pins = new(); // Displayed pins on the map
    public List<Pin> _allPins = new(); // Full list of pins (used for search filtering)
    public GeolocationRequest _geolocationRequest = new(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
    private DateTime _lastTapTime;
    private Pin _lastTappedPin;
    public Location()
    {
        InitializeComponent();

        // Set up the map and search functionality
        GetAndCenterUserLocationAsync();
        AddRecyclingCenterPins();

        // Bind map pins to the ObservableCollection
        map.ItemsSource = _pins;

        // Hook up the search bar text changed event
        SearchBar.TextChanged += SearchBar_TextChanged;

        //map.MapClicked += OnMapClicked;
        

    }



    // Search bar event handler to filter pins based on search input
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue?.ToLower();

        // If the search query is empty, display all pins
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            UpdateMapPins(_allPins); // Reset to show all pins
        }
        else
        {
            // Filter pins based on both Label and Address containing the search term
            var filteredPins = _allPins.Where(pin =>
                pin.Label.ToLower().Contains(searchTerm) ||
                pin.Address.ToLower().Contains(searchTerm)).ToList();

            // Update the map to show only filtered pins
            UpdateMapPins(filteredPins);
        }
    }

    // Method to update the map pins without duplicating or causing unnecessary redraws
    private void UpdateMapPins(IEnumerable<Pin> pinsToShow)
    {
        _pins.Clear();
        foreach (var pin in pinsToShow)
        {
            _pins.Add(pin);
        }
    }

    // Get the user's location and center the map on it, with a fallback if location fails
    private async Task GetAndCenterUserLocationAsync()
    {
        try
        {
            var location = await Geolocation.Default.GetLocationAsync(_geolocationRequest);
            if (location != null)
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(10)));
            }
            else
            {
                throw new Exception("Location is null.");
            }
        }
        catch (Exception ex)
        {
            // Handle location retrieval error and center the map to a default location
            Console.WriteLine($"Error getting location: {ex.Message}");
            var defaultLocation = new Microsoft.Maui.Devices.Sensors.Location(-26.2041, 28.0473); // Johannesburg coordinates
            map.MoveToRegion(MapSpan.FromCenterAndRadius(defaultLocation, Distance.FromMiles(10)));
        }
    }

    // Method to add all recycling center pins to the map and store them in _allPins for future filtering
    private void AddRecyclingCenterPins()
    {
        var recyclingCenters = new List<Pin>
            {
                new Pin
                {
                    Label = "Mpact Limited",
                    Address = "3 Melrose Blvd, Melrose, Johannesburg, 2196",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.135185217668344, 28.068385923194175)
                },


                new Pin
                {
                    Label = "Mpact Recycling Newtown (BRJ)",
                    Address = "103 Barney Simon st, Newtown, Johannesburg, 2113",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.203645136060707, 28.03017930785737)
                },
                new Pin
                {
                    Label = "Mpact Plastics Wadeville",
                    Address = "Cnr Dekema & Lantern Rd, Wadvillle, Johannesburg, 1428",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.267008916485555, 28.18370732490792)
                },
                new Pin
                {
                    Label = "Mpact Recycling Tulisa Park",
                    Address = "17 Brunel Rd, Tulisa Park, Johannesburg, 2136",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.24545805339062, 28.10127365018917)
                },
                new Pin
                {
                    Label = "Mpact Plastic Containers Castleview",
                    Address = "1 Atom Rd Castleview, Wadeville, Germiston, 1422",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.24545805339062, 28.10127365018917)
                },
                new Pin
                {
                    Label = "Mpact Roodekop",
                    Address = "1 Log Rd, Union Settlement, Germiston, 1401",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.29015580539453, 28.180833752037174)
                },
                new Pin
                {
                    Label = "Mpact Recycling Germiston",
                    Address = "18 James Bright Ave, Germiston Driehoek, Germiston, 1401",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.21980157875653, 28.14154823669312)
                },
                new Pin
                {
                    Label = "Mpact Paper Springs",
                    Address = "82-84 Steel Rd, New Era, Springs, 1559",
                    Location = new Microsoft.Maui.Devices.Sensors.Location(-26.25885047207088, 28.40626387959999)
                },


         };

        foreach (var pin in recyclingCenters)
        {
           
            pin.MarkerClicked += OnPinClicked;
            _allPins.Add(pin);

           
        }

        //Add all pins to both _allPins(for search) and _pins(for initial display)
        _allPins.AddRange(recyclingCenters);
        UpdateMapPins(recyclingCenters);
    }

    //private void OnInfoWindowClicked(object? sender, PinClickedEventArgs e)
    //{
    //    throw new NotImplementedException();
    //}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        map.ItemsSource = _pins;  // Ensure pins are added when the page is shown
    }

    private void LocationButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Location");
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Homepage");
    }

    private void ScanButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//QRScan");
    }


    private void ProfileButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }

    private void WalletButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Walletpage");
    }

    //private async void OnMapClicked(object sender, MapClickedEventArgs e)
    //{
    //    // If last tap is on the same pin within a short duration, consider it a double-tap
    //    if (_lastTappedPin != null && DateTime.Now - _lastTapTime < TimeSpan.FromMilliseconds(500))
    //    {
    //        // Open Google Maps for directions
    //        await OpenGoogleMaps(_lastTappedPin.Location);
    //    }
    //    else
    //    {
    //        // Save this as the last tap
    //        _lastTapTime = DateTime.Now;
    //        _lastTappedPin = null;

    //        // Check if tap was on a pin
    //        foreach (var pin in _pins)
    //        {
    //            if (IsTapOnPin(e.Location, pin.Location))
    //            {
    //                _lastTappedPin = pin;
    //                break;
    //            }
    //        }
    //    }
    //}

    //private bool IsTapOnPin(Microsoft.Maui.Devices.Sensors.Location tapLocation, Microsoft.Maui.Devices.Sensors.Location pinLocation)
    //{
    //    const double tolerance = 0.0005;  // Adjust tolerance as needed for map zoom level
    //    return Math.Abs(tapLocation.Latitude - pinLocation.Latitude) < tolerance
    //           && Math.Abs(tapLocation.Longitude - pinLocation.Longitude) < tolerance;
    //}

    //private async Task OpenGoogleMaps(Microsoft.Maui.Devices.Sensors.Location location)
    //{
    //    var latitude = location.Latitude;
    //    var longitude = location.Longitude;
    //    var googleMapsUrl = $"https://www.google.com/maps/dir/?api=1&destination={latitude},{longitude}";

    //    // Open Google Maps
    //    await Launcher.OpenAsync(new Uri(googleMapsUrl));
    //}

    //Event handler for pin taps
    //private DateTime _lastTapTimePin;
    //private Pin _lastTappedPinForGoogleMaps;

    //private async void OnPinClicked(object sender, PinClickedEventArgs e)
    //{
    //    var currentTime = DateTime.Now;

    //    if (_lastTappedPinForGoogleMaps == sender && (currentTime - _lastTapTimePin).TotalMilliseconds < 500)
    //    {
    //        // Double-tap detected, open Google Maps for directions
    //        var pin = (Pin)sender;
    //        await OpenGoogleMaps(pin.Location);
    //    }
    //    else
    //    {
    //        _lastTapTimePin = currentTime;
    //        _lastTappedPinForGoogleMaps = (Pin)sender;
    //    }

    //    // Prevent further propagation of the click event
    //    e.HideInfoWindow = false;  // You can remove this if you want the info window to show
    //}

    //private async void OnInfoWindowClicked(object sender, PinClickedEventArgs e)
    //{
    //    var pin = sender as Pin;
    //    if (pin != null)
    //    {
    //        // Get user's current location
    //        var location = await Geolocation.Default.GetLocationAsync(_geolocationRequest);
    //        if (location != null)
    //        {
    //            // Create Google Maps URL with directions from current location to pin location
    //            var googleMapsUrl = $"https://www.google.com/maps/dir/?api=1&origin={location.Latitude},{location.Longitude}&destination={pin.Location.Latitude},{pin.Location.Longitude}";
    //            await Launcher.OpenAsync(new Uri(googleMapsUrl));
    //        }
    //        else
    //        {
    //            await DisplayAlert("Error", "Unable to retrieve current location.", "OK");
    //        }
    //    }
    //    e.HideInfoWindow = false; // Optionally, set to true if you don't want to show the pin info window again
    //}



    private async void OnPinClicked(object sender, PinClickedEventArgs e)
    {
        if (sender is Pin pin)
        {
            // Get the user's current location
            var location = await Geolocation.Default.GetLocationAsync(_geolocationRequest);
            if (location != null)
            {
                var googleMapsUrl = $"https://www.google.com/maps/dir/?api=1&origin={location.Latitude},{location.Longitude}&destination={pin.Location.Latitude},{pin.Location.Longitude}";

                // Open Google Maps
                await Launcher.OpenAsync(new Uri(googleMapsUrl));
            }
            else
            {
                await DisplayAlert("Error", "Unable to retrieve current location.", "OK");
            }
        }

    }
}