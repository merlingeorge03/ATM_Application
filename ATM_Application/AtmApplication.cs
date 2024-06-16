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

            while (true)
            {
                Console.WriteLine("\n============= ATM MAIN MENU =============");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit Application");

                //Checking if the entered option is a valid integer 
                //if yes, then update the value of choice. Else throw error message
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number(1-3).");
                    continue;

                }
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
                            //Message printed when user enters the option 'y'
                            Console.WriteLine("\nTHANK YOU FOR CHOOSING THE ATM APPLICATION !!");
                            return;
                        }
                        else if (exitChoice != "n")
                        {
                            // Message printed if the any letter entered other than 'y' or 'n'
                            Console.WriteLine("Invalid option entered. Please try again !!");

                        }
                        break;
                    default:
                        // Message printed if the option entered is an integer which is more than 3
                        Console.WriteLine("Invalid option, Please try again !!");
                        break;

                }
            }
        }

        public void createAccount()
        {
            int accountNumber;
            float interestRate;
            float initialBalance;

            //ACCOUNT HOLDER NAME
            Console.WriteLine("====== 1. CREATE ACCOUNT MENU =====");
            Console.WriteLine("Enter Account Holder Name");
            string name = Console.ReadLine();
            //condition to check if the entered name is valid
            if ((name != null) && !IsValidName(name))
            {
                Console.WriteLine("Invalid name entered !!! (Special characters, digits or white spaces not allowed.)");
                return;
            }

            //ACCOUNT NUMBER 
            Console.WriteLine("Enter Account Number (Account number must be between 100 and 1000)");
            //Checking if the entered account number is a valid integer  
            if (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.WriteLine("Invalid input. Please enter a number(100-1000).");
                return;
            }
            //checking if the account number entered is within the allowed number limit (100-1000)
            if (accountNumber < 100 || accountNumber > 1000)
            {
                Console.WriteLine("Account number must be between 100 and 1000.");
                return;
            }
            //Checking if the entered account number is already present in the default user list
            if (!_bank.IsAccountNumberUnique(accountNumber))
            {
                Console.WriteLine("Account number already exists.");
                return;
            }

            //ANNUAL INTEREST RATE 
            Console.WriteLine("Enter Annual Interest Rate (Must be less than 3.0%)");

            if (!float.TryParse(Console.ReadLine(), out interestRate) || interestRate > 3.0f)
            {
                Console.WriteLine("Invalid input. Interest rate must be less than or equal to 3%.");
                return;
            }

            //INITIAL BALANCE
            Console.WriteLine("Enter Initial Balance");
            if (!float.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid balance.");
                return;
            }

            //CREATE ACCOUNT
            Account newAccount = new Account(name, accountNumber, interestRate, initialBalance);
            _bank.AddAccount(newAccount);
            Console.WriteLine("Account created successfully.");

        }

        public void selectAccount()
        {
            Console.WriteLine("\n====== 2. SELECT ACCOUNT =======");
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
                Console.WriteLine("Account not found !!!");
            }
        }

        private void DisplayAccountMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n------- ACCOUNT MENU -------");
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
            Console.WriteLine("\n-------Transaction Summary-------");
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

        // Method to check if name entered is valid
        public bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;

        }
    }

}