using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class FrontDeskOperator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FrontDeskOperator(int id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}
