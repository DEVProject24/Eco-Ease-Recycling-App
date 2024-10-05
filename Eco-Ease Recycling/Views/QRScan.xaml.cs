//using Java.Util;
using Eco_Ease_Recycling.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System.Globalization;


namespace Eco_Ease_Recycling.Views;

public partial class QRScan : ContentPage
{
    private bool isProcessingQRCode = false;
    private FirebaseClient _firebaseClient;
    private readonly FirebaseAuthClient _authClient;
    private string _userId;

    public QRScan(FirebaseAuthClient authClient, FirebaseClient firebaseClient)
    {
        InitializeComponent();
        _authClient = authClient;
        _firebaseClient = firebaseClient;


        if (!string.IsNullOrWhiteSpace(authClient?.User?.Info?.Email))
        {
            _userId = authClient.User.Uid;
        }
        // Initialize barcode reader options
        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false,
            TryHarder = true
        };

        // Register the event handler
        barcodeReader.BarcodesDetected += barcodeReader_BarcodesDetected;

    }

    private async void barcodeReader_BarcodesDetected(object? sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        if (isProcessingQRCode)
            return;

        isProcessingQRCode = true;

        var first = e.Results?.FirstOrDefault();
        if (first is null)
        {
            isProcessingQRCode = false;
            return;
        }


       // Use the main thread dispatcher to display the alert
       await Dispatcher.DispatchAsync(async () =>
       {
           await DisplayAlert("QR Code Detected", first.Value, "OK");
       });



        string qrData = first.Value;

        try
        {
            
            var qrParts = qrData.Split(',');

            //if (qrParts.Length != 5)
            //{
            //    await DisplayAlert("Error", "Invalid QR code format.", "OK");
            //    isProcessingQRCode = false;
            //    return;
            //}

            // Extract data from QR code
            var activityID = qrParts[0];
            var location = qrParts[4];
            //var scanID = qrParts[1];
            var materials = qrParts[1];

            double moneyEarned;
            double weight;

            if (!double.TryParse(qrParts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out weight))
            {
                await DisplayAlert("Error", "Invalid number format for money earned.", "OK");
                return; // Exit if the parsing fails
            }

            if (!double.TryParse(qrParts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out moneyEarned))
            {
                await DisplayAlert("Error", "Invalid number format for money earned.", "OK");
                return; // Exit if the parsing fails
            }



            // Create new recycling activity
            var newActivity = new RecyclingActivityModel
            {

                Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                //LocationID = "L_UNKNOWN",  // Location ID can be set based on your logic
                Materials = materials,
                MoneyEarned = moneyEarned,
                //ActivityID = "Sc_" + Guid.NewGuid().ToString(),  // Generate a unique scan ID
                ActivityId = activityID,
                UserId = _userId,
                Weight = weight,
                LocationID = location
            };

            //Save the activity to Firebase Realtime Database
            await SaveRecyclingActivity(newActivity);



        }
        catch (Exception ex) 
        {
            await DisplayAlert("Error", $"Could not process QR code: {ex.Message}", "OK");
        }

        isProcessingQRCode = false;
        
    }

    

    
private async Task SaveRecyclingActivity(RecyclingActivityModel activity)
    {
        try
        {

            await _firebaseClient
            .Child("RecyclingActivity")
            
            .Child(activity.ActivityId)
            .PutAsync(JsonConvert.SerializeObject(activity));

            string materials = activity.Materials ?? "Unknown";
            string weight = activity.Weight.ToString() ?? "0";
            string moneyEarned = activity.MoneyEarned.ToString() ?? "0";
            string recyclingCenter = activity.LocationID ?? "Unknown";

            //Show success message and display the activity details
            //await DisplayAlert("Success", "Nice", "OK");
            //    "Recycling activity recorded.\n\n" +
            //    "Materials: {materials}\n" +
            //    "Weight: {weight}kg\n" +
            //    "Money Earned: R{moneyEarned}\n" +
            //    "Recycling Center: {recyclingCenter}",
            //    "OK");

            // Navigate to the Activity Details Page with the activity details
            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to save activity: {ex.Message}", "OK");
        }
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
}