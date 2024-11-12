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
            TransactionService transactionService = new TransactionService(accountService);

            bool exit = false;
            bool isLoggedIn = false;
            string loggedInUser = null;

            while (!exit)
            {
                try
                {
                    // Display Main Menu
                    Console.WriteLine("\n--- Welcome to the Console Banking Application ---");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Open Account");
                    Console.WriteLine("4. Check Balance");
                    Console.WriteLine("5. Deposit Money");
                    Console.WriteLine("6. Withdraw Money");
                    Console.WriteLine("7. View Transaction History");
                    Console.WriteLine("8. Exit");
                    Console.Write("Please select an option (1-8): ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Register a new user
                            RegisterUser(userService);
                            break;

                        case "2":
                            // Login user
                            loggedInUser = LoginUser(userService);
                            isLoggedIn = loggedInUser != null;
                            break;

                        case "3":
                            // Open an account (requires login)
                            if (isLoggedIn)
                                OpenAccount(accountService, loggedInUser);
                            else
                                Console.WriteLine("Please login first to open an account.");
                            break;

                        case "4":
                            // Check account balance (requires login)
                            if (isLoggedIn)
                                CheckBalance(accountService);
                            else
                                Console.WriteLine("Please login first to check balance.");
                            break;

                        case "5":
                            // Deposit money (requires login)
                            if (isLoggedIn)
                                DepositMoney(transactionService);
                            else
                                Console.WriteLine("Please login first to deposit money.");
                            break;

                        case "6":
                            // Withdraw money (requires login)
                            if (isLoggedIn)
                                WithdrawMoney(transactionService);
                            else
                                Console.WriteLine("Please login first to withdraw money.");
                            break;

                        case "7":
                            // View transaction history (requires login)
                            if (isLoggedIn)
                                ViewTransactionHistory(transactionService);
                            else
                                Console.WriteLine("Please login first to view transaction history.");
                            break;

                        case "8":
                            Console.WriteLine("Thank you for using the Console Banking Application. Goodbye!");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please enter a number between 1 and 8.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        // Method to register a new user
        static void RegisterUser(UserService userService)
        {
            Console.WriteLine("\n--- User Registration ---");
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
                Console.WriteLine("Error: All fields are required for registration.");
            }
        }

        // Method for user login
        static string LoginUser(UserService userService)
        {
            Console.WriteLine("\n--- User Login ---");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var user = userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine($"Welcome, {user.FullName}!");
                return user.Username;
            }
            else
            {
                Console.WriteLine("Error: Invalid username or password.");
                return null;
            }
        }

        // Method to open a new account
        static void OpenAccount(AccountService accountService, string username)
        {
            Console.WriteLine("\n--- Open a New Account ---");
            Console.Write("Enter Account Type (Savings/Checking): ");
            string accountType = Console.ReadLine();
            Console.Write("Enter Initial Deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
            {
                accountService.OpenAccount(username, accountType, initialDeposit);
            }
            else
            {
                Console.WriteLine("Error: Invalid deposit amount.");
            }
        }

        // Method to check account balance
        static void CheckBalance(AccountService accountService)
        {
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
                Console.WriteLine("Error: Invalid account number.");
            }
        }

        // Method to deposit money
        static void DepositMoney(TransactionService transactionService)
        {
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.Write("Enter Deposit Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    transactionService.Deposit(accountNumber, amount);
                }
                else
                {
                    Console.WriteLine("Error: Invalid deposit amount.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid account number.");
            }
        }

        // Method to withdraw money
        static void WithdrawMoney(TransactionService transactionService)
        {
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.Write("Enter Withdrawal Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    transactionService.Withdraw(accountNumber, amount);
                }
                else
                {
                    Console.WriteLine("Error: Invalid withdrawal amount.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid account number.");
            }
        }

        // Method to view transaction history
        static void ViewTransactionHistory(TransactionService transactionService)
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
