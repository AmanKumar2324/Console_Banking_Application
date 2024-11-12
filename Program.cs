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
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Banking Application Menu ---");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
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

                        // Validate inputs
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

                        // Attempt login
                        var user = userService.Login(loginUsername, loginPassword);
                        if (user != null)
                        {
                            Console.WriteLine($"Successfully logged in as {user.FullName}.");
                        }
                        break;

                    case "3":
                        // Exit
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
