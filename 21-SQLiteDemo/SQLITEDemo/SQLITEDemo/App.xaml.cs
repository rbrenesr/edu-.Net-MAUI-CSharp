using SQLITEDemo.MVVM.Models;
using SQLITEDemo.MVVM.Views;
using SQLITEDemo.Repositories;

namespace SQLITEDemo
{
    public partial class App : Application
    {
        //public static CustomerRepository CustomerRepo { get; private set; }
        public static BaseRepository<Customer> CustomerRepo { get; private set; }
        public static BaseRepository<Order> OrderRepo { get; private set; }
        public static BaseRepository<Passport> PassportRepo { get; private set; }

        //public App(CustomerRepository repo)
        public App(
            BaseRepository<Customer> customerRepo, 
            BaseRepository<Order> orderRepo,
            BaseRepository<Passport> passportRepo
            )
        {
            InitializeComponent();
            CustomerRepo = customerRepo;
            OrderRepo = orderRepo;
            PassportRepo = passportRepo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}