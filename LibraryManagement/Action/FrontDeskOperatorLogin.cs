using LibraryManagement.ActionExecutors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Action
{
    public class FrontDeskOperatorLogin
    {
        int selectedChoice;

        public void ActionMenu()
        {
            FrontDeskOperatorActionExecutor frontDeskOperatorActionExecutor = new FrontDeskOperatorActionExecutor();
            do
            {
                Console.WriteLine("1: Issue Book");
                Console.WriteLine("2: Return Book");
                Console.WriteLine("0: Exit");
                Console.WriteLine("Enter your choice:");
                selectedChoice = Int32.Parse(Console.ReadLine());   
                switch(selectedChoice) {
                    case 1:
                        {
                           
                            frontDeskOperatorActionExecutor.IssueBookAction();
                            break;
                        }
                    case 2:
                        {
                            frontDeskOperatorActionExecutor.ReturnBookAction();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input!");
                            break;
                        }
                
                
                
                }
                    

            } while (selectedChoice != 0);

        }
    }
        
}
