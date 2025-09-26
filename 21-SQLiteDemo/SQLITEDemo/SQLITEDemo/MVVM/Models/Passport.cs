using SQLITEDemo.Abstractions;
using SQLiteNetExtensions.Attributes;

namespace SQLITEDemo.MVVM.Models
{
    public class Passport: TableData
    {
        public DateTime ExpirationDate { get; set; }

        //[ForeignKey(typeof(Customer))]

        [ManyToMany(typeof(Customer))]
        public int CustomerId { get; set; }
    }
}
