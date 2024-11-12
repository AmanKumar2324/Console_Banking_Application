using System;
using Console_Banking_Application.Services;

namespace Console_Banking_Application.Menus
{
    public class LoginMenu
    {
        public static string LoginUser(UserService userService)
        {
            Console.WriteLine("\n--- User Login ---\n");
            // Get username
            string username;
            while (true)
            {
                Console.Write("Enter Username (or type 'back' to return to main menu): ");
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

            // Get password
            string password;
            while (true)
            {
                Console.Write("Enter Password (or type 'back' to return to main menu): ");
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

            // Attempt login
            var user = userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine("Logged In successfully!");
                Console.WriteLine($"Welcome, {user.FullName}!");
                return user.Username;
            }
            else
            {
                Console.WriteLine("Error: Invalid username or password.");
                return null;
            }
        }
    }
}
