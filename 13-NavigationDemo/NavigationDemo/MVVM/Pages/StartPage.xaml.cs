using NavigationDemo.MVVM.ViewModels;
using NavigationDemo.Utilities;

namespace NavigationDemo.MVVM.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        BindingContext = new StartPageViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Utilities.NavUtilities.Examine(Navigation);
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //Pasar parámetros utilizando BindigCiontext entre VIewModels

        var currentViewModel =
            ((StartPageViewModel)BindingContext).Name;

        Navigation.PushAsync(new Page2 { 
            BindingContext = new Page2ViewModel { Name = currentViewModel }
        });


		//Crear una pagina completa que es llamada y se agrega a la pila de navegación
        //Navigation.PushAsync(new Page2(txtName.Text));

        //Permite llamar una pagina que se agrega a la pila de navegación de formato Modal
        //No tiene navigation bar
        //Inicia una pila de navegación nueva y diferente
        //Navigation.PushModalAsync(new CoolPage());
        //NavUtilities.RemovePage(Navigation, "StartPage");

    }
}