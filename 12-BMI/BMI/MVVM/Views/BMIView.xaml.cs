using BMI.MVVM.ViewModels;

namespace BMI.MVVM.Views;

public partial class BMIView : ContentPage
{
	public BMIView()
	{
		InitializeComponent();
		  BindingContext = new BMIViewModel();
	}
}