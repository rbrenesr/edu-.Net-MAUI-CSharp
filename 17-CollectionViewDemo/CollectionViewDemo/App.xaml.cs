using CollectionViewDemo.MVVM.Views;

namespace CollectionViewDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new DataView();
            //MainPage = new LayoutPage();
            //MainPage = new EmptyView();
            MainPage = new ProductsView();
        }
    }
}
