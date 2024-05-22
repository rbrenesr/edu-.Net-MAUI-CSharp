using UnitConverter.MVVM.ViewModels;

namespace UnitConverter.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		//BindingContext = new ConverterViewModel();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
    }
}