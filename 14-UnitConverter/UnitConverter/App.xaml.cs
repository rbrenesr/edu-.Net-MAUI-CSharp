using UnitConverter.MVVM.Views;

namespace UnitConverter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //            MainPage = new MenuView();
            //MainPage = new ConverterView();
            MainPage = new NavigationPage(new MenuView());
        }
    }
}
