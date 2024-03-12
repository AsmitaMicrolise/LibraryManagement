using LibraryManagement;
using LibraryManagement.ActionExecutors;
using LibraryManagement.Model;
using System.Linq;

namespace LibrarySystemTestProject
{
    [TestClass]
    public class UnitTest1
    {

        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void TestAddStudent()
        {
            Student student = new Student(116,"Asmita Mhetre");
            bool result=librarySystem.AddStudent(student);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            int Student_id = 116;
            bool result = librarySystem.RemoveStudent(Student_id);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveBook()
        {
            int book_id = 21656;
            bool result =librarySystem.RemoveBook(book_id);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestAddBook()
        {
            Author author1 = new Author(101, "James Clear");
            Book book = new Book(21656, "Book1", 11, 5, new List<Author> { author1 });
            bool result = librarySystem.AddBook(book);
            Assert.IsFalse(result);
        }

     
        [TestMethod]
        public void TestRemoveBookCopy()
        {
            Book book1 = new Book(101, "Atomic Habits", 6, 4, new List<Author> { new Author(1, "James Clear") });
            bool removed =librarySystem.RemoveBookCopy(book1);
            Assert.IsTrue(removed);
            

        }
      

        [TestMethod]
        public void TestAddCopy()
        {
            Book book1 = new Book(101, "Atomic Habits", 6, 4, new List<Author> { new Author(1, "James Clear") });
            bool added = librarySystem.AddBookCopy(book1);
            Assert.IsTrue(added);   
            

        }


    }
}