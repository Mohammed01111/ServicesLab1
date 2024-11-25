using ServicesLab1.Models;
using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactionRepository.GetTransactionById(id);
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(transaction);
        }

        public void DeleteTransaction(int id)
        {
            _transactionRepository.DeleteTransaction(id);
        }
    }
}
}
