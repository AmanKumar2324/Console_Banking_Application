using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application.Models
{
    public class Transaction
    {
        // Properties
        public string TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // e.g., "Deposit" or "Withdrawal"
        public decimal Amount { get; set; }

        // Constructor
        public Transaction(string transactionId, int accountNumber, string type, decimal amount)
        {
            TransactionId = transactionId;
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }

        // Method to display transaction details
        public void DisplayTransactionInfo()
        {
            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Amount: {Amount:C}");
        }
    }
}
