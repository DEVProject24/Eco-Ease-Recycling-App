using ZXing;

namespace Eco_Ease_Recycling.Views;

public partial class QRScan : ContentPage
{
	public QRScan()
	{
        InitializeComponent();

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
    }
}