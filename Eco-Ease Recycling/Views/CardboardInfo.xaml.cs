using CommunityToolkit.Maui.Views;

namespace Eco_Ease_Recycling.Views;

public partial class CardboardInfo : Popup
{
    public CardboardInfo()
    {
        InitializeComponent();
    }
    private void OnPopupButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}