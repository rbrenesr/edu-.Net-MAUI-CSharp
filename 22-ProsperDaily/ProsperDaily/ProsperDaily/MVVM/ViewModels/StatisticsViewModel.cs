using PropertyChanged;
using ProsperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary> Summary { get; set; }
        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionRepo.GetItems();

            var resul = new List<TransactionsSummary>();

            var groupedTransactions = data.GroupBy(t => t.OperationDate.Date);

            foreach (var group in groupedTransactions)
            {
                var transactionSummary = new TransactionsSummary
                {
                    TransactionDate = group.Key,
                    ShownDate = group.Key.ToString("MM/dd"),
                    TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount)
                };
                resul.Add(transactionSummary);

            }

            resul = resul.OrderBy(t => t.TransactionDate).ToList();
            Summary = new ObservableCollection<TransactionsSummary>(resul);

            var spendingList = data.Where(t => !t.IsIncome).OrderByDescending(t => t.OperationDate).ToList();
            SpendingList = new ObservableCollection<Transaction>(spendingList);

        }


    }
}
