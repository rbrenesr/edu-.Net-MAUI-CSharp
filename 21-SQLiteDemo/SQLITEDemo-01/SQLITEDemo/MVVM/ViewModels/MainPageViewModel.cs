using Bogus;
using PropertyChanged;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLITEDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }

        public MainPageViewModel()
        {
            Console.WriteLine($"ENTRO..................................01");
            GenerateNewCustomer();

            Console.WriteLine($"ENTRO..................................02");


            AddOrUpdateCommand = new Command( () =>
            {
                App.CustomerRepo.AddOrUpdate(CurrentCustomer!);
                Console.WriteLine($"Customer {CurrentCustomer!.Name} added/updated.");
                GenerateNewCustomer();
            });
        }

        private void GenerateNewCustomer()
        {
            
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Person.FullName) 
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .Generate();
        }

    }
}
