//using Java.Util;
using CommunityToolkit.Maui.Views;

namespace Eco_Ease_Recycling.Views;

public partial class PaperInfo : Popup
{
    public PaperInfo()
    {
        InitializeComponent();
    }
    private void OnPopupButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}