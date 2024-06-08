using CollectionViewDemo.MVVM.ViewModels;

namespace CollectionViewDemo.MVVM.Views;

public partial class LayoutPage : ContentPage
{
	public LayoutPage()
	{
		InitializeComponent();
		BindingContext = new DataViewModel();
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var element = e.CurrentSelection;
    }
}