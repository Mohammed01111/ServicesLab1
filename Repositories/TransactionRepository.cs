using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;



namespace ServicesLab1.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.BankAccount).ToList();
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions.Include(t => t.BankAccount).FirstOrDefault(t => t.Id == id);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}

