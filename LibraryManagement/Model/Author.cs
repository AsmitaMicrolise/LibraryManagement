using System.Net;

namespace LibraryManagement.Model
{
    public class Author
    {
        public int Author_Id { get; set; }
        public string Author_Name { get; set; }

        public Author() { }
        public Author(int Author_Id, string Author_Name)
        {
            this.Author_Id = Author_Id;
            this.Author_Name = Author_Name;
        }

        public override string ToString()
        {
            // return $"Author Name: {Author_Name}";
            return Author_Name;
        }
    }
}