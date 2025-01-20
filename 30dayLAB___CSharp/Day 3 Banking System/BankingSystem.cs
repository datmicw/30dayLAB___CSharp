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
        public void Withdraw()
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
                        decimal balanceData = decimal.Parse(accountData[2].Split(':')[1].Trim()); // lay so du hien tai
                        accountFound = true;
                        decimal withDrawAmount; // so tien rut
                        do // lap lai neu so tien rut > so du hoac so tien rut <= 0
                        {
                            Console.WriteLine("Enter Amount You Want Withdraw: ");
                            withDrawAmount = Convert.ToDecimal(Console.ReadLine()); // nhap so tien rut
                            if (withDrawAmount > balanceData)
                            {
                                Console.WriteLine("Insufficient balance. Try a smaller amount.");
                            }
                            else if (withDrawAmount <= 0)
                            {
                                Console.WriteLine("Invalid amount. Enter a positive number.");
                            }
                        } while (withDrawAmount > balanceData || withDrawAmount <= 0); // lap lai neu so tien rut > so du hoac so tien rut <= 0
                        balanceData -= withDrawAmount;
                        updatedLines.Add($"AccountNumber: {fileAccountNumber}, AccountName: {accountData[1].Split(':')[1].Trim()}, Balance: {balanceData}");
                        Console.WriteLine("Withdraw Successful!");
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
        public void Transfer()
        {
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No accounts found in file.");
                return;
            }

            Console.WriteLine("Enter Sender Account Number: ");
            int senderAccountNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Receiver Account Number: ");
            int receiverAccountNumber = Convert.ToInt32(Console.ReadLine());

            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            bool senderFound = false, receiverFound = false;
            decimal senderBalance = 0, receiverBalance = 0;
            List<string> updatedLines = new List<string>();

            foreach (var line in lines)
            {
                string[] accountData = line.Split(',');

                if (accountData.Length >= 3)
                {
                    int fileAccountNumber = int.Parse(accountData[0].Split(':')[1].Trim());
                    decimal balanceData = decimal.Parse(accountData[2].Split(':')[1].Trim());

                    if (fileAccountNumber == senderAccountNumber)
                    {
                        senderFound = true;
                        senderBalance = balanceData;
                    }
                    else if (fileAccountNumber == receiverAccountNumber)
                    {
                        receiverFound = true;
                        receiverBalance = balanceData;
                    }
                }
            }

            if (!senderFound)
            {
                Console.WriteLine("Sender account not found.");
                return;
            }

            if (!receiverFound)
            {
                Console.WriteLine("Receiver account not found.");
                return;
            }

            Console.WriteLine("Enter Amount You Want to Transfer: ");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

            if (transferAmount <= 0)
            {
                Console.WriteLine("Invalid transfer amount. Enter a positive value.");
                return;
            }

            if (transferAmount > senderBalance)
            {
                Console.WriteLine("Insufficient balance in sender account.");
                return;
            }

            // Update balances
            senderBalance -= transferAmount;
            receiverBalance += transferAmount;

            foreach (var line in lines)
            {
                string[] accountData = line.Split(',');
                int fileAccountNumber = int.Parse(accountData[0].Split(':')[1].Trim());
                decimal balanceData = decimal.Parse(accountData[2].Split(':')[1].Trim());

                if (fileAccountNumber == senderAccountNumber)
                {
                    updatedLines.Add($"AccountNumber: {fileAccountNumber}, AccountName: {accountData[1].Split(':')[1].Trim()}, Balance: {senderBalance}");
                }
                else if (fileAccountNumber == receiverAccountNumber)
                {
                    updatedLines.Add($"AccountNumber: {fileAccountNumber}, AccountName: {accountData[1].Split(':')[1].Trim()}, Balance: {receiverBalance}");
                }
                else
                {
                    updatedLines.Add(line);
                }
            }

            FileManage.SaveToFile(baseURL, string.Join('\n', updatedLines));
            Console.WriteLine("Transfer Successful!");
        }

    }
}

