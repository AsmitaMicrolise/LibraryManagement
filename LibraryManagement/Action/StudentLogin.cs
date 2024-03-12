using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryManagement.Action
{
    public class StudentLogin
    {

        public void ActionMenu()
        {
            int selectedChoice;
            StudentActionExecutors studentActionExecutors = new StudentActionExecutors();   
            do
            {
                Console.WriteLine("\n1: Search Book By Book Name");
                Console.WriteLine("2: Search Book By Author Name");
                Console.WriteLine("0: Exit");

                Console.WriteLine("Enter Your Choice:");
                selectedChoice = Int32.Parse(Console.ReadLine());
                switch(selectedChoice)
                {
                    case 1:
                        {
                            studentActionExecutors.SearchBookByTitleAction();
                            break;
                        }
                    case 2:
                        {
                            studentActionExecutors.SearchBookByAuthorNameAction();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input!");
                            break;
                            return;
                        }
                }
            } while (selectedChoice!=0);
        }
    }
   /* public enum LoginAction
    {
        STUDENT ("Login As Student",1),
        FRONTDESK ("Front desk operator",2),
        LIBRARIAN ("Librarian",3),
        EXIT ("Exit",4);

        public string displayName;
        public int actionId;

        LoginAction(string displayName, int actionId)
        {

            this.displayName = displayName;
            this.actionId = actionId;   
        }
        public static LoginAction forId(int id)
        {
            for (UserAction action : values())
            {
                if (action.actionId == id) return action;
            }
            return null;
        }

}*/
    }
   
   

