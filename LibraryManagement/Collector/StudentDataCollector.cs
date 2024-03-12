using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Collector
{
    public class StudentDataCollector
    {
        public int Student_id;
        public string Student_Name;

        public Student StudentData()
        {
            

            Console.WriteLine("Enter Student Id:");
            Student_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            Student_Name = Console.ReadLine();


            return new Student(Student_id, Student_Name);
        }

        public int RemoveStudentCollector()
        {
            Console.WriteLine("Enter StudentId :");
            Student_id = Int32.Parse(Console.ReadLine());
            return Student_id;
        }

       

       
    }
}
