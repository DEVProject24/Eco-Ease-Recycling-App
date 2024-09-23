using CommunityToolkit.Maui.Views;
namespace Eco_Ease_Recycling.Views;

public partial class MetalInfo : Popup
{
    public MetalInfo()
    {
        InitializeComponent();
    }
    private void OnPopupButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}