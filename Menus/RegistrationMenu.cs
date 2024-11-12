using System;
using Console_Banking_Application.Services;
using Console_Banking_Application.Utils;

namespace Console_Banking_Application.Menus
{
    public class RegistrationMenu
    {
        public static void RegisterUser(UserService userService)
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

            // Once all fields are validated, call the RegisterUser method
            userService.RegisterUser(username, password, fullName);
        }
    }
}
