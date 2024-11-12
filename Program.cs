using Console_Banking_Application.Services;
using Console_Banking_Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Banking Application";
            UserService userService = new UserService();
            AccountService accountService = new AccountService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Banking Application Menu ---");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Open Account");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Calculate Interest (Savings Accounts)");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // User Registration
                        Console.Write("Enter Full Name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        if (Validator.IsValidInput(fullName) && Validator.IsValidInput(username) && Validator.IsValidInput(password))
                        {
                            userService.RegisterUser(username, password, fullName);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. All fields are required.");
                        }
                        break;

                    case "2":
                        // User Login
                        Console.Write("Enter Username: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string loginPassword = Console.ReadLine();

                        userService.Login(loginUsername, loginPassword);
                        break;

                    case "3":
                        // Open Account
                        Console.Write("Enter Account Holder Name: ");
                        string accHolderName = Console.ReadLine();
                        Console.Write("Enter Account Type (Savings/Checking): ");
                        string accType = Console.ReadLine();
                        Console.Write("Enter Initial Deposit Amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
                        {
                            accountService.OpenAccount(accHolderName, accType, initialDeposit);
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        break;

                    case "4":
                        // Check Balance
                        Console.Write("Enter Account Number: ");
                        if (int.TryParse(Console.ReadLine(), out int accountNumber))
                        {
                            decimal balance = accountService.CheckBalance(accountNumber);
                            if (balance != -1)
                            {
                                Console.WriteLine($"Current Balance: {balance:C}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid account number.");
                        }
                        break;

                    case "5":
                        // Calculate Interest
                        Console.Write("Enter Account Number: ");
                        if (int.TryParse(Console.ReadLine(), out int accNum))
                        {
                            Console.Write("Enter Interest Rate (in %): ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal interestRate))
                            {
                                accountService.CalculateInterest(accNum, interestRate);
                            }
                            else
                            {
                                Console.WriteLine("Invalid interest rate.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid account number.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
