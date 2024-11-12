using System;
using Console_Banking_Application.Services;
using Console_Banking_Application.Menus;

namespace Console_Banking_Application
{
    class Program
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
                Console.WriteLine("\n--- Banking Application Menu ---\n");
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
                        RegistrationMenu.RegisterUser(userService);
                        break;
                    case "2":
                        loggedInUser = LoginMenu.LoginUser(userService);
                        isLoggedIn = loggedInUser != null;
                        break;
                    case "3":
                        if (isLoggedIn)
                            AccountMenu.OpenAccount(accountService, loggedInUser);
                        else
                            Console.WriteLine("Please login first.");
                        break;
                    case "4":
                        AccountMenu.CheckBalance(accountService);
                        break;
                    case "5":
                        TransactionMenu.DepositMoney(transactionService);
                        break;
                    case "6":
                        TransactionMenu.WithdrawMoney(transactionService);
                        break;
                    case "7":
                        TransactionMenu.ViewTransactionHistory(transactionService);
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select option between 1 and 8.");
                        break;
                }
            }
        }
    }
}
