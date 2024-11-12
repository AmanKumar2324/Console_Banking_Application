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

        // METHOD TO REGISTER A NEW USER
        static void RegisterUser(UserService userService)
        {
            Console.WriteLine("\n--- User Registration ---\n");
            // Get full name
            string fullName;
            while (true)
            {
                Console.Write("Enter Full Name (or type 'back' to return to main menu): ");
                fullName = Console.ReadLine();
                if (fullName.ToLower() == "back")
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.WriteLine("Error: Full Name cannot be empty. Please enter a valid Full Name.");
                }
                else
                {
                    break;
                }
            }
            // Get username
            string username;
            while (true)
            {
                Console.Write("Enter Username (or type 'back' to return to main menu): ");
                username = Console.ReadLine();
                if (username.ToLower() == "back")
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Error: Username cannot be empty. Please enter a valid Username.");
                }
                else
                {
                    break;
                }
            }
            // Get password
            string password;
            while (true)
            {
                Console.Write("Enter Password (or type 'back' to return to main menu): ");
                password = Console.ReadLine();
                if (password.ToLower() == "back")
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Error: Password cannot be empty. Please enter a valid Password.");
                }
                else
                {
                    break;
                }
            }
            // Once all fields are validated, calling the RegisterUser method
            userService.RegisterUser(username, password, fullName);
        }




        // METHOD FOR USER LOGIN
        static string LoginUser(UserService userService)
        {
            Console.WriteLine("\n--- User Login ---\n");
            // Get username and ensuring it's not empty
            string username;
            while (true)
            {
                Console.Write("Enter Username (or type 'back' to return to the main menu): ");
                username = Console.ReadLine();
                if (username.ToLower() == "back")
                {
                    return null;
                }
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Error: Username cannot be empty. Please enter a valid Username.");
                }
                else
                {
                    break;
                }
            }
            string password;
            while (true)
            {
                Console.Write("Enter Password (or type 'back' to return to the main menu): ");
                password = Console.ReadLine();
                if (password.ToLower() == "back")
                {
                    return null;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Error: Password cannot be empty. Please enter a valid Password.");
                }
                else
                {
                    break;
                }
            }
            // After both fields are validated, attempt login
            var user = userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine($"User '{user.Username}' successfully logged in.");
                Console.WriteLine($"Welcome, {user.FullName}!");
                return user.Username;
            }
            else
            {
                return null;
            }
        }



        // METHOD TO OPEN A NEW ACCOUNT
        static void OpenAccount(AccountService accountService, string username)
        {
            Console.WriteLine("\n--- Open a New Account ---");
            // Get account type and ensure it's valid (either "Savings" or "Checking")
            string accountType;
            while (true)
            {
                Console.Write("Enter Account Type 'Savings'/'Checking' (or type 'back' to return to the main menu) : ");
                accountType = Console.ReadLine();
                if (accountType.ToLower() == "back")
                {
                    return;
                }
                // Check if the account type is valid
                if (accountType.Equals("Savings", StringComparison.OrdinalIgnoreCase) ||
                    accountType.Equals("Checking", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid account type. Please enter either 'Savings' or 'Checking'.");
                }
            }
            // Get initial deposit amount after valid account type is entered
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
                    Console.WriteLine("Error: Invalid deposit amount. Please enter a valid number greater than or equal to 0.");
                }
            }
            // Now, after both account type and initial deposit are validated, open the account
            accountService.OpenAccount(username, accountType, initialDeposit);
        }



        // METHOD TO CHECK THE ACCOUNT BALANCE
        static void CheckBalance(AccountService accountService)
        {
            Console.WriteLine("\n--- Check Account Balance ---");
            while (true)
            {
                Console.Write("Enter Account Number (or type 'back' to return to the main menu): ");
                string input = Console.ReadLine();

                // Check if user wants to go back to the main menu
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
                        return; // Exit the loop after displaying the balance
                    }
                }
                else
                {
                    // Error message for invalid input
                    Console.WriteLine("Error: Invalid account number. Please enter a valid account number.");
                }
            }
        }


        // Method to deposit money
        static void DepositMoney(TransactionService transactionService)
        {
            Console.WriteLine("\n--- Deposit Amount ---\n");
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
