

using _30dayLAB___CSharp.saveNload;
using System.Text;

namespace _30dayLAB___CSharp.Day5_Manage_Students
{
    internal class ManageStudents
    {
        List<Student> students = new List<Student>();
        private string baseURL = "C:\\Users\\datmi\\OneDrive\\Documents\\Coder\\30dayLAB___CSharp\\30dayLAB___CSharp\\Data\\Day4_StudentManage.txt";
        public ManageStudents()
        {
            students = new List<Student>();
        }
        private void SaveToFile() => FileManage.SaveToFile(baseURL, StudentToString());
        private void LoadFromFile()
        {

        }

        private string StudentToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var student in students)
            {
                sb.AppendLine($"ID: {student.ID}");
                sb.AppendLine($"Name: {student.Name}");
                sb.AppendLine($"Grades: {string.Join(",", student.Grade)}");
            }
            return sb.ToString();
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
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
    }
}