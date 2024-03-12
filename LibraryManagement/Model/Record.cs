using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class Record
    {
        public int IssueId { get; set; }
        public Book book { get; set; }
        public Student student { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime Return_Date { get; set; }
    }
}
