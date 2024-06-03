namespace StylesDemo;

public partial class DynamicStyleView : ContentPage
{
	public DynamicStyleView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

		Application.Current.Resources.TryGetValue("specialButton", out var retVal);

		//Resources["dynamicStyle"] = Resources["greenStyle"];
		Resources["dynamicStyle"] = (Style)retVal;
    }
}