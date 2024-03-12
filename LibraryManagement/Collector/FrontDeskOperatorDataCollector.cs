using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Collector
{
    public class FrontDeskOperatorDataCollector
    {
        public void IssueBookDataCollector()
        {
            Console.WriteLine("Enter the student ID:");
            int Student_id = Int32.Parse(Console.ReadLine());   
        }
    }
}
