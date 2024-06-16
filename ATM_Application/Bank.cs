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

        public Account GetAccount(int accountNumber)
        {
            return _accountList.FirstOrDefault(account => account.GetAccountNumber() == accountNumber);
        }

        public Account GetAccount(string clientName)
        {
            return _accountList.FirstOrDefault(account => account.GetAccountHolderName() == clientName);
        }

        public void AddAccount(Account account)
        {
            _accountList.Add(account);
        }

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
