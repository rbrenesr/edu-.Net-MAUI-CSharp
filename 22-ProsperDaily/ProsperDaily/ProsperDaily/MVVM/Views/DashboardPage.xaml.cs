namespace ProsperDaily.MVVM.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.DashboardViewModel();
    }

    private async void AddTransaction_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TransactionsPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var currentVM = BindingContext as ViewModels.DashboardViewModel;
        currentVM?.FillData();
    }
}