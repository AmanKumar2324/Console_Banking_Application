using System;
using Console_Banking_Application.Services;

namespace Console_Banking_Application.Menus
{
    public class TransactionMenu
    {
        public static void DepositMoney(TransactionService transactionService)
        {
            while (true)
            {
                Console.Write("Enter Account Number (or type 'back' to return to the main menu): ");
                string input = Console.ReadLine();
                // If user wants to go back to the main menu
                if (input.ToLower() == "back")
                {
                    return;
                }
                // Check if the account number is valid
                if (int.TryParse(input, out int accountNumber))
                {
                    // Ask for the deposit amount if account number is valid
                    Console.Write("Enter Deposit Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                    {
                        // Perform deposit
                        transactionService.Deposit(accountNumber, amount);
                        Console.WriteLine($"Successfully deposited {amount:C} into account {accountNumber}.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid deposit amount. Please enter a positive number.");
                    }
                }
                else
                {
                    // Error for invalid account number input
                    Console.WriteLine("Error: Invalid account number. Please enter a valid numeric account number.");
                }
            }
        }

        public static void WithdrawMoney(TransactionService transactionService)
        {
            while (true)
            {
                // Prompt for the account number and provide a "back" option
                Console.Write("Enter Account Number (or type 'back' to return to the main menu): ");
                string input = Console.ReadLine();

                // If user wants to go back to the main menu
                if (input.ToLower() == "back")
                {
                    return;
                }

                // Validate the account number input
                if (int.TryParse(input, out int accountNumber))
                {
                    while (true)
                    {
                        Console.Write("Enter Withdrawal Amount (or type 'back' to return to the main menu): ");
                        input = Console.ReadLine();
                        if (input.ToLower() == "back")
                        {
                            return;
                        }

                        // Validate the withdrawal amount input
                        if (decimal.TryParse(input, out decimal amount) && amount > 0)
                        {
                            // Attempt the withdrawal
                            transactionService.Withdraw(accountNumber, amount);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid withdrawal amount. Please enter a positive number.");
                        }
                    }
                }
                else
                {
                    // Error for invalid account number input
                    Console.WriteLine("Error: Invalid account number. Please enter a valid numeric account number.");
                }
            }
        }

        public static void ViewTransactionHistory(TransactionService transactionService)
        {
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                transactionService.ViewTransactionHistory(accountNumber);
            }
            else
            {
                Console.WriteLine("Error: Invalid account number.");
            }
        }
    }
}
