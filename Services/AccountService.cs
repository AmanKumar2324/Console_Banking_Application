using System;
using System.Collections.Generic;
using System.Linq;
using Console_Banking_Application.Models;
using Console_Banking_Application.Utils;

namespace Console_Banking_Application.Services
{
    public class AccountService
    {
        // In-memory list to store bank accounts
        private List<Account> accounts = new List<Account>();
        private int nextAccountNumber = 1001; // Initial account number

        // Method to open a new account
        public bool OpenAccount(string accountHolderName, string accountType, decimal initialDeposit)
        {
            try
            {
                // Validate account type
                if (accountType.ToLower() != "savings" && accountType.ToLower() != "checking")
                {
                    Console.WriteLine("Invalid account type. Please choose either 'Savings' or 'Checking'.");
                    return false;
                }

                // Ensure initial deposit is not negative
                if (initialDeposit < 0)
                {
                    Console.WriteLine("Initial deposit cannot be negative.");
                    return false;
                }

                // Create a new Account object
                var newAccount = new Account(nextAccountNumber++, accountHolderName, accountType, initialDeposit);
                accounts.Add(newAccount);

                Console.WriteLine($"Account successfully created! Your account number is {newAccount.AccountNumber}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Failed to open account. {ex.Message}");
                return false;
            }
        }

        // Method to check account balance
        public decimal CheckBalance(int accountNumber)
        {
            try
            {
                var account = GetAccountByNumber(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found. Please enter valid account number or open new account if not opened.");
                    return -1;
                }

                return account.Balance;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to check balance. {ex.Message}");
                return -1;
            }
        }

        // Method to calculate and add interest for savings accounts
        public bool CalculateInterest(int accountNumber, decimal interestRate)
        {
            try
            {
                var account = GetAccountByNumber(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found. Please enter valid account number or open new account if not opened.");
                    return false;
                }

                if (account.AccountType.ToLower() != "savings")
                {
                    Console.WriteLine("Interest can only be calculated for savings accounts.");
                    return false;
                }

                // Calculate interest and update the balance
                decimal interestAmount = (account.Balance * interestRate) / 100;
                account.Balance += interestAmount;

                Console.WriteLine($"Interest of {interestAmount:C} added. New Balance: {account.Balance:C}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to calculate interest. {ex.Message}");
                return false;
            }
        }

        // Helper method to find an account by its number
        public Account GetAccountByNumber(int accountNumber)
        {
            return accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
        }

        // Optional: Method to display account details (for debugging)
        public void DisplayAccountDetails(int accountNumber)
        {
            var account = GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.DisplayAccountInfo();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
