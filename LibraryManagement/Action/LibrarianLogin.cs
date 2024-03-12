using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Action
{
    public class LibrarianLogin
    {
        int selectedChoice;
        LibrarianActionExecutors actionExecutors = new LibrarianActionExecutors();

        public void ActionMenu()
        {
            do
            {
                Console.WriteLine("\n1: Add Book");
                Console.WriteLine("2: Add Student");
                Console.WriteLine("3: Remove Book");
                Console.WriteLine("4: Remove Student");
                Console.WriteLine("5: Display All Books");
                Console.WriteLine("6: Add Book Copy");
                Console.WriteLine("7: Remove Book Copy");
                Console.WriteLine("0: Exit");
                Console.WriteLine("Enter your Choice:");
                selectedChoice = Int32.Parse(Console.ReadLine());

                switch (selectedChoice)
                {
                    case 1:
                        {
                            actionExecutors.AddBookAction();
                            break;
                        }
                    case 2:
                        {
                            actionExecutors.AddStudentAction();
                            break;
                        }
                    case 3:
                        {
                            actionExecutors.RemoveBookAction();
                            break;
                        }
                    case 4:
                        {
                            actionExecutors.RemoveStudentAction();
                            break;
                        }
                    case 5:
                        {
                            actionExecutors.DisplayAllBooksAction();
                            break;
                        }
                    case 6:
                        {
                            actionExecutors.AddBookCopyAction();
                            break;
                        }
                    case 7:
                        {
                            actionExecutors.RemoveBookCopyAction();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }

                }



            } while (selectedChoice != 0);
        }
    }
}
