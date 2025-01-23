﻿
namespace _30dayLAB___CSharp.Day7_User_Login_System
{
    internal class Account
    {
        List<User> accounts = new List<User>();
        public Account()
        {
            accounts = new List<User>();
        }
        private static class Messages
        {
            public const string AccountNotFound = "Account not found.";
        }
        public void Register()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            if (accounts.Find(x => x.Username == username) != null)
            {
                Console.WriteLine("Username already exists.");
                return;
            }
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username or Password cannot be empty.");
                return;
            }
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters.");
                return;
            }
            accounts.Add(new User
            {
                Username = username,
                Password = password
            });
            Console.WriteLine("Account created successfully.");
        }
    }
}
            