using Android.App;
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
        //public ICommand ClickCommand { get; }
        public ICommand ClickCommand => new Command(Alert);
        public ICommand SearchCommand { get; }
        public string SearchTerm { get; set; }

        public CommandsViewModel()
        {
        //    ClickCommand = new Command(() =>
        //    {
        //        App.Current.MainPage.DisplayAlert("Alert", "You clicked me", "OK");
        //    });


            SearchCommand = new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Search", $"You searched for {SearchTerm}", "OK");
            });


        }


        //Forma I de crear commands
        //public ICommand ClickCommand => new Command(() =>
        //{
        //    App.Current.MainPage.DisplayAlert("Alert", "You clicked me", "OK");
        //});



        private void Alert()
        {
            App.Current.MainPage.DisplayAlert("Alert", "You clicked me", "OK");
        }
    }
}
