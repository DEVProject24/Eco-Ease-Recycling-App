//using Java.Util;
using Eco_Ease_Recycling.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;


namespace Eco_Ease_Recycling.Views;

public partial class QRScan : ContentPage
{
    private bool isProcessingQRCode = false;
    private FirebaseClient firebaseClient;
    private readonly FirebaseAuthClient authClient;
    private string userId;

    public QRScan()
    {
        InitializeComponent();
        //authClient = firebaseAuthClient;
        //firebaseClient = new FirebaseClient("https://eco-ease-5e1f9-default-rtdb.firebaseio.com/");


        //if (!string.IsNullOrWhiteSpace(authClient?.User?.Info?.Email))
        //{
        //    userId = authClient.User.Uid;
        //}
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
        var first = e.Results?.FirstOrDefault();
        if (first is null)
            return;

        // Use the main thread dispatcher to display the alert
        await Dispatcher.DispatchAsync(async () =>
        {
            await DisplayAlert("Barcode Detected", first.Value, "OK");
        });

        //if (isProcessingQRCode)
        //    return;

        //isProcessingQRCode = true;

        ////var qrData = e.Results.FirstOrDefault()?.Value;
        //string qrData = e.Results[0].Value;
        //var scanID = qrData[0];
        //var materials = qrData[1];
        //var weight = qrData[2];
        //double moneyEarned = qrData[3];

        //// Create new recycling activity
        //var newActivity = new RecyclingActivityModel
        //{
        //    //ActivityID = Guid.NewGuid().ToString(),
        //    Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
        //    //LocationID = "L_UNKNOWN",  // Location ID can be set based on your logic
        //    Materials = Char.ToString(materials),
        //    MoneyEarned = moneyEarned,
        //    //ScanID = "Sc_" + Guid.NewGuid().ToString(),  // Generate a unique scan ID
        //    UserId = userId,
        //    Weight = weight
        // };

        //    if (qrData != null)
        //    {
        //        try
        //        {
        //            //var recyclingData = Newtonsoft.Json.JsonConvert.DeserializeObject<RecyclingActivityModel>(qrData);

        //            await SaveRecyclingActivity(newActivity);

        //            await DisplayAlert("Success", "Recycling activity recorded.", "OK");
        //        }
        //        catch (Exception ex)
        //        {
        //            await DisplayAlert("Error", $"Could not process QR code: {ex.Message}", "OK");

        //        }
        //    }
        //    isProcessingQRCode = false;
        //}

        //private async Task SaveRecyclingActivity(RecyclingActivityModel activity)
        //{


        //    await firebaseClient
        //    .Child("RecyclingActivity")
        //    .Child("user_id")
        //    .PostAsync(activity);
        //}
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