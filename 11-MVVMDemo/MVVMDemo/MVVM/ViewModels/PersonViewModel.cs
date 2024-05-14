using MVVMDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.MVVM.ViewModels
{
    public class PersonViewModel
    {
        public Person Person { get; set; }
        public PersonViewModel()
        {
            Person = new Person
            {
                Name = "John Doe",
                Age = 25,
                Married = true,
                BirthDate = new DateTime(1995, 1, 1),
                Weight = 70.5,
                LunchTime = new TimeSpan(12, 0, 0)
            };
        }
    }
}
