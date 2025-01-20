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
        public static class Messages
        {
            public const string AccountNotFound = "Account not found.";
            public const string InvalidAmount = "Invalid amount.";
            public const string AccountNumber = "Enter Account Number: ";

        }
        private void SaveToFile() => FileManage.SaveToFile(baseURL, BanksToString());

        private void LoadFromFile()
        {
            Banks = new List<Bank>();
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine(Messages.AccountNotFound);
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
        private Bank FindAccountByNumber(int accountNumber) =>  Banks.FirstOrDefault(b => b.AccountNumber == accountNumber);

        public void AddAccount()
        {
            Console.WriteLine(Messages.AccountNumber);
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (Banks.Any(c => c.AccountNumber == accountNumber))
                {
                    Console.WriteLine("ID already exists. Please enter a different ID.");
                    Console.Write("Enter ID: ");
                    accountNumber = int.Parse(Console.ReadLine());
                }
            } while (Banks.Any(c => c.AccountNumber == accountNumber));
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
        public void ViewAccount()
        {
            Console.WriteLine(Messages.AccountNumber);
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            var account = FindAccountByNumber(accountNumber);

            if (account == null)
            {
                Console.WriteLine(Messages.AccountNotFound);
                return;
            }
            Console.WriteLine($"Account Number: {account.AccountNumber}\nAccount Name: {account.AccountName}\nBalance: {account.Balance}");

        }
        public void Deposit()
        {
            Console.WriteLine(Messages.AccountNumber);
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            var account = FindAccountByNumber(accountNumber);

            if (account == null)
            {
                Console.WriteLine(Messages.AccountNotFound);
                return;
            }
            Console.Write("Enter Deposit Amount: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            if(depositAmount <= 0)
            {
                Console.WriteLine(Messages.InvalidAmount);
                return;
            }

            account.Balance += depositAmount;
            Console.WriteLine("Deposit successful!");
            SaveToFile();
        }
        public void Withdraw()
        {
            Console.WriteLine(Messages.AccountNumber);
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            var account = FindAccountByNumber(accountNumber);

            if (account == null)
            {
                Console.WriteLine(Messages.AccountNotFound);
                return;
            }

            Console.Write("Enter Withdraw Amount: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            if (withdrawAmount <= 0 || withdrawAmount > account.Balance)
            {
                Console.WriteLine(Messages.InvalidAmount);
                return;
            }

            account.Balance -= withdrawAmount;
            Console.WriteLine("Withdraw successful!");
            SaveToFile();
        }
        public void Transfer()
        {
            Console.Write("Enter Sender Account Number: ");
            int senderAccountNumber = int.Parse(Console.ReadLine());
            var senderAccount = FindAccountByNumber(senderAccountNumber);

            if (senderAccount == null)
            {
                Console.WriteLine(Messages.AccountNotFound);
                return;
            }

            Console.Write("Enter Receiver Account Number: ");
            int receiverAccountNumber = int.Parse(Console.ReadLine());
            var receiverAccount = FindAccountByNumber(receiverAccountNumber);

            if (receiverAccount == null)
            {
                Console.WriteLine(Messages.AccountNotFound);
                return;
            }

            Console.Write("Enter Transfer Amount: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());

            if (transferAmount <= 0 || transferAmount > senderAccount.Balance)
            {
                Console.WriteLine(Messages.InvalidAmount);
                return;
            }

            senderAccount.Balance -= transferAmount;
            receiverAccount.Balance += transferAmount;

            Console.WriteLine("Transfer successful!");
            SaveToFile();
        }

    }
}

