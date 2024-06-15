using System;

namespace ATM_Application
{
    internal class AtmApplication
    {
        public void displayMainMenu()
        {
            int choice;
            Console.WriteLine("========================================= WELCOME TO ATM APPLICATION =========================================");
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;

                }
            } while (choice != 3);
        }
    }
}