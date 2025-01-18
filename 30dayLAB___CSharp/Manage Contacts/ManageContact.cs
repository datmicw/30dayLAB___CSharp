using _30dayLAB___CSharp.saveNload;
using System;
using System.Collections.Generic;
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

        public void LoadContactsFromFile()
        {
            string fileData = FileManage.LoadFromFile(baseURL);
            string[] lines = fileData.Split('\n');
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] contactData = line.Split(',');
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
            }
        }

        public void SaveContactsToFile()
        {
            FileManage.SaveToFile(baseURL, ContactsToString());
        }
        internal string ContactsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var contact in Contacts)
            {
                sb.AppendLine($"ID: {contact.ID}, Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
            }
            return sb.ToString();
        }
        public void AddContact()
        {
            Console.WriteLine("=== ADD NEW CONTACT ===: ");
            Contact contact = new Contact();
            Console.WriteLine("Enter ID:");
            contact.ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Enter Phone: ");
            contact.Phone = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            contact.Address = Console.ReadLine();

            Contacts.Add(contact);
            Console.WriteLine("Contact added successfully!");
            SaveContactsToFile(); 
        }

        public void ShowContact()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }
            string contactsData = FileManage.LoadFromFile(baseURL);
            Console.WriteLine("Contacts from file:\n" + contactsData);
        }

        // Cập nhật contact
        public void UpdateContact()
        {
            Console.WriteLine("=== UPDATE CONTACT ===: ");
            Console.WriteLine("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return;
            }
            Contact contact = Contacts.Find(c => c.ID == id);
            if (contact != null)
            {
                Console.WriteLine("Enter Name: ");
                contact.Name = Console.ReadLine();
                Console.WriteLine("Enter Phone: ");
                contact.Phone = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                contact.Email = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                contact.Address = Console.ReadLine();
                Console.WriteLine("Contact updated successfully!");
                SaveContactsToFile(); 
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
        }
        public void DeleteContact()
        {
            int id;
            Console.WriteLine("Enter ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return;
            }
            Contact contact = Contacts.Find(c => c.ID == id);
            if (contact != null)
            {
                Contacts.Remove(contact);
                Console.WriteLine("Contact deleted successfully!");
                SaveContactsToFile();
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
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
            int index = LinearSearch(Contacts, id);
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
        private int LinearSearch(List<Contact> contacts, int searchId)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].ID == searchId)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}


