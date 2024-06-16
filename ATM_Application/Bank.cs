using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_Application
{
    internal class Bank
    {
        private List<Account> _accountList;

        public Bank()
        {
            //Initialize the default accounts (100-110) with the intial deposit 100
            _accountList = new List<Account>();
            for (int i = 100; i < 110; i++)
            {
                // Create default accounts
                _accountList.Add(new Account($"Default User {i}", i, 3, 100));
            }
        }

        //Method to retrieve the account numbers
        public Account GetAccount(int accountNumber)
        {
            return _accountList.FirstOrDefault(account => account.GetAccountNumber() == accountNumber);
        }

        //Method to add created account to the list
        public void AddAccount(Account account)
        {
            _accountList.Add(account);
        }

        //Method to check if the account already exists in the list
        public bool IsAccountNumberUnique(int accountNumber)
        {
            foreach (Account account in _accountList)
            {
                if (account.GetAccountNumber().Equals(accountNumber))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
