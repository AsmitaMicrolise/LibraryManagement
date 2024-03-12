using LibraryManagement.Collector;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Action
{
    public class LibrarianActionExecutors
    {
        LibrarySystem system = new LibrarySystem();
        BookDataCollector collector = new BookDataCollector();


        public void AddStudentAction()
        {

            StudentDataCollector collector = new StudentDataCollector();
            Student student = collector.StudentData();

            bool addedstudent = system.AddStudent(student);

            if (addedstudent)
            {
                Console.WriteLine("Student Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add student");
            }
        }

        public void AddBookAction()
        {
            Book book = collector.BookData();

            bool addedBook = system.AddBook(book);

            if (addedBook)
            {
                Console.WriteLine("Book Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add Book!");
            }
        }

        public void RemoveStudentAction()
        {
            StudentDataCollector collector = new StudentDataCollector();
            int Student_Id = collector.RemoveStudentCollector();

            bool removedStudent = system.RemoveStudent(Student_Id);
            if (removedStudent)
            {
                Console.WriteLine("Student Removed!");
            }
            else
            {
                Console.WriteLine("Failed to remove Student!");
            }
        }

       public void RemoveBookAction()
        {
            int book_id = collector.GetBookId();
            bool removedBook = system.RemoveBook(book_id);

            if (removedBook)
            {
                
                Console.WriteLine("Book Removed!");
            }
            else
            {
                Console.WriteLine("Failed to remove Book!");
            }
        }

        public void DisplayAllBooksAction()
        {
            List<Book> listOfBook = system.DisplayAllBooks();
            foreach (Book book in listOfBook)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void AddBookCopyAction()
        {
            int book_id =  collector.GetBookId();
            bool AddedCopy = system.AddBookCopy(system.GetBookByID(book_id));
            if (AddedCopy)
            {

                Console.WriteLine("Book Copy Added!");
            }
            else
            {
                Console.WriteLine("Failed to Add Book copy!");
            }
        }
        public void RemoveBookCopyAction()
        {

            int book_id = collector.GetBookId();
            bool removedCopy = system.RemoveBookCopy(system.GetBookByID(book_id));
            if (removedCopy)
            {

                Console.WriteLine("Book Copy removed!");
            }
            else
            {
                Console.WriteLine("Failed to remove Book copy!");
            }
        }


    }
}
