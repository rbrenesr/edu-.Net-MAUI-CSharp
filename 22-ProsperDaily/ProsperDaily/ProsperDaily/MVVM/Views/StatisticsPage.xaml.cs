namespace ProsperDaily.MVVM.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.StatisticsViewModel();
    }

	override protected void OnAppearing()
	{
		base.OnAppearing();
		var viewModel = BindingContext as ViewModels.StatisticsViewModel;
		viewModel?.GetTransactionsSummary();
    }
}