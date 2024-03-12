using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }

        public int Issued_Copies { get; set; }

        public int Total_copies { get; set; }

        public List<Author> ListOfAuthors { get; set; }


        public Book(int BookID, string Title, int Issued_Copies, int Total_copies, List<Author> ListOfAuthors)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.Issued_Copies = Issued_Copies;
            this.Total_copies = Total_copies;
            this.ListOfAuthors = ListOfAuthors;
        }

        public override string ToString()
        {
            string authors = string.Join(", ", ListOfAuthors.Select(author => author.Author_Name));
            return $"BookID: {BookID}, Title: {Title}, Total Copies: {Total_copies}, Issued Copies: {Issued_Copies}, Authors: {string.Join(", ", ListOfAuthors)}";
        }


    }
}
