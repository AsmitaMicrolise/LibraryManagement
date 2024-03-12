using LibraryManagement.ActionExecutors;
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
    public class FrontDeskOperatorTest
    {
      
       
        [TestMethod]
        public void TestReturnBook()
        {
            LibrarySystem librarySystem = new LibrarySystem();

            int book_id = 116;
            bool actual = librarySystem.ReturnBook(book_id);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestIssueBook()
        {
            LibrarySystem librarySystem = new LibrarySystem();

            Book book1 = new Book(118, "Atomic Habits", 6, 4, new List<Author> { new Author(1, "James Clear") });
            Student student1 = new Student(21656, "Asmita");
            bool acual = librarySystem.IssueBook(book1, student1);
            Assert.IsNotNull(acual);

        }
    }
}
