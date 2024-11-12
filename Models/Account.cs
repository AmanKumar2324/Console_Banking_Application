using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application.Models
{
    public class Account
    {
        // Properties
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; } // e.g., "Savings", "Checking"
        public decimal Balance { get; set; }
        public DateTime DateOpened { get; set; }

        // Constructor
        public Account(int accountNumber, string accountHolderName, string accountType, decimal initialDeposit)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            AccountType = accountType;
            Balance = initialDeposit;
            DateOpened = DateTime.Now;
        }

        // Method to display account details
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {Balance:C}");
            Console.WriteLine($"Date Opened: {DateOpened}");
        }
    }
}
