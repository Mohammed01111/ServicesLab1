using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServicesLab1.Services
{
    public class ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(int id);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int id);

        internal void AddTransaction(Models.Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
