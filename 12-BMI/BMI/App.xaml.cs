using BMI.MVVM.Views;

namespace BMI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BMIView();
        }
    }
}
