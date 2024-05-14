using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.MVVM.Models;

namespace MVVMDemo.MVVM.ViewModels
{
    public class ConvertersViewModel
    {
        public Data Data { get; set; }
        public ConvertersViewModel()
        {
            Data = new Data { 
                Merried = "Yes" 
            };
        }
    }
}
