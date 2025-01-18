using _30dayLAB___CSharp.saveNload;
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
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                if (option == 31)
                {
                    exit = true;
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
                    Day1();
                    break;
                default:
                    Console.WriteLine("Invalid day. Please select a valid day between 1 and 30.");
                    break;
            }
        }

        private static void Day1()
        {
            Manage_Contacts.ManageContact manageContact = new Manage_Contacts.ManageContact();
            Console.Clear();
            Console.WriteLine($"Menu Day 1:");
            Console.WriteLine("1. Add Contacts");
            Console.WriteLine("2. Show Contacts");
            Console.WriteLine("3. Update Contacts");
            Console.WriteLine("4. Delete Contacts");
            Console.WriteLine("5. Search Contacts");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid option. Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (n)
            {
                case 1:
                    Console.WriteLine("1. Add Contacts");
                    manageContact.AddContact();
                    break;
                case 2:
                    Console.WriteLine("2. Show Contacts");
                    manageContact.ShowContact();
                    break;
                case 3:
                    Console.WriteLine("3. Update Contacts");
                    manageContact.UpdateContact();
                    break;
                case 4:
                    Console.WriteLine("4. Delete Contacts");
                    manageContact.DeleteContact();
                    break;
                case 5:
                    Console.WriteLine("5. Search Contacts");
                    manageContact.SearchContact();
                    break;
                case 6:
                    Console.WriteLine("Exiting Day 1.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

