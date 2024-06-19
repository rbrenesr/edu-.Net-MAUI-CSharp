using Weather.MVVM.Views;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherView();
        }
    }
}
