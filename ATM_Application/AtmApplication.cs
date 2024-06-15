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
                        createAccount();
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
            Console.WriteLine("====== 1. CREATE ACCOUNT MENU =====");
            Console.WriteLine("Enter Account Holder Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Account Number (Account number must be between 100 and 1000)");
            int accountNumber = int.Parse(Console.ReadLine());

            //Default accounts already created from 100 to 110. 
            //Check if the user entered the same account number as default account number
            if (accountNumber >= 100 && accountNumber <= 110)
            {
                Console.WriteLine("This Account Number already exists in the database. Please enter another number");
                Console.WriteLine("Enter Account Number (Account number must be between 110 and 1000)");
                accountNumber = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Annual Interest Rate (Must be less than 3.0%)");
            float interestRate = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Initial Balance");
            float initialBalance = float.Parse(Console.ReadLine());

            // Account class to be called and feed the data

            Console.WriteLine("Account created successfully.");

        }
        public void selectAccount()
        {
            Console.WriteLine("====== 2. SELECT ACCOUNT =======");
            Console.WriteLine("Enter Account Number (Account number must be between 100 and 1000)");
            int accountNumber = int.Parse(Console.ReadLine());

            //if account selected is not null (exists), then do the below actions
            //welcome message to be printed along with the name
            //displayAccountMenu();
        }

        private void DisplayAccountMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("------- ACCOUNT MENU -------");
                Console.WriteLine("Choose from the following options.");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Display Transaction");
                Console.WriteLine("5. Exit Account");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //CheckBalance method to be called
                        break;
                    case 2:
                        //Deposit method to be called 
                        break;
                    case 3:
                        //Withdraw method to be called 
                        break;
                    case 4:
                        //DisplayTransactions method to be called 
                        break;
                    case 5:
                        Console.WriteLine("Exiting Account Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 5);
        }
    }
}