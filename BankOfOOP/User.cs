using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfOOP
{
    class User
    {
        private string _userName;
        private string _password;
        private string _customer;
        private decimal _checking;
        private decimal _savings;
        public delegate void DoTransaction(Enums.AccountType CheckOrSave, decimal amount);
        public delegate void DefaultTransaction(decimal amount);

        public User(string Username, string Password, string Customer, decimal Checking, decimal Savings)
        {
            _userName = Username;
            _password = Password;
            _customer = Customer;
            _checking = Checking;
            _savings = Savings;
        }
        public string Username
        {
            get { return _userName; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string Customer
        {
            get { return _customer; }
        }
        public decimal Checking
        {
            get { return _checking; }
        }
        public decimal Savings
        {
            get { return _savings; }
        }
// Balance changing methods;
        public void ChangeUserBalance(Enums.AccountType CheckOrSave, decimal sentFunds)
        {
            ChangeBalance(CheckOrSave, sentFunds);
        }
        private void ChangeBalance(Enums.AccountType aType, decimal funds)
        {
            if (aType is Enums.AccountType.Checking)
            { _checking += funds; }
            else if (aType is Enums.AccountType.Savings)
            { _savings += funds; }
        }
        public void DefaultChangeUserBalance(decimal sentFunds)
        { DefaultChangeBalance(sentFunds); }
        private void DefaultChangeBalance(decimal funds)
        { _checking += funds; }
    }
}
