using Eco_Ease_Recycling.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Eco_Ease_Recycling.Views;

public partial class ActivityDetailsPage : ContentPage
{
	public ActivityDetailsPage(RecyclingActivityModel activity)
	{
        InitializeComponent();

        MaterialsLabel.Text = activity.Materials;
        WeightLabel.Text = $"{activity.Weight} kg";
        MoneyEarnedLabel.Text = $"${activity.MoneyEarned}";
        RecyclingCenterLabel.Text = activity.LocationID;
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    // Retrieve the activity object from query parameters
    //    var activityString = Shell.Current.Navigation.NavigationStack.Last()
    //                                                                 .Parameters["activity"];
    //    var activity = JsonConvert.DeserializeObject<RecyclingActivityModel>(activityString);

    //    // Set labels
    //    MaterialsLabel.Text = activity.Materials;
    //    WeightLabel.Text = $"{activity.Weight} kg";
    //    MoneyEarnedLabel.Text = $"${activity.MoneyEarned}";
    //    RecyclingCenterLabel.Text = activity.LocationID;
    //}


}