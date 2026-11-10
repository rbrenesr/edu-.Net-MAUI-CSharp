using MVVMToolkitSample.MVVM.ViewModels;

namespace MVVMToolkitSample.MVVM.Views;

public partial class DemoPage : ContentPage
{
     public DemoPage()
     {
          InitializeComponent();
          BindingContext = new DemoViewModel();
     }
}