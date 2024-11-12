using Console_Banking_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application.Services
{
    public class UserService
    {
        // In-memory list to store users
        private List<User> users = new List<User>();
        private int nextUserId = 1; // To auto-increment User IDs

        // Method to register a new user
        public bool RegisterUser(string username, string password, string fullName)
        {
            // Check if the username already exists
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username already exists. Please try a different one.");
                return false;
            }

            // Create a new User object
            var newUser = new User(nextUserId++, username, password, fullName);

            // Add the user to the list
            users.Add(newUser);
            Console.WriteLine("Registration successful!");
            return true;
        }

        // Method to authenticate user login
        public User Login(string username, string password)
        {
            // Find user by username and password
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("ERROR: Invalid username or password.");
                return null;
            }

            //Console.WriteLine($"Welcome, {user.FullName}!");
            return user;
        }

        // Optional: Method to display all registered users (for debugging)
        public void DisplayAllUsers()
        {
            Console.WriteLine("Registered Users:");
            foreach (var user in users)
            {
                user.DisplayUserInfo();
                Console.WriteLine("---------------");
            }
        }
    }
}
