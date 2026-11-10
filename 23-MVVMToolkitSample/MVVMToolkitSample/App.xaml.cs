using MVVMToolkitSample.MVVM.Views;

namespace MVVMToolkitSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new DemoPage();
	}
}
