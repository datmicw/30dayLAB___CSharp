//Day 5: Manage Students
//Task:
//Create a class Student with properties ID, Name, and Grades.
//• Calculate the average score of each student.
//• Find the student with the highest and lowest average scores.
//• Algorithm: Iterate through the list and compare values.
namespace _30dayLAB___CSharp.Day5_Manage_Students
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<float> Grade { get; set; } // List of grades
    }
}