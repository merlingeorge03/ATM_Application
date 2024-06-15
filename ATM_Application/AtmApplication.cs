using System;

namespace ATM_Application
{
    internal class AtmApplication
    {
        private Bank _bank = new Bank();
        private Account selectedAccount;

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
                        selectAccount();
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
                Console.WriteLine("Account Number already exists. Please enter another Account number");
                accountNumber = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Annual Interest Rate (Must be less than 3.0%)");
            float interestRate= float.Parse(Console.ReadLine());
            if (interestRate > 3)
            {
                Console.WriteLine("Annual Interest Rate must be less than 3.0%)");
            }
            

            Console.WriteLine("Enter Initial Balance");
            float initialBalance = float.Parse(Console.ReadLine());

            Account newAccount = new Account(name, accountNumber, interestRate, initialBalance);
            _bank.AddAccount(newAccount);

            Console.WriteLine("Account created successfully.");

        }
        public void selectAccount()
        {
            Console.WriteLine("====== 2. SELECT ACCOUNT =======");
            Console.WriteLine("Enter Account Number (Account number must be between 100 and 1000)");
            int accountNumber = int.Parse(Console.ReadLine());

            //if account selected is not null (exists), then do the below actions
            //welcome message to be printed along with the name
            selectedAccount = _bank.GetAccount(accountNumber);

            if (selectedAccount != null)
            {
                Console.WriteLine($"----------------------------------------------");
                Console.WriteLine($"Welcome {selectedAccount.GetAccountHolderName()}");
                DisplayAccountMenu();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
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
                        CheckBalance();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        DisplayTransactions();
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

        private void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {selectedAccount.GetBalance()}");
        }

        private void Deposit()
        {
            Console.WriteLine("Enter the amount");
            float amount = float.Parse(Console.ReadLine());
            selectedAccount.Deposit(amount);
            Console.WriteLine("Amount deposited!!");
        }

        private void Withdraw()
        {
            Console.WriteLine("Enter the amount to be withdrawn");
            float amount = float.Parse(Console.ReadLine());
            selectedAccount.Withdraw(amount);
            Console.WriteLine("Amount Withdrawn!!");
        }

        private void DisplayTransactions()
        {
            Console.WriteLine("-------Transaction Summary-------");
            Console.WriteLine($"Account Number: {selectedAccount.GetAccountNumber()}");
            Console.WriteLine($"Account Holder Name: {selectedAccount.GetAccountHolderName()}");
            Console.WriteLine($"Annual Interest Rate: {selectedAccount.GetAnnualInterestRate()}");
            Console.WriteLine($"Account Balance: {selectedAccount.GetBalance()}");
            foreach (var transaction in selectedAccount.GetTransactions())
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}