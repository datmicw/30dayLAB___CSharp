using _30dayLAB___CSharp.Manage_Contacts;
using _30dayLAB___CSharp.saveNload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30dayLAB___CSharp.Day2_Sort_Products
{
    public class SortProducts
    {
        string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day2_products.txt";
        private List<Products> Products { get; set; }

        public SortProducts()
        {
            Products = new List<Products>();
            LoadContactsFromFile();
        }
        public void AddProduct()
        {
            Console.WriteLine("Enter the number of products: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid number of products. Please enter a positive integer.");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter details for product {i + 1}:");

                Console.Write("Enter the ID of product: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Skipping this product.");
                    continue;
                }

                Console.Write("Enter the Name of product: ");
                string name = Console.ReadLine();

                Console.Write("Enter the Price of product: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
                {
                    Console.WriteLine("Invalid price. Skipping this product.");
                    continue;
                }

                Products.Add(new Products { ID = id, Name = name, Price = price });
                SaveToFile();
            }
        }
        public void ShowProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("=== PRODUCT LIST ===");
            foreach (var product in Products)
            {
                Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price}");
            }
        }
        public void BubbleSortAscending()
        {
            if (Products == null || Products.Count == 0)
            {
                Console.WriteLine("The product list is empty. Nothing to sort.");
                return;
            }
            for (int i = 0; i < Products.Count - 1; i++) // sap xep theo gia tang dan
            {
                for (int j = 0; j < Products.Count - i - 1; j++) // so sanh 2 phan tu ke nhau
                {
                    if (Products[j].Price > Products[j + 1].Price) // sap xep theo gia tang dan
                    {
                        var temp = Products[j]; // doi cho 2 phan tu
                        Products[j] = Products[j + 1]; // doi cho 2 phan tu
                        Products[j + 1] = temp; // doi cho 2 phan tu
                    }
                }
            }
            Console.WriteLine("Products sorted by price (Ascending).");
        }
        public void SaveToFile()
        {
            FileManage.SaveToFile(baseURL, ProductsToString());
        }

        private string ProductsToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var contact in Products)
            {
                sb.AppendLine($"ID: {contact.ID}, Name: {contact.Name}, Price: {contact.Price}");
            }
            return sb.ToString();
        }
        public void LoadContactsFromFile()
        {
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No product found in file. Initializing an empty product list.");
                return;
            }

            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] productData = line.Split(',');
                if (productData.Length < 3)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }

                try
                {
                    Products product = new Products
                    {
                        ID = int.Parse(productData[0].Split(':')[1].Trim()),
                        Name = productData[1].Split(':')[1].Trim(),
                        Price = decimal.Parse(productData[2].Split(':')[1].Trim())
                    };
                    Products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing product data: {ex.Message}");
                }
            }
        }

    }
}
