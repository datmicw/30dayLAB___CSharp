using _30dayLAB___CSharp.saveNload;
using System.Text;

namespace _30dayLAB___CSharp.Manage_Contacts
{
    public class ManageContact
    {
        public string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day1_contacts.txt";
        private List<Contact> Contacts { get; set; }
        public ManageContact()
        {
            Contacts = new List<Contact>();
            LoadContactsFromFile();
        }
        // Load danh bạ từ file
        public void LoadContactsFromFile()
        {
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No contacts found in file. Initializing an empty contact list.");
                return;
            }
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] contactData = line.Split(',');
                if (contactData.Length < 5)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }
                try
                {
                    Contact contact = new Contact
                    {
                        ID = int.Parse(contactData[0].Split(':')[1].Trim()),
                        Name = contactData[1].Split(':')[1].Trim(),
                        Phone = contactData[2].Split(':')[1].Trim(),
                        Email = contactData[3].Split(':')[1].Trim(),
                        Address = contactData[4].Split(':')[1].Trim()
                    };
                    Contacts.Add(contact);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing contact data: {ex.Message}");
                }
            }
        }
        // Lưu danh bạ vào file
        public void SaveContactsToFile()
        {
            FileManage.SaveToFile(baseURL, ContactsToString());
        }

        // Chuyển danh bạ thành string
        private string ContactsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var contact in Contacts)
            {
                sb.AppendLine($"ID: {contact.ID}, Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
            }
            return sb.ToString();
        }

        // Thêm danh bạ mới
        public void AddContact()
        {
            Console.WriteLine("=== ADD NEW CONTACT ===: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                // Kiểm tra trùng ID
                do
                {
                    if (Contacts.Any(c => c.ID == id))
                    {
                        Console.WriteLine("ID already exists. Please enter a different ID.");
                        Console.Write("Enter ID: ");
                        id = int.Parse(Console.ReadLine());
                    }
                } while (Contacts.Any(c => c.ID == id));

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Address: ");
                string address = Console.ReadLine();

                Contacts.Add(new Contact { ID = id, Name = name, Phone = phone, Email = email, Address = address });
                Console.WriteLine("Contact added successfully!");
                SaveContactsToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding contact: {ex.Message}");
            }
        }
        // Hiển thị danh sách danh bạ
        public void ShowContacts()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }
            Console.WriteLine("=== CONTACT LIST ===");
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"ID: {contact.ID}, Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
            }
        }
        // Cập nhật danh bạ
        public void UpdateContact()
        {
            Console.Write("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var contact = Contacts.FirstOrDefault(c => c.ID == id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            Console.Write("Enter new Name: ");
            contact.Name = Console.ReadLine();

            Console.Write("Enter new Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Enter new Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter new Address: ");
            contact.Address = Console.ReadLine();

            Console.WriteLine("Contact updated successfully!");
            SaveContactsToFile();
        }
        // Xóa danh bạ
        public void DeleteContact()
        {
            Console.Write("Enter ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var contact = Contacts.FirstOrDefault(c => c.ID == id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            Contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully!");
            SaveContactsToFile();
        }
        public void SearchContact()
        {
            Console.WriteLine("Enter ID to search: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return;
            }
            int index = LinearSearch(Contacts, id); // tìm kiếm contact theo ID sử dụng Linear Search
            if (index != -1)
            {
                var contact = Contacts[index];
                Console.WriteLine($"ID: {contact.ID}, Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
        }
        // Tìm kiếm contact theo ID sử dụng Linear Search
        private int LinearSearch(List<Contact> contacts, int searchId)
        {
            for (int i = 0; i < contacts.Count; i++) // duyệt từng phần tử trong danh sách contact
            {
                if (contacts[i].ID == searchId) // nếu ID của contact tại vị trí i bằng ID cần tìm
                {
                    return i; // trả về vị trí của contact trong danh sách
                }
            }
            return -1; // trả về -1 nếu không tìm thấy
        }
    }
}