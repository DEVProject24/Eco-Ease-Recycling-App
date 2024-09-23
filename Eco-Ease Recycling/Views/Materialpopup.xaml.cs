using CommunityToolkit.Maui.Views;

namespace Eco_Ease_Recycling.Views;

public partial class Materialpopup : Popup
{
	public Materialpopup()
	{
		InitializeComponent();
	}

    private void OnPopupButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}