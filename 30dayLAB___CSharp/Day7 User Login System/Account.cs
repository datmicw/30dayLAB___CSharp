
using _30dayLAB___CSharp.saveNload;
using System.Text;

namespace _30dayLAB___CSharp.Day7_User_Login_System
{
    internal class Account
    {
        List<User> accounts = new List<User>();
        private string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day7_User.txt";
        public Account()
        {
            accounts = new List<User>();
            LoadFromFile(); // Load accounts from file
        }
        private void SaveToFile() => FileManage.SaveToFile(baseURL, AccountsToString());
        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(baseURL)) return;
                var lines = File.ReadAllLines(baseURL);
                foreach (var line in lines)
                {
                    var parts = line.Split(','); // Split line by comma
                    if (parts.Length == 2) // Username and Password
                    {
                        string username = parts[0].Split(':')[1];
                        string password = parts[1].Split(':')[1];
                        accounts.Add(new User { Username = username, Password = password });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
        private string AccountsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var account in accounts)
            {
                sb.AppendLine($"Username:{account.Username},Password:{account.Password}");
            }
            return sb.ToString();
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
            SaveToFile();
        }
        public void Login()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            User user = accounts.Find(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                Console.WriteLine("Invalid Username or Password.");
                return;
            }
            Console.WriteLine("Login successful.");
        }
        public void ViewAccounts()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            var account = accounts.Find(x => x.Username == username);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }
            Console.WriteLine($"Username: {account.Username}, Password: {account.Password}");
            
        }
    }
}
            