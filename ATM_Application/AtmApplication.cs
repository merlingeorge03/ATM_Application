using System;

namespace ATM_Application
{
    internal class AtmApplication
    {
        public void displayMainMenu()
        {
            int choice;
            string exitChoice;
            
            do
            {
                Console.WriteLine("============= ATM MAIN MENU =============");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit Application");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //createAccount
                        break;
                    case 2:
                        //selectAccount
                        break;
                    case 3:
                        //ExitApplication
                        Console.WriteLine("Do you want to exit? (y/n)");
                        exitChoice = Console.ReadLine().ToLower();
                        if (exitChoice == "y")
                        {
                            Console.WriteLine("THANK YOU FOR CHOOSING THE ATM APPLICATION !!");
                        }
                        else 
                        {
                            if (exitChoice != "n")
                            {
                                Console.WriteLine("Press y to exit and n to continue operations");
                              
                            }
                            displayMainMenu();     
                        
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option, Please try again !!");
                        break;

                }
            } while (choice != 3);
        }

        public void createAccount()
        {

        }
        public void selectAccount()
        {

        }
    }
}