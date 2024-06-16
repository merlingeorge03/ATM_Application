using System;
using System.Collections.Generic;

namespace ATM_Application
{
    internal class Account
    {
        private string _accHolderName;
        private int _accNo;
        private float _annualIntrRate;
        private float _balance;
        private List<string> transactions = new List<string>();

        //Initiallize user values using constructor
        public Account(string accHolderName, int accno, float annualIntrRate, float initialBalance)
        {
            _accHolderName = accHolderName;
            _accNo = accno;
            _annualIntrRate = annualIntrRate;
            _balance = initialBalance;
            transactions.Add($"Initial balance: {initialBalance:C}");
        }

        //Modify the balance amount and transaction details when user opts for deposit amount
        public float Deposit(float amount)
        {
            _balance += amount;
            transactions.Add($"Deposited: {amount}");
            return _balance;
        }

        //To get the account holder name 
        public string GetAccountHolderName()
        {
            return _accHolderName;
        }

        //To get the Account number
        public int GetAccountNumber()
        {
            return _accNo;
        }

        //To get the Annual Interest Rate 
        public float GetAnnualInterestRate()
        {
            return _annualIntrRate;
        }

        //To get the balance amount in account
        public float GetBalance()
        {
            return _balance;
        }

        //To get the monthly Interest
        public float GetMonthlyInterest()
        {
            return _balance * (_annualIntrRate / 12 / 100);
        }

        //To get monthly interest rate
        public float GetMonthlyInterestRate()
        {
            return _annualIntrRate / 12;
        }


        public void SetAnnualInterestRate(float annualIntrRate)
        {
            _annualIntrRate = annualIntrRate;
        }

        // Modify the balance amount and transaction details when user opts to withdraw amount
        public float Withdraw(float amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;
                transactions.Add($"Withdrew: {amount}");
                return _balance;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return _balance;
            }
        }

        //Get the list of transactions
        public List<string> GetTransactions()
        {
            return transactions;
        }
    }
}
