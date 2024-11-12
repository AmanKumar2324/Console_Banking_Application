using System;
using System.Collections.Generic;
using Console_Banking_Application.Models;
using System.Linq;

namespace Console_Banking_Application.Services
{
    public class TransactionService
    {
        // In-memory list to store transactions
        private List<Transaction> transactions = new List<Transaction>();
        private AccountService accountService;

        // Constructor to accept account service as dependency
        public TransactionService(AccountService accountService)
        {
            this.accountService = accountService;
        }

        // Method to deposit money into an account
        public bool Deposit(int accountNumber, decimal amount)
        {
            try
            {
                // Validate deposit amount
                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be greater than zero.");
                    return false;
                }

                // Fetch the account by number
                var account = accountService.GetAccountByNumber(accountNumber);
                if (account == null)
                {
                    Console.WriteLine("ERROR: Account not found. Please check the account number.");
                    return false;
                }

                // Update account balance
                account.Balance += amount;

                // Log the transaction
                var transaction = new Transaction(Guid.NewGuid().ToString(), accountNumber, "Deposit", amount);
                transactions.Add(transaction);

                Console.WriteLine($"Deposit of {amount:C} successful. New Balance: {account.Balance:C}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to process deposit. {ex.Message}");
                return false;
            }
        }

        // Method to withdraw money from an account
        public bool Withdraw(int accountNumber, decimal amount)
        {
            try
            {
                // Validate withdrawal amount
                if (amount <= 0)
                {
                    Console.WriteLine("ERROR: Withdrawal amount must be greater than zero.");
                    return false;
                }

                // Fetch the account by number
                var account = accountService.GetAccountByNumber(accountNumber);
                if (account == null)
                {
                    Console.WriteLine("ERROR: Account not found. Please check the account number.");
                    return false;
                }

                // Check for sufficient balance
                if (amount > account.Balance)
                {
                    Console.WriteLine("ERROR: Insufficient funds. Unable to process withdrawal.");
                    return false;
                }

                // Update account balance
                account.Balance -= amount;

                // Log the transaction
                var transaction = new Transaction(Guid.NewGuid().ToString(), accountNumber, "Withdrawal", amount);
                transactions.Add(transaction);

                Console.WriteLine($"Withdrawal of {amount:C} successful. New Balance: {account.Balance:C}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to process withdrawal. {ex.Message}");
                return false;
            }
        }

        // Method to view transaction history for an account
        public void ViewTransactionHistory(int accountNumber)
        {
            try
            {
                var accountTransactions = transactions.Where(t => t.AccountNumber == accountNumber).ToList();

                if (accountTransactions.Count == 0)
                {
                    Console.WriteLine("ERROR: No transactions found for this account.");
                    return;
                }

                Console.WriteLine("\n--- Transaction History ---\n");
                foreach (var transaction in accountTransactions)
                {
                    transaction.DisplayTransactionInfo();
                    Console.WriteLine("-----------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to retrieve transaction history. {ex.Message}");
            }
        }
    }
}
