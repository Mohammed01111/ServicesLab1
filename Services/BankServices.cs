using ServicesLab1.Models;
using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class BankService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransactionService _transactionService;

        public BankService(IBankAccountRepository bankAccountRepository, ITransactionService transactionService)
        {
            _bankAccountRepository = bankAccountRepository;
            _transactionService = transactionService;
        }

        public void Deposit(int accountId, decimal amount)
        {
            var account = _bankAccountRepository.GetAccountById(accountId);
            if (account == null)
                throw new Exception("Account not found.");

            account.Balance += amount;
            _bankAccountRepository.UpdateAccount(account);

            _transactionService.AddTransaction(new Transaction
            {
                SourceAccNumber = "ATM",
                Operation = "Deposit",
                Amount = amount,
                BankAccountId = accountId
            });
        }

        public void Withdraw(int accountId, decimal amount)
        {
            var account = _bankAccountRepository.GetAccountById(accountId);
            if (account == null)
                throw new Exception("Account not found.");

            if (account.Balance < amount)
                throw new Exception("Insufficient funds.");

            account.Balance -= amount;
            _bankAccountRepository.UpdateAccount(account);

            _transactionService.AddTransaction(new Transaction
            {
                SourceAccNumber = "ATM",
                Operation = "Withdraw",
                Amount = amount,
                BankAccountId = accountId
            });
        }

        public void Transfer(int sourceAccountId, int destinationAccountId, decimal amount)
        {
            var sourceAccount = _bankAccountRepository.GetAccountById(sourceAccountId);
            var destinationAccount = _bankAccountRepository.GetAccountById(destinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
                throw new Exception("Account not found.");

            if (sourceAccount.Balance < amount)
                throw new Exception("Insufficient funds.");

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            _bankAccountRepository.UpdateAccount(sourceAccount);
            _bankAccountRepository.UpdateAccount(destinationAccount);

            _transactionService.AddTransaction(new Transaction
            {
                SourceAccNumber = destinationAccount.AccountNumber,
                Operation = "Transfer",
                Amount = amount,
                BankAccountId = sourceAccountId
            });

            _transactionService.AddTransaction(new Transaction
            {
                SourceAccNumber = sourceAccount.AccountNumber,
                Operation = "Transfer",
                Amount = amount,
                BankAccountId = destinationAccountId
            });
        }
    }

}
