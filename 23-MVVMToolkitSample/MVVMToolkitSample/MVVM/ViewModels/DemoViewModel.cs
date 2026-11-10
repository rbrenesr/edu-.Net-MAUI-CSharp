using Bogus;
using MVVMToolkitSample.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMToolkitSample.MVVM.ViewModels
{
     [AddINotifyPropertyChangedInterface]
     public class DemoViewModel
    {
          public FakePerson Person { get; set; }
          public string Password { get; set; }

          public ICommand GenerateData =>
               new Command(() =>
               {
                    var faker = new Faker<FakePerson>()
                    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                    .RuleFor(p => p.LastName, f => f.Person.LastName)
                    .Generate();

                    Person.FirstName = faker.FirstName;
                    Person.LastName= faker.LastName;

                    Password = new Faker().Internet.Password(5, true);
               });

          public DemoViewModel()
          {
               Person = new FakePerson
               {
                    FirstName = "Héctor",
                    LastName = "Pérez",
               };

               Password = new Faker().Internet.Password(5, true);
          }
     }
}
