using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.MVVM.Models
{
    public class TransactionsSummary
    {

        public DateTime TransactionDate { get; set; }
        public string ShownDate { get; set; }
        public decimal TransactionsTotal{ get; set; }

    }
}
