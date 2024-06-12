using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestDemo.MVVM.Models
{  
    public class User
    {
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string alias { get; set; }
        public string id { get; set; }

        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, Avatar: {avatar}, Alias: {alias}";
        }
    }

}
