using CommunityToolkit.Maui.Views;
namespace Eco_Ease_Recycling.Views;

public partial class GlassInfo : Popup
{
    public GlassInfo()
    {
        InitializeComponent();
    }

    private void OnPopupButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}