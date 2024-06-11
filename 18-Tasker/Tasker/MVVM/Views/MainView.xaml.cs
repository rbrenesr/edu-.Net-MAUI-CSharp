using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{

    public MainViewModel mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.UpdateData();
    }
}