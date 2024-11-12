using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Banking_Application.Models
{
    public class User
    {
        // Properties
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        // Constructor
        public User(int userId, string username, string password, string fullName)
        {
            UserId = userId;
            Username = username;
            Password = password;
            FullName = fullName;
        }

        // Method to display user details (optional)
        public void DisplayUserInfo()
        {
            Console.WriteLine($"User ID: {UserId}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Full Name: {FullName}");
        }
    }
}
