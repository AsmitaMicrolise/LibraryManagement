using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model

{
    public class Student
    {
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }


        public Student(int Student_ID, string Student_Name)
        {
            this.Student_ID = Student_ID;
            this.Student_Name = Student_Name;


        }
    }
}
