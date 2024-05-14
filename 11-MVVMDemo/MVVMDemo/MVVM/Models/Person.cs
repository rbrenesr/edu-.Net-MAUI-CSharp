using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.MVVM.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public bool Married { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public double Weight { get; set; }        
        public TimeSpan LunchTime { get; set; }

    }
}
