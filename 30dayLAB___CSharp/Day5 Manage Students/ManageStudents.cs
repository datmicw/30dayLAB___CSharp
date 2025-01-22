

using _30dayLAB___CSharp.Day3_Banking_System;
using _30dayLAB___CSharp.saveNload;
using System.Text;

namespace _30dayLAB___CSharp.Day5_Manage_Students
{
    internal class ManageStudents
    {
        List<Student> students = new List<Student>();
        private string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day5_StudentManage.txt";
        public ManageStudents()
        {
            students = new List<Student>();
            LoadFromFile();
        }
        private void SaveToFile() => FileManage.SaveToFile(baseURL, StudentToString());
        private void LoadFromFile()
        {
            if (!File.Exists(baseURL))
            {
                Console.WriteLine("Data file not found. Starting with an empty list.");
                return;
            }
            students = new List<Student>();
            string fileData = FileManage.LoadFromFile(baseURL);
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("No student data found.");
                return;
            }
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] studentData = line.Split('|');
                if (studentData.Length < 3)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }
                try
                {
                    Student student = new Student
                    {
                        ID = int.Parse(studentData[0].Split(':')[1].Trim()),
                        Name = studentData[1].Split(':')[1].Trim(),
                        Grade = studentData[2].Split(':')[1].Trim().Split(',').Select(float.Parse).ToList()
                    };
                    students.Add(student);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing student data: {ex.Message}");
                }
            }
        }

        private string StudentToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var student in students)
            {
                sb.AppendLine($"ID:{student.ID} | Name:{student.Name} | Grades:{string.Join(",", student.Grade)}");
            }
            return sb.ToString();
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Grades (separated by comma): ");
            string[] grades = Console.ReadLine().Split(',');
            List<float> grade = new List<float>();
            foreach (var g in grades)
            {
                grade.Add(float.Parse(g));
            }
            Student student = new Student
            {
                ID = id,
                Name = name,
                Grade = grade
            };
            students.Add(student);
            Console.WriteLine("Student added successfully.");
            SaveToFile();
        }
        public void ShowInfor()
        {
            LoadFromFile();
            foreach (var student in students)
            {
                Console.WriteLine($"ID:{student.ID} | Name:{student.Name} | Grades:{string.Join(",", student.Grade)}");
            }
        }
        public double AverageGrande()
        {
            Console.WriteLine("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
                return 0;
            }

            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                Console.ReadKey();
                return 0;
            }
            if (student.Grade.Count == 0)
            {
                Console.WriteLine("Student has no grades.");
                Console.ReadKey();
                return 0;
            }
            double average = student.Grade.Average();
            Console.WriteLine($"The average grade for student {student.Name} (ID: {student.ID}) is {average:F2}");
            Console.ReadKey();
            return average;
        }

    }
}