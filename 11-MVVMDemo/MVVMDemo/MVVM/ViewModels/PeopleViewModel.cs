using MVVMDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.MVVM.ViewModels
{
    public class PeopleViewModel
    {
        
        //public List<string> People { get; set;  }
        public List<Person> People { get; set;  } = new List<Person>();


        public PeopleViewModel()
        {

            //People = new List<string>{ "John Doe", "Rafa"};

            People.Add(new Person { Name = "John Doe", Age = 25 });
            People.Add(new Person { Name = "Jane Doe", Age = 22 });
            People.Add(new Person { Name = "Sammy Doe", Age = 21 });
            People.Add(new Person { Name = "Don Doe", Age = 23 });
            People.Add(new Person { Name = "Ron Doe", Age = 24 });
            People.Add(new Person { Name = "Tom Doe", Age = 26 });
            People.Add(new Person { Name = "Jerry Doe", Age = 27 });
            People.Add(new Person { Name = "Harry Doe", Age = 28 });
            People.Add(new Person { Name = "Larry Doe", Age = 29 });
            People.Add(new Person { Name = "Mary Doe", Age = 30 });
            People.Add(new Person { Name = "Carry Doe", Age = 31 });
            People.Add(new Person { Name = "Barry Doe", Age = 32 });
            People.Add(new Person { Name = "Terry Doe", Age = 33 });
            People.Add(new Person { Name = "Jerry Doe", Age = 34 });
            People.Add(new Person { Name = "Harry Doe", Age = 35 });

        }
    }
}
