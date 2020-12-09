using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfOOP
{
    class Bank<T>
    {
        private List<string> usernameList = new List<string>();
        private List<string> passwordList = new List<string>();
        private List<User> accountList = new List<User>();
        private List<T> transactions = new List<T>();

        public int aReference { get; set; }
        public void SetAccountList(User user)
        {
            accountList.Add(user);
        }
        public List<User> GetAccountList()
        {
            return accountList;
        }
        public void SetUsernameList(string customerName)
        {
            usernameList.Add(customerName);
        }
        public List<string> GetUsernameList()
        { 
            return usernameList; 
        }
        public void SetPasswordList(string customerPW)
        {
            passwordList.Add(customerPW);
        }
        public List<string> GetPasswordList() 
        { 
            return passwordList; 
        }
        public void AddAccount(User account)
        {
            AccountList.Add(account);
        }
    //creates a list of transactions
        public List<User> AccountList { get; }
    //---DEPOSIT METHOD------------------------------------------------------------  
        private User.DoTransaction invoke;
        public void Deposit(Enums.AccountType AccountType, T money, User client)
        {
            invoke = client.ChangeUserBalance;
            transactions.Add(money);
            if (AccountType is Enums.AccountType.Savings)
            {
                invoke(AccountType, decimal.Parse(money.ToString()));
            }
            else if (AccountType is Enums.AccountType.Checking)
            {
                invoke(AccountType, decimal.Parse(money.ToString()));
            }
        }
//  returns a string to be displayed by Main()
        public string ToString(User CurrentAccount)
        {
            string message = "";
            string changeMessage = "";
            decimal dchange = 0;

            foreach (T i in transactions)
            {
                dchange += decimal.Parse(i.ToString());      
            }
            if (dchange < 0)
            {
                changeMessage += "Total change to your account  ($" + (dchange * -1) + ")";
            }
            else
            {
                changeMessage += "Total change to your account  $" + dchange;
            }
            message += (changeMessage + "\n");
            if (CurrentAccount.Checking >= 0)
            {
                message += ("Your current Checking balance is $" + CurrentAccount.Checking + "\n");
            }
            else
            {
                message += ("Your current Checking balance is ($" + (CurrentAccount.Checking * -1) + ")\n");
            }
            if (CurrentAccount.Savings >= 0)
            {
                message += ("Your current Savings balance is $" + CurrentAccount.Savings + "\n");
            }
            else
            {
                message += ("Your current Savings banlance is ($" + (CurrentAccount.Savings * -1) + ")\n");
            }
        //Builds transactions list and adds to return string----------
            foreach (T monies in transactions)
            {
                if (decimal.Parse(monies.ToString()) >= 0)
                {
                    message += ("Deposit:\t$" + monies + "\n");
                }
                else
                {
                    message += ("Withdrawl:\t$" + (decimal.Parse(monies.ToString()) * -1) + "\n");
                }
            }
            transactions.Clear();
            return message;
        }
        

    }
}
