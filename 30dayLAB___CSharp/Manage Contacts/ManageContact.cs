

namespace _30dayLAB___CSharp.Manage_Contacts
{
    public class ManageContact
    {
        private List<Contact> Contacts { get; set; }
        public ManageContact()
        {
            Contacts = new List<Contact>();
        }
        public void AddContact()
        {
            Console.WriteLine("=== ADD NEW CONTACT ===: ");
            Contact contact = new Contact();
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
        }
        public void ShowContact()
        {
            Console.WriteLine($"Name: {Contacts[0].Name}");
            Console.WriteLine($"Phone: {Contacts[0].Phone}");
            Console.WriteLine($"Email: {Contacts[0].Email}");
            Console.WriteLine($"Address: {Contacts[0].Address}");
        }
        public void UpdateContact()
        {
            Console.WriteLine("=== UPDATE CONTACT ===: ");
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Contact contact = Contacts.Find(c => c.Name == name);
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
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
        }
    }
}
