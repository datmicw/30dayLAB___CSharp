using System;

namespace _30dayLAB___CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("=== 30 Days of C# Practice: Main Menu ===");
                Console.WriteLine("Select a day to work on (1-30):");
                Console.WriteLine($"Day 1: Challenge | Management Contact | Linear Search");

                Console.WriteLine("31. Exit");
                Console.Write("Choose an option: ");
                if(!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                if(option == 31)
                {
                    exit = true;
                    continue;
                }
                else
                {
                    ExecuteDay(option);
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            } while (!exit);
        }

        private static void ExecuteDay(int day)
        {
            Console.Clear();
            Console.WriteLine($"=== Day {day} Challenge ===");
            switch (day)
            {
                case 1:
                    Console.WriteLine("Day 1: Manage Contacts");
                    Manage_Contacts.ManageContact manageContact = new Manage_Contacts.ManageContact();
                    manageContact.AddContact();
                    manageContact.ShowContact();
                    manageContact.UpdateContact();
                    manageContact.ShowContact();
                    break;
            }
        }
    }
}