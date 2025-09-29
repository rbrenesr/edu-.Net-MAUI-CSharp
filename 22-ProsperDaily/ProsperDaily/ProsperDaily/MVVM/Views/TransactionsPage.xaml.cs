using System.Threading.Tasks;

namespace ProsperDaily.MVVM.Views;

public partial class TransactionsPage : ContentPage
{
	public TransactionsPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.TransactionViewModel();
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVM = BindingContext as ViewModels.TransactionViewModel;
        var message = currentVM?.SaveTransaction();
        await DisplayAlert("Status", message, "OK");
        await Navigation.PopToRootAsync();
    }
}