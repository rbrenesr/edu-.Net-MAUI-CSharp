using ProsperDaily.MVVM.Models;
using ProsperDaily.MVVM.Views;
using ProsperDaily.Repositories;

namespace ProsperDaily
{
    public partial class App : Application
    {

        public static BaseRepository<Transaction> TransactionRepo { get; private set; }

        public App(BaseRepository<Transaction> _transactionRepo)
        {
            InitializeComponent();
            TransactionRepo = _transactionRepo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            //return new Window(new NavigationPage(new DashboardPage()));
            //return new Window(new TransactionsPage());
            //return new Window(new StatisticsPage());
            return new Window( new AppContainer());
        }
    }
}