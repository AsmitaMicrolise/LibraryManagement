using LibraryManagement.Collector;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Action
{
    public class StudentActionExecutors
    {
        BookDataCollector collector = new BookDataCollector();

        public void SearchBookByTitleAction()
        {
            string Title = collector.SearchBookByTitleDataCollector();
            LibrarySystem system = new LibrarySystem();
            List<Book> listOfBook = system.searchBookByBookName(Title);
            foreach (Book book in listOfBook)
            {

                Console.WriteLine(book.ToString());
            }

        }

        public void SearchBookByAuthorNameAction()
        {
            string AuthorName = collector.SearchBookByAuthorDataCollector();
            LibrarySystem system = new LibrarySystem();
            List<Book> listOfBook = system.searchBookByAuthorName(AuthorName);
            foreach (Book book in listOfBook)
            {
                Console.WriteLine(book.ToString());
            }
        }

        
    }

   
}
