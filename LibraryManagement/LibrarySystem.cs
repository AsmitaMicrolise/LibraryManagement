using LibraryManagement.Collector;
using LibraryManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class LibrarySystem
    {
       

        //implementation to search the book by book name
        public List<Book> searchBookByBookName(string Title)
        {
             List<Book> listofbook =new List<Book>();
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open(); 
                    string checkQuery = "SELECT * FROM BOOK WHERE book_Name = @BookName" ;

                    using (SqlCommand Command = new SqlCommand(checkQuery, connection))
                    {
                        Command.Parameters.AddWithValue("@BookName", Title);
                        using (SqlDataReader reader = Command.ExecuteReader()) 
                        {
                            //int count = (int)Command.ExecuteScalar();
                            //Console.WriteLine("Count!" + count);

                            while (reader.Read())
                            {

                                int BookID = Convert.ToInt32(reader["Book_id"]);
                                string bookName = reader["book_Name"].ToString();
                                int Total_copies = Convert.ToInt32(reader["Total_copies"]);
                                int Issued_Copies = Convert.ToInt32(reader["Issued_Copies"]);
                                List<Author> authorlist = GetAuthorsForBook(BookID);

                                Book book = new Book(BookID, bookName, Total_copies, Issued_Copies, authorlist);

                                listofbook.Add(book);

                            }
                            reader.Close();

                        }    
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search book by Book Name "+ex.Message);
                

            }
            return listofbook;
           
        }
        //implementation to search the book by Author Name
        public List<Book> searchBookByAuthorName(string Author_Name)
        {
            List<Book> listofbook = new List<Book>();
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = @"SELECT B.Book_id, B.book_Name, B.Total_copies, B.Issued_Copies
                             FROM Book_Author BA
                             JOIN Book B ON BA.Book_id = B.Book_id
                             JOIN Author A ON BA.Author_id = A.Author_Id
                             WHERE A.Author_Name = @AuthorName";

                    using (SqlCommand Command = new SqlCommand(query, connection))
                    {
                        Command.Parameters.AddWithValue("@AuthorName", Author_Name);
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            //int count = (int)Command.ExecuteScalar();
                            //Console.WriteLine("Count!" + count);

                            while (reader.Read())
                            {

                                int BookID = Convert.ToInt32(reader["Book_id"]);
                                string bookName = reader["book_Name"].ToString();
                                int Total_copies = Convert.ToInt32(reader["Total_copies"]);
                                int Issued_Copies = Convert.ToInt32(reader["Issued_Copies"]);
                                List<Author> authorlist = GetAuthorsForBook(BookID);

                                Book book = new Book(BookID, bookName, Total_copies, Issued_Copies, authorlist);

                                listofbook.Add(book);

                            }
                            reader.Close();

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search book By Author Name " + ex.Message);


            }
            return listofbook;

        }

        //method to add student from library database
        public bool AddStudent(Student student)
        {
            
            try
            {
                using(SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Student (Student_id,Student_Name) VALUES (@StudentId,@StudentName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId",student.Student_ID);
                        command.Parameters.AddWithValue("@StudentName",student.Student_Name);

                        int rowsAfftected = command.ExecuteNonQuery();
                        if(rowsAfftected > 0) {
                            return true; }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
            return false;    
        }

        //To remove Student
        public bool RemoveStudent(int student_id)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    // Check if the student exists before attempting to delete them
                    string checkQuery = "SELECT COUNT(*) FROM Student WHERE Student_id = @StudentId";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentId", student_id);
                        int count = (int)checkCommand.ExecuteScalar();
                        // If the student exists, proceed with deletion
                        if (count > 0)
                        {
                            string deleteQuery = "DELETE FROM Student WHERE Student_id = @StudentId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@StudentId", student_id);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nStudent with ID " + student_id + " does not exist in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to remove student: " + ex.Message);
            }
            return false;
        }

        public List<Book> DisplayAllBooks()
        {
            List<Book> listofbook = new List<Book>();
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string checkQuery = "SELECT * FROM BOOK";

                    using (SqlCommand Command = new SqlCommand(checkQuery, connection))
                    {
                      
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            //int count = (int)Command.ExecuteScalar();
                            //Console.WriteLine("Count!" + count);

                            while (reader.Read())
                            {

                                int BookID = Convert.ToInt32(reader["Book_id"]);
                                string bookName = reader["book_Name"].ToString();
                                int Total_copies = Convert.ToInt32(reader["Total_copies"]);
                                int Issued_Copies = Convert.ToInt32(reader["Issued_Copies"]);
                                List<Author> authorlist = GetAuthorsForBook(BookID);

                                Book book = new Book(BookID, bookName, Total_copies, Issued_Copies, authorlist);

                                listofbook.Add(book);

                            }
                            reader.Close();

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search book by Book Name " + ex.Message);


            }
            return listofbook;

        }

        //method to Add a book.
        public bool AddBook(Book book)
        {
           
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO BOOK (Book_id,book_Name,Total_copies,Issued_Copies) VALUES (@Book_id,@title,@Total_copies,@Issued_Copies)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Book_id", book.BookID);
                        command.Parameters.AddWithValue("@title", book.Title);
                        command.Parameters.AddWithValue("@Total_copies", book.Total_copies);
                        command.Parameters.AddWithValue("@Issued_Copies", book.Issued_Copies);
                       
                      command.ExecuteNonQuery();
                    }

                  
                    foreach (var author in book.ListOfAuthors)
                    {
                       string AuthorQuery = "INSERT INTO Author(Author_id,Author_Name) VALUES (@Author_id,@Author_Name)";
                        SqlCommand command = new SqlCommand(AuthorQuery, connection);
                        

                            command.Parameters.AddWithValue("@Author_id", author.Author_Id);
                            command.Parameters.AddWithValue("@Author_Name", author.Author_Name); 
                            command.ExecuteNonQuery();     
                    }


                    foreach (Author author in book.ListOfAuthors)
                    {
                        string bookAuthorQuery = "INSERT INTO Book_Author (Book_id,Author_id) VALUES (@Book_id,@Author_id)";
                        SqlCommand command = new SqlCommand(bookAuthorQuery, connection);
                        
                            command.Parameters.AddWithValue("@Book_id", book.BookID);
                            command.Parameters.AddWithValue("@Author_id", author.Author_Id);              
                            command.ExecuteNonQuery();
                        
                    }
                    return true;

                }
                }catch (Exception ex) { 
                    Console.WriteLine("Failed to Add book in database") ;
                    return false;
                }
            }

        //Method to add copies of the book
        public bool AddBookCopy(Book book)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "UPDATE BOOK SET Total_Copies = Total_Copies + 1 WHERE book_id = @book_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@book_id",book.BookID );
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        //method to remove copy of book
        public bool RemoveBookCopy(Book book)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "UPDATE BOOK SET Total_Copies = Total_Copies - 1 WHERE book_id = @book_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@book_id", book.BookID);
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        //method to Issue book
        public bool IssueBook(Book book, Student student)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO library_Records (Issue_id,IssuedDate,Student_id,Book_id,Return_Date) VALUES (@Issue_id,@IssuedDate,@Student_id,@Book_id,NULL)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Issue_id", 1);
                        command.Parameters.AddWithValue("@IssuedDate",DateTime.Now.ToString());
                        command.Parameters.AddWithValue("@Student_id", student.Student_ID);
                        command.Parameters.AddWithValue("@Book_id", book.BookID);
                        

                        command.ExecuteNonQuery();
                       
                    }

                    //SqlCommand UpdateBookQuery = new SqlCommand("UPDATE BOOK SET Issued_Copies = @Issued_Copies Where book_id = @book_id", connection);
                    //UpdateBookQuery.Parameters.Add(new SqlParameter("@Issued_Copies",( book.Issued_Copies) + 1));
                   

                }
               
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          

        }
        //method to return the book
        public bool ReturnBook(int book_id)
        {

            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = "UPDATE library_records SET Return_Date=@Return_Date WHERE book_id = @book_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Return_Date", DateTime.Now.ToString());
                        command.Parameters.AddWithValue("@book_id", book_id);
                        command.ExecuteNonQuery();
                    }
                    //SqlCommand UpdateBookQuery = new SqlCommand("UPDATE BOOK SET Issued_Copies = @Issued_Copies Where book_id = @book_id", connection);
                    //UpdateBookQuery.Parameters.Add(new SqlParameter("@Issued_Copies", (book.Issued_Copies) + 1));


                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        //Method to remove the book
        public bool RemoveBook(int book_id)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    // Check 
                    string checkQuery = "SELECT COUNT(*) FROM BOOK WHERE book_id = @BookId";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@BookId", book_id);
                        int count = (int)checkCommand.ExecuteScalar();
                       
                        if (count > 0)
                        {
                            string deleteQuery = "DELETE FROM BOOK WHERE book_id = @BookId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@BookId", book_id);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book with ID " + book_id + " does not exist in the database!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to remove book: " + ex.Message);
            }
            return false;
        }

        private List<Author> GetAuthorsForBook(int bookId)
        {
            List<Author> listOfauthors = new List<Author>();
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string query = @"SELECT A.Author_Id, A.Author_Name FROM Book_Author BA JOIN Author A ON BA.Author_id = A.Author_ID WHERE BA.Book_id=@BookID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookId", bookId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {


                                int Author_Id = Convert.ToInt32(reader["Author_id"]);
                                string Author_Name = reader["Author_Name"].ToString();
                                Author author = new Author(Author_Id,Author_Name);


                                listOfauthors.Add(author);
                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to fetch authors for book: " + ex.Message);
            }
            return listOfauthors;
        }

        public Student GetStudentByID(int Student_id)
        {
            Student student = null;
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Student WHERE student_id = @Student_id";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@student_id", Student_id);
                        checkCommand.ExecuteNonQuery();
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count == 0)
                        {
                            Console.WriteLine("Student Not found");
                            return null;
                        }
                    }
                    string query = "SELECT * FROM Student";

                    using (SqlCommand checkCommand = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = checkCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int student_id = Convert.ToInt32(reader["Student_id"]);
                                string student_Name = reader["student_Name"].ToString();

                                student = new Student(student_id, student_Name);
                            }
                            reader.Close();
                        }

                    }



                }
            
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Student Not Found"+ex.Message);
            }

            return student;

        }

         public Book GetBookByID(int Book_id)
        {
            Book book = null;
            try
            {
                using (SqlConnection connection = DatabaseConnection.getConnection())
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM BOOK WHERE Book_id = @Book_id";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Book_id", Book_id);
                        checkCommand.ExecuteNonQuery();
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count == 0)
                        {
                            Console.WriteLine("Book Not found");
                            return null;
                        }
                    }
                    string query = "SELECT * FROM BOOK";
                    using (SqlCommand checkCommand = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = checkCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int BookID = Book_id;
                                string bookName = reader["book_Name"].ToString();
                                int Total_copies = Convert.ToInt32(reader["Total_copies"]);
                                int Issued_Copies = Convert.ToInt32(reader["Issued_Copies"]);
                                List<Author> authorlist = GetAuthorsForBook(BookID);

                                book = new Book(BookID, bookName, Total_copies, Issued_Copies, authorlist);

                            }
                            reader.Close();
                        }
                    }
                
                    
                }
               

            }
            catch(Exception ex)
            {
                Console.WriteLine("Book Not Found"+ex.Message);
            }
            return book;


        }
    }
}



