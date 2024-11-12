using System;
using Console_Banking_Application.Services;

namespace Console_Banking_Application.Menus
{
    public class LoginMenu
    {
        public static string LoginUser(UserService userService)
        {
            Console.WriteLine("\n--- User Login ---\n");

            // Get username and ensure it's not empty or invalid
            string username;
            while (true)
            {
                Console.Write("Enter Username (or type 'back' to return to the main menu): ");
                username = Console.ReadLine();

                // Allow user to go back to the main menu
                if (username.ToLower() == "back")
                {
                    return null;
                }

                // Validate username
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Error: Username cannot be empty. Please enter a valid Username.");
                }
                else
                {
                    break;
                }
            }

            // Get password and ensure it's not empty or invalid
            string password;
            while (true)
            {
                Console.Write("Enter Password (or type 'back' to return to the main menu): ");
                password = Console.ReadLine();

                // Allow user to go back to the main menu
                if (password.ToLower() == "back")
                {
                    return null;
                }

                // Validate password
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
    }
}
