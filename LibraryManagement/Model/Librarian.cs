using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class Librarian
    {
        public int Librarian_ID { get; set; }
        public string Librarian_Name { get; set; }

        public Librarian(int librarian_ID, string librarian_Name)
        {
            Librarian_ID = librarian_ID;
            Librarian_Name = librarian_Name;
        }


    }
}
