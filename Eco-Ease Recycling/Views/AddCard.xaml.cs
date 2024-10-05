//using Java.Util;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace Eco_Ease_Recycling.Views;

public partial class AddCard : ContentPage
{

    private readonly FirebaseClient _firebaseClient;
    private readonly FirebaseAuthClient _firebaseAuthClient;
    public AddCard(FirebaseClient firebaseClient, FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        _firebaseClient = firebaseClient;
        _firebaseAuthClient = firebaseAuthClient;
    }

    private async void OnAddCardClicked(object sender, EventArgs e)
    {
        string cardHolderName = CardHolderNameEntry.Text;
        string cardNumber = CardNumberEntry.Text;
        string expiryDate = ExpiryDateEntry.Text;
        string cvv = CvvEntry.Text;

        if (string.IsNullOrEmpty(cardHolderName) || string.IsNullOrEmpty(cardNumber) ||
                string.IsNullOrEmpty(expiryDate) || string.IsNullOrEmpty(cvv))
        {
            await DisplayAlert("Error", "Please fill in all the fields.", "OK");
            return;
        }

        var bankCardDetails = new
        {
            CardHolderName = cardHolderName,
            CardNumber = cardNumber,
            ExpiryDate = expiryDate,
            CVV = cvv,
            userID = _firebaseAuthClient.User.Info.Uid
        };
        string userId = _firebaseAuthClient.User.Info.Uid;
        await _firebaseClient
            .Child("Card")

            .PutAsync(JsonConvert.SerializeObject(bankCardDetails));

        await DisplayAlert("Success", "Your card details have been updated successfully", "OK");
    }

    private void Profile_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Profilepage");
    }
}