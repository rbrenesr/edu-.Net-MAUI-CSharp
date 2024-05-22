using NavigationDemo.MVVM.ViewModels;

namespace NavigationDemo.MVVM.Pages;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
        BindingContext = new Page2ViewModel();
	}

    //public Page2(string name)
    //{
    //    InitializeComponent();
    //    txtName.Text = name;
    //}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Utilities.NavUtilities.Examine(Navigation);
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FinalPage());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}