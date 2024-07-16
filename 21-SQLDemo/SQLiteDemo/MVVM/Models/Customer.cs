using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.MVVM.Models
{
    [SQLite.Table("Customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed, NotNull]
        public string Name { get; set; }
        [Unique]
        public string Phone { get; set; }
        public int Age { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung => Age < 50 ? true : false;
    }
}
