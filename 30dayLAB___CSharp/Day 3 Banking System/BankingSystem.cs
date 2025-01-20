using _30dayLAB___CSharp.saveNload;
using System.Text;

namespace _30dayLAB___CSharp.Day_3_Banking_System
{
    internal class BankingSystem
    {
        public string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day3_Banking.txt";
        List<Bank> Banks = new List<Bank>();
        public BankingSystem()
        {
            Banks = new List<Bank>();
            LoadFromFile();
        }
        public void SaveToFile()
        {
            FileManage.SaveToFile(baseURL, BanksToString());
        }
        public void LoadFromFile()
        {
            Banks = new List<Bank>();
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No accounts found in file. Initializing an empty account list.");
                return;
            }
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] accountData = line.Split(',');
                if (accountData.Length < 3)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }
                try
                {
                    Bank bank = new Bank
                    {
                        AccountNumber = int.Parse(accountData[0].Split(':')[1].Trim()),
                        AccountName = accountData[1].Split(':')[1].Trim(),
                        Balance = decimal.Parse(accountData[2].Split(':')[1].Trim())
                    };
                    Banks.Add(bank);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing account data: {ex.Message}");
                }
            }
        }
        private string BanksToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in Banks)
            {
                sb.AppendLine($"AccountNumber: {bank.AccountNumber}, AccountName: {bank.AccountName}, Balance: {bank.Balance}");
            }
            return sb.ToString();
        }
        public void AddAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Account Name: ");
            string accountName = Console.ReadLine();

            Bank bank = new Bank()
            {
                AccountNumber = accountNumber,
                AccountName = accountName,
                Balance = 0
            };
            Banks.Add(bank);
            Console.WriteLine("Account Created Successfully!");
            SaveToFile();
        }
        public void ShowAccount()
        {
            Console.WriteLine("Enter Account Number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No accounts found in file.");
                return;
            }
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            bool accountFound = false;

            foreach (var line in lines)
            {
                string[] accountData = line.Split(',');
                if (accountData.Length >= 3)
                {
                    int fileAccountNumber = int.Parse(accountData[0].Split(':')[1].Trim());
                    if (fileAccountNumber == accountNumber)
                    {
                        Console.WriteLine($"Account Number: {accountData[0].Split(':')[1].Trim()}");
                        Console.WriteLine($"Account Name: {accountData[1].Split(':')[1].Trim()}");
                        Console.WriteLine($"Balance: {accountData[2].Split(':')[1].Trim()}");
                        accountFound = true;
                        break;
                    }
                }
            }
            if (!accountFound)
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void Deposit()
        {
            Console.WriteLine("Enter Account Number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No accounts found in file.");
                return;
            }

            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            bool accountFound = false;
            List<string> updatedLines = new List<string>(); // luu lai cac dong da update

            foreach (var line in lines)
            {
                string[] accountData = line.Split(','); // tach tung dong thanh cac phan tu

                if (accountData.Length >= 3)
                {
                    int fileAccountNumber = int.Parse(accountData[0].Split(':')[1].Trim());

                    if (fileAccountNumber == accountNumber)
                    {
                        accountFound = true;

                        Console.WriteLine("Enter Your Deposit Amount: ");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("Invalid Deposit Amount.");
                            return;
                        }
                        decimal balance = decimal.Parse(accountData[2].Split(':')[1].Trim());
                        balance += depositAmount;
                        updatedLines.Add($"AccountNumber: {fileAccountNumber}, AccountName: {accountData[1].Split(':')[1].Trim()}, Balance: {balance}"); // cap nhat lai so du
                        Console.WriteLine("Deposit Successful!");
                    }
                    else
                    {
                        updatedLines.Add(line); // giu nguyen cac dong khac
                    }
                }
                else
                {
                    updatedLines.Add(line); // giu nguyen cac dong khac
                }
            }
            if (!accountFound)
            {
                Console.WriteLine("Account not found.");
                return;
            }
            FileManage.SaveToFile(baseURL, string.Join('\n', updatedLines));
        }
    }
}
