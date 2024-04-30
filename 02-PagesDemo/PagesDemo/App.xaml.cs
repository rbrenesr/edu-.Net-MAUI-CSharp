namespace PagesDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new MainPage();
            //MainPage = new ContentPageDemo();

            //NavigationPage navigationPage = new NavigationPage(new MainPage());
            //navigationPage.BarBackgroundColor = Color.FromHex("#3498db");
            //navigationPage.BarTextColor = Colors.White;
            //MainPage = navigationPage;

            //MainPage = new FlyoutPageDemo();
            MainPage = new TabbedPageDemo();
        }
    }
}
