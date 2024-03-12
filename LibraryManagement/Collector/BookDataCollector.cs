using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Collector
{
    public class BookDataCollector
    {
        public Book BookData()
        {
            Console.WriteLine("Enter book ID:");
            int book_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Total Number of Copies:");
            int Total_Copies = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Issued Copies:");
            int Issued_Copies = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of authors:");
            int CountOfAuhtors = Int32.Parse(Console.ReadLine());

            AuthorDataCollector authorDataCollector = new AuthorDataCollector();
            List<Author> listOfAuthor = authorDataCollector.AuthorData(CountOfAuhtors);

            return new Book(book_id,title,Issued_Copies,Total_Copies,listOfAuthor);

        }

        public int GetBookId()
        {
            Console.WriteLine("Enter book ID  :");
            int book_id = Int32.Parse(Console.ReadLine());

            return book_id;
        }

        public string SearchBookByTitleDataCollector()
        {
            Console.WriteLine("Enter Book Title to search Book:");
            string title = Console.ReadLine();
            return title;
        }

        public string SearchBookByAuthorDataCollector()
        {
            Console.WriteLine("Enter Author Name to Search Book:");
            string authorName = Console.ReadLine();
            return authorName;
        }
    }
}
