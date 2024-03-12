using LibraryManagement.Model;
using LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemTestProject
{
    [TestClass]
    public class StudentActionTest
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void TestSearchBookByAuthorName()
        {
            string Author_Name = "Author1";
            Book book1 = new Book(101, "Book1", 6, 4, new List<Author> { new Author(1, "Author1") });

            List<Book> result = librarySystem.searchBookByAuthorName(Author_Name);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestSearchBookByBookName()
        {
            string title = "Book1";
            int expectedCount = 1;

            Book ExpectedBook = new Book(21656, "Book1", 10, 5, new List<Author> { new Author(101, "Author1") });
            List<Book> result = librarySystem.searchBookByBookName(title);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCount, result.Count());


        }
    }
}
