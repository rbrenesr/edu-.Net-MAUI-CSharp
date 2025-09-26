using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.MVVM.Models
{
    public class Order: Abstractions.TableData
    {
       
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
