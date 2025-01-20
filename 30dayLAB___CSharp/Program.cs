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
                DrawBox("30 Days of C# Practice", ConsoleColor.Green, ConsoleColor.Black);
                Console.WriteLine("  Select a day to work on (1-30):");
                Console.WriteLine("  1. Challenge | Management Contact | Linear Search");
                Console.WriteLine("  2. Challenge | Sort Products      | Bubble Sort  ");
                Console.WriteLine("  3. Challenge | Banking System     | If/Else      ");
                Console.WriteLine("  31. Exit");
                Console.Write("  Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }

                if (option == 31)
                {
                    exit = true;
                }
                else
                {
                    ExecuteDay(option);
                    ShowMessage("\nPress any key to return to the main menu...", ConsoleColor.Yellow);
                    Console.ReadKey();
                }
            } while (!exit);
        }

        private static void ExecuteDay(int day)
        {
            Console.Clear();
            DrawBox($"Day {day} Challenge", ConsoleColor.Blue, ConsoleColor.Black);
            switch (day)
            {
                case 1:
                    Day1();
                    break;
                case 2:
                    Day2();
                    break;
                case 3:
                    Day3();
                    break;
                default:
                    ShowMessage("Invalid day. Please select a valid day between 1 and 30.", ConsoleColor.Yellow);
                    break;
            }
        }

        private static void Day2()
        {
            Day2_Sort_Products.SortProducts sortProducts = new Day2_Sort_Products.SortProducts();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 2 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Add Products");
                Console.WriteLine("  2. Show Products");
                Console.WriteLine("  3. Short Products");
                Console.WriteLine("  4. Back to Main Menu");
                Console.Write("  Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }

                Console.Clear();
                DrawBox("Day 2 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        Console.WriteLine("  === Add Product ===");
                        sortProducts.AddProduct();
                        break;
                    case 2:
                        Console.WriteLine("  === Show Product ===");
                        sortProducts.ShowProducts();
                        break;
                    case 3:
                        Console.WriteLine("  === Sort Product ===");
                        sortProducts.BubbleSortAscending();
                        sortProducts.ShowProducts();
                        break;
                    case 4:
                        ShowMessage("Returning to Main Menu...", ConsoleColor.Green);
                        return;
                    default:
                        ShowMessage("Invalid choice. Please try again.", ConsoleColor.Yellow);
                        break;
                }
                ShowMessage("\nPress any key to continue...", ConsoleColor.Yellow);
                Console.ReadKey();
            }
        }

        private static void Day1()
        {
            Manage_Contacts.ManageContact manageContact = new Manage_Contacts.ManageContact();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 1 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Add Contacts");
                Console.WriteLine("  2. Show Contacts");
                Console.WriteLine("  3. Update Contacts");
                Console.WriteLine("  4. Delete Contacts");
                Console.WriteLine("  5. Search Contacts");
                Console.WriteLine("  6. Back to Main Menu");
                Console.Write("  Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }

                Console.Clear();
                DrawBox("Day 1 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        Console.WriteLine("  === Add Contact ===");
                        manageContact.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("  === Show Contacts ===");
                        manageContact.ShowContacts();
                        break;
                    case 3:
                        Console.WriteLine("  === Update Contact ===");
                        manageContact.UpdateContact();
                        break;
                    case 4:
                        Console.WriteLine("  === Delete Contact ===");
                        manageContact.DeleteContact();
                        break;
                    case 5:
                        Console.WriteLine("  === Search Contact ===");
                        manageContact.SearchContact();
                        break;
                    case 6:
                        ShowMessage("Returning to Main Menu...", ConsoleColor.Green);
                        return;
                    default:
                        ShowMessage("Invalid choice. Please try again.", ConsoleColor.Yellow);
                        break;
                }
                ShowMessage("\nPress any key to continue...", ConsoleColor.Yellow);
                Console.ReadKey();
            }
        }
        private static void Day3()
        {
            Day_3_Banking_System.BankingSystem bankingSystem = new Day_3_Banking_System.BankingSystem();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 3 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Add Account");
                Console.WriteLine("  2. Show Account");
                Console.WriteLine("  3. Withdraw");
                Console.WriteLine("  4. Deposit");
                Console.WriteLine("  5. Transfer");
                Console.WriteLine("  6. Back to Main Menu");
                Console.Write("  Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }
                Console.Clear();
                DrawBox("Day 3 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        Console.WriteLine("  === Add Account ===");
                        bankingSystem.AddAccount();
                        break;
                    case 2:
                        Console.WriteLine("  === Show Account ===");
                        bankingSystem.ViewAccount();
                        break;
                    case 3:
                        Console.WriteLine("  === Withdraw ===");
                        bankingSystem.Withdraw();
                        break;
                    case 4:
                        Console.WriteLine("  === Deposit ===");
                        bankingSystem.Deposit();
                        break;
                    case 5:
                        Console.WriteLine("  === Transfer ===");
                        bankingSystem.Transfer();
                        break;
                    case 6:
                        ShowMessage("Returning to Main Menu...", ConsoleColor.Green);
                        return;
                    default:
                        ShowMessage("Invalid choice. Please try again.", ConsoleColor.Yellow);
                        break;
                }
                ShowMessage("\nPress any key to continue...", ConsoleColor.Yellow);
                Console.ReadKey();
            }
        }

        private static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n  {message}");
            Console.ResetColor();
        }

        private static void DrawBox(string title, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            string line = new string('=', title.Length + 8);
            Console.WriteLine(line);
            Console.WriteLine($"=== {title} ===");
            Console.WriteLine(line);

            Console.ResetColor();
        }
    }
}
