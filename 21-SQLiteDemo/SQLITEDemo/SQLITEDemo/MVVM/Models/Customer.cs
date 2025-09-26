using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace SQLITEDemo.MVVM.Models
{
    [Table("Customers")]
    public class Customer : Abstractions.TableData
    {



        [Indexed, NotNull]
        public string Name { get; set; }

        [Unique]
        public string Phone { get; set; }
        public int Age { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung => Age > 50 ? true : false;


        [ForeignKey(typeof(Passport))]
        public int PassportId { get; set; }

        //[OneToOne(
        //    CascadeOperations =
        //        CascadeOperation.CascadeInsert | 
        //        CascadeOperation.CascadeRead
        //)]

        //[OneToOne( CascadeOperations = CascadeOperation.All)]
        //public Passport Passport { get; set; }




        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<Passport> Passports { get; set; }




        [ManyToMany(typeof(Passport),CascadeOperations = CascadeOperation.All)]
        public List<Passport> Passports { get; set; }
    }
}
