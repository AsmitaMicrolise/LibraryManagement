using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Collector
{
    public class AuthorDataCollector
    {
        public List<Author> AuthorData(int CountOfAuthors)
        {
            List<Author> authorList = new List<Author>();
            

            while (true)
            {
                while ( CountOfAuthors!=0)
                {
                    Console.WriteLine("Enter author ID :");
                    int authorId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Enter author name:");
                    string authorName = Console.ReadLine();

                    if (string.IsNullOrEmpty(authorName))
                    {
                        Console.WriteLine("Author name cannot be empty. Please enter a valid name.");
                        continue;
                    }
                    // Create an instance of the Author class with the collected data
                    Author author = new Author { Author_Id = authorId, Author_Name = authorName };
                    // Add the author to the list of authors
                    authorList.Add(author);
                    CountOfAuthors--; ;
                }
                return authorList;
            }
        }
        }
    }