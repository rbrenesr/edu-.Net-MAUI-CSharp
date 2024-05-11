using DataBindingDemo.Pages;

namespace DataBindingDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
