using Tasker.MVVM.Views;

namespace Tasker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainView();
            MainPage = new NewTaskView();
        }
    }
}
