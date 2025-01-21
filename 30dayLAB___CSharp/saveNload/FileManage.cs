using System;
using System.IO;
using System.Text;

namespace _30dayLAB___CSharp.saveNload
{
    internal class FileManage
    {
        public static void SaveToFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }
        public static string LoadFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist. Returning empty data.");
                    return string.Empty;
                }
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
