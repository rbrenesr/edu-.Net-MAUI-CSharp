using SQLITEDemo.MVVM.Views;
using SQLITEDemo.Repositories;

namespace SQLITEDemo
{
    public partial class App : Application
    {
        public static CustomerRepository CustomerRepo { get; private set; }

        public App(CustomerRepository repo)
        {
            InitializeComponent();
            CustomerRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}