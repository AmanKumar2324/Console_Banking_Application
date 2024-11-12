using System;
using Console_Banking_Application.Services;

namespace Console_Banking_Application.Menus
{
    public class AccountMenu
    {
        public static void OpenAccount(AccountService accountService, string username)
        {
            Console.WriteLine("\n--- Open a New Account ---\n");

            string accountType;
            while (true)
            {
                Console.Write("Enter Account Type 'savings'/'checking' (or type 'back' to return to the main menu): ");
                accountType = Console.ReadLine();
                if(accountType.ToLower() == "back")
                {
                    return;
                }
                if (accountType.Equals("Savings", StringComparison.OrdinalIgnoreCase) ||
                    accountType.Equals("Checking", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid account type. Please enter either 'Savings' or 'checking'.");
                }
            }

            decimal initialDeposit;
            while (true)
            {
                Console.Write("Enter Initial Deposit: ");
                if (decimal.TryParse(Console.ReadLine(), out initialDeposit) && initialDeposit >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid deposit amount.");
                }
            }

            accountService.OpenAccount(username, accountType, initialDeposit);
        }

        public static void CheckBalance(AccountService accountService)
        {
            while (true)
            {
                Console.Write("Enter Account Number (or type 'back' to return to the main menu): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    return; 
                }
                // Validate the account number input
                if (int.TryParse(input, out int accountNumber))
                {
                    // Attempt to retrieve the balance
                    decimal balance = accountService.CheckBalance(accountNumber);
                    if (balance != -1)
                    {
                        // Display the balance if account exists
                        Console.WriteLine($"Current Balance: {balance:C}");
                        return;
                    }
                }
                else
                {
                    // Error message for invalid input
                    Console.WriteLine("Error: Invalid account number. Please enter a valid account number.");
                }
            }
        }

    }
}
