using LibraryManagement.Action;
using LibraryManagement.Collector;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ActionExecutors
{
    public class FrontDeskOperatorActionExecutor
    {
        LibrarySystem system = new LibrarySystem();
        LibrarianActionExecutors actionExecutors = new LibrarianActionExecutors();

        public void IssueBookAction()
        {
            
          
            StudentDataCollector collector = new StudentDataCollector();
            int Student_Id = collector.RemoveStudentCollector();
        
            BookDataCollector collector2 = new BookDataCollector();  
            int Book_ID = collector2.GetBookId();
          
            bool IssuedBook =  system.IssueBook(system.GetBookByID(Book_ID),system.GetStudentByID(Student_Id));
            actionExecutors.RemoveBookCopyAction();

            if(IssuedBook)
            {
                Console.WriteLine("Book Issued");
            }
            else
            {
                Console.WriteLine("Unable to Issue book");
            }
        }

        public void ReturnBookAction()
        {
           
            BookDataCollector collector2 = new BookDataCollector();
            int Book_ID = collector2.GetBookId();
            actionExecutors.AddBookCopyAction();

            bool ReturnBook = system.ReturnBook(Book_ID);
            if (ReturnBook)
            {
                Console.WriteLine("Book Returned");
            }
            else
            {
                Console.WriteLine("Unable to return book");
            }

        }
        
    }
}
