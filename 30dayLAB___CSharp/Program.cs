namespace _30dayLAB___CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            do
            {
                Console.Clear();
                DrawBox("30 Days of C# Practice", ConsoleColor.Green, ConsoleColor.Black);
                Console.WriteLine("  Select a day to work on (1-30):");
                Console.WriteLine("  1. Challenge | Management Contact    | Linear Search");
                Console.WriteLine("  2. Challenge | Sort Products         | Bubble Sort  ");
                Console.WriteLine("  3. Challenge | Banking System        | If/Else      ");
                Console.WriteLine("  4. Challenge | Find Most Frequent    | Dictionary   ");
                Console.WriteLine("  5. Challenge | Student Manage        | Iterate      ");
                Console.WriteLine("  6. Challenge | Decode String         | Stack        ");
                Console.WriteLine("  7. Challenge | User Login System     | Loop         ");
                Console.WriteLine("  9. Challenge | Number Guessing Game  | Loop         ");
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
                case 4:
                    Day4();
                    break;
                case 5:
                    Day5();
                    break;
                case 6:
                    Day6();
                    break;
                case 7:
                    Day7();
                    break;
                case 31:
                    ShowMessage("Exiting program...", ConsoleColor.Green);
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
            Day3_Banking_System.BankingSystem bankingSystem = new Day3_Banking_System.BankingSystem();
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
        private static void Day4()
        {
            while (true)
            {
                Console.Clear();
                DrawBox("Day 4 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Enter Array");
                Console.WriteLine("  2. Back to Main Menu");
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

                        Console.WriteLine("  === Array ===");
                        Console.WriteLine("Nhập các số nguyên, cách nhau bằng dấu cách:");
                        string input = Console.ReadLine();
                        int[] arr = input.Split(' ') // tách chuỗi bằng dấu cách
                             .Select(int.Parse) // chuyển đổi mỗi phần tử thành số nguyên
                             .ToArray();
                        Day4_Find_Most_Frequent_Element.FindElement findElement = new Day4_Find_Most_Frequent_Element.FindElement(arr);
                        break;
                    case 2:
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
        private static void Day5()
        {
            Day5_Manage_Students.ManageStudents studentManager = new Day5_Manage_Students.ManageStudents();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 5 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Add Student");
                Console.WriteLine("  2. Show Student");
                Console.WriteLine("  3. Average Grande");
                Console.WriteLine("  3. Exit to mennu ");
                Console.Write("  Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }
                Console.Clear();
                DrawBox("Day 5 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        studentManager.AddStudent();
                        break;
                    case 2:
                        studentManager.ShowInfor();
                        break;
                    case 3:
                        studentManager.AverageGrande();
                        return;
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
        private static void Day6()
        {
            Day6_Decode_String.DecodeString decode = new Day6_Decode_String.DecodeString();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 6 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Decode String");
                Console.WriteLine("  2. Exit to mennu ");
                Console.Write("  Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }
                Console.Clear();
                DrawBox("Day 6 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        decode.Decode();
                        break;
                    case 2:
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
        private static void Day7()
        {
            Day7_User_Login_System.Account user = new Day7_User_Login_System.Account();
            while (true)
            {
                Console.Clear();
                DrawBox("Day 7 Menu", ConsoleColor.Cyan, ConsoleColor.Black);
                Console.WriteLine("  1. Register Account");
                Console.WriteLine("  2. Login Account");
                Console.WriteLine("  3. View Account");
                Console.Write("  Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    ShowMessage("Invalid option. Please enter a valid number!", ConsoleColor.Red);
                    continue;
                }
                Console.Clear();
                DrawBox("Day 7 Action", ConsoleColor.Magenta, ConsoleColor.Black);
                switch (n)
                {
                    case 1:
                        user.Register();
                        break;
                    case 2:
                        user.Login();
                        break;
                    case 3:
                        user.ViewAccounts();
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
