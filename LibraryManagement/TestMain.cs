using LibraryManagement.Action;
using LibraryManagement.Collector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryManagement
{
    public class TestMain
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            string welcomeMessage = "*******************************   WELCOME TO LIBRARY SYSTEM     *******************************";
            int leftpadding = (Console.WindowWidth - welcomeMessage.Length) / 2;
            Console.Write("".PadLeft(leftpadding));
            Console.WriteLine(welcomeMessage);

            Console.ResetColor();
            LibrarianActionExecutors action = new LibrarianActionExecutors();
           int choice;
           

            do {

                Console.WriteLine("\n\n************************************************");
                Console.WriteLine("1: Login As Student.");
                Console.WriteLine("2: Login As FrontDeskOperator.");
                Console.WriteLine("3: Login As Librarian.");
                Console.WriteLine("0: EXIT");
                Console.WriteLine("***************************************************");
                Console.WriteLine("Enter your choice:");
                choice = Int32.Parse(Console.ReadLine());
               
                Console.WriteLine("------------------------\n\n");

                switch (choice)
                {
                    case 1:
                        {
                            string message = "You are logged in as Student!";
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine($"{message}");
                            Console.ResetColor();
                            StudentLogin studentLogin = new StudentLogin();
                            studentLogin.ActionMenu();
                            break;
                        }

                    case 2:
                        {
                             string message = "You are logged in as Front-desk Operator!";
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine($"{message}");
                            Console.ResetColor();
                            FrontDeskOperatorLogin frontDeskOperatorlogin = new FrontDeskOperatorLogin();
                            frontDeskOperatorlogin.ActionMenu();
                           
                            break;
                        }
                    case 3:
                        {
                             string message = "You are logged in as Librarian!";
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine($"{message}");
                            Console.ResetColor();
                            LibrarianLogin librarianLogin = new LibrarianLogin();
                            librarianLogin.ActionMenu();
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }


            } while (choice!=0);
           
           
            
            
            
            
            
            

        }
       
    }
}
