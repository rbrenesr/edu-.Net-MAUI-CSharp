using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.MVVM.ViewModels
{
    public class CommandsViewModel
    {
        //Forma 1 para crear un comando
        //public ICommand ClickCommand => new Command( ()=> App.Current.MainPage.DisplayAlert("Tittle","Message","Ok"));

        //Formna 2 de crear un commando
        //public ICommand ClickCommand => new Command(Alert);

        //Forma 3 de crear un comando
        public ICommand ClickCommand { get;  }





        public ICommand SearchCommand { get; }

        public ICommand SearchCommand2 { get; }
        public string SearchTerm { get; set; }





        public CommandsViewModel()
        {
            ClickCommand = new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Alert", "You clicked me", "OK");
            });


            SearchCommand = new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Search", $"You searched for {SearchTerm}", "OK");
            });


            SearchCommand2 = new Command((s) =>
            {
                App.Current.MainPage.DisplayAlert("Search", $"You searched for {s}", "OK");
            });

        }






        private void Alert()
        {
            App.Current.MainPage.DisplayAlert("Alert", "You clicked me", "OK");
        }
    }
}
