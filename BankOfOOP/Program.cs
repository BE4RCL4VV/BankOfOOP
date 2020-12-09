using System;
using System.Collections.Generic;
using System.Threading;


namespace BankOfOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank<decimal> bank = new Bank<decimal>();
//--User creation  -------------------------------------------------------------------------------
            User efudd = new User("efudd", "efudd1", "Elmer Fudd", 345.00M, 0M);
            bank.SetUsernameList(efudd.Username);
            bank.SetPasswordList(efudd.Password);
            bank.SetAccountList(efudd);
            
            User bbunny = new User("bbunny", "bbunny1", "Bugs Bunny", 1722.12M, 0M);
            bank.SetUsernameList(bbunny.Username);
            bank.SetPasswordList(bbunny.Password);
            bank.SetAccountList(bbunny);
            
            User tbird = new User("tbird", "tbird1", "Tweety Bird", 45.44M, 0M);
            bank.SetUsernameList(tbird.Username);
            bank.SetPasswordList(tbird.Password);
            bank.SetAccountList(tbird);

            decimal depositAmount;
            decimal withdrawAmount;

            string currentCustomer = "";
            Enums.AccountType selectedAccount;
            string input;

//--Initial Menu  -----------------------------------------------------------------------------------
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(L)ogin\t(Q)uit");
                ConsoleKeyInfo keyPress = Console.ReadKey();
//--Login -------------------------------------------------------------------------------------------                
                if (keyPress.Key == ConsoleKey.L)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your username");
                    input = Console.ReadLine();
//--username entry  ---------------------------------------------------------------------------------                    
                    if (bank.GetUsernameList().Contains(input.ToLower())) 
                    {
                        for (int i = 0; i < bank.GetUsernameList().Count; i++)
                        {
                            if (bank.GetUsernameList()[i].Equals(input))
                            {
                                currentCustomer = bank.GetAccountList()[i].Customer;
                                bank.aReference = i;
                            }
                        }
                        Thread.Sleep(500);
                        Console.WriteLine();
//----password entry  --------------------------------------------------------------------------------
                        Console.WriteLine("Please enter your password");
                        input = Console.ReadLine();
                        Thread.Sleep(500);
                        if (bank.GetPasswordList().Contains(input))
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Hello " + currentCustomer);

                                Console.WriteLine("(W)ithdraw\t(D)eposit\t(B)alance\t(L)ogout");
                                Console.WriteLine();
                                keyPress = Console.ReadKey();
                                Console.WriteLine();
//------Deposit --------------------------------------------------------------------------------------
                                if (keyPress.Key == ConsoleKey.D)
                                {
                                    Console.Clear();
                                    Console.WriteLine("(C)hecking\t(S)avings");
                                    keyPress = Console.ReadKey();
                                    Console.Clear();
                                    if (keyPress.Key == ConsoleKey.S)
                                    {
                                        selectedAccount = Enums.AccountType.Savings;
                                        Console.WriteLine("Savings selected");
                                    }
                                    else if (keyPress.Key == ConsoleKey.C)
                                    {
                                        selectedAccount = Enums.AccountType.Checking;
                                        Console.WriteLine("Checking selected");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Checking selected as default");
                                        selectedAccount = Enums.AccountType.Checking;
                                    }
                                    Thread.Sleep(500);
                                    Console.WriteLine("Please enter a Deposit amount: ");
                                    string depositInput = Console.ReadLine();
                //--Deposit method calls----------------------------------------------------                    
                                    if (Decimal.TryParse(depositInput, out depositAmount))
                                    {
                                        if (input.ToLower().Equals("efudd1"))
                                        { bank.Deposit(selectedAccount, depositAmount, efudd); }
                                        else if (input.ToLower().Equals("bbunny1"))
                                        { bank.Deposit(selectedAccount, depositAmount, bbunny); }
                                        else if (input.ToLower().Equals("tbird1"))
                                        { bank.Deposit(selectedAccount, depositAmount, tbird); }
                                    }                                                           
                                    Thread.Sleep(500);
                                }
//-----Withdrawl -----------------------------------------------------------------------------------
                                if (keyPress.Key == ConsoleKey.W)
                                {
                                    Console.Clear();
                                    Console.WriteLine("(C)hecking\t(S)avings");
                                    keyPress = Console.ReadKey();
                                    Console.Clear();                                 
                                    if (keyPress.Key == ConsoleKey.S)
                                    {
                                        selectedAccount = Enums.AccountType.Savings;
                                        Console.WriteLine("Savings selected");
                                    }
                                    else if (keyPress.Key == ConsoleKey.C)
                                    {
                                        selectedAccount = Enums.AccountType.Checking;
                                        Console.WriteLine("Checking selected");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Checking selected as default");
                                        selectedAccount = Enums.AccountType.Checking;
                                    }
                                    Thread.Sleep(500);
                                    Console.WriteLine("Please enter an amount to Withdraw: ");
                                    string withdrawInput = Console.ReadLine();
                        //Deposit method calls---------------
                                    if (Decimal.TryParse(withdrawInput, out withdrawAmount))
                                    {
                                        withdrawAmount *= -1;
                                        if (input.ToLower().Equals("efudd1"))
                                        { bank.Deposit(selectedAccount, withdrawAmount, efudd); }
                                        else if (input.ToLower().Equals("bbunny1"))
                                        { bank.Deposit(selectedAccount, withdrawAmount, bbunny); }
                                        else if (input.ToLower().Equals("tbird1"))
                                        { bank.Deposit(selectedAccount, withdrawAmount, tbird); }
                                    }
                                    Thread.Sleep(1000);
                                }
//-----Balance -------------------------------------------------------------------------------------
                                if (keyPress.Key == ConsoleKey.B)
                                {
                                    Console.Clear();

                                    if (input.ToLower().Equals("efudd1"))
                                    {
                                        if (efudd.Checking >= 0)
                                        { Console.WriteLine("Current checking balance: $" + efudd.Checking); }
                                        else { Console.WriteLine("Current checking balance: ($" + (efudd.Checking * -1) + ")"); }
                                        if (efudd.Savings >= 0)
                                        { Console.WriteLine("Current savings balance: $" + efudd.Savings); }
                                        else { Console.WriteLine("Current savings balance: ($" + (efudd.Savings * -1) + ")"); }
                                    }
                                    else if (input.ToLower().Equals("bbunny1"))
                                    {
                                        if (bbunny.Checking >= 0)
                                        { Console.WriteLine("Current checking balance: $" + bbunny.Checking); }
                                        else { Console.WriteLine("Current checking balance: ($" + (bbunny.Checking * -1) + ")"); }
                                        if (bbunny.Savings >= 0)
                                        { Console.WriteLine("Current savings balance: $" + bbunny.Savings); }
                                        else { Console.WriteLine("Current savings balance: ($" + (bbunny.Savings * -1) + ")"); }
                                    }
                                    else if (input.ToLower().Equals("tbird1"))
                                    {
                                        if (tbird.Checking >= 0)
                                        { Console.WriteLine("Current checking balance: $" + tbird.Checking); }
                                        else { Console.WriteLine("Current checking balance: ($" + (tbird.Checking * -1) + ")"); }
                                        if (tbird.Savings >= 0)
                                        { Console.WriteLine("Current savings balance: $" + tbird.Savings); }
                                        else { Console.WriteLine("Current savings balance: ($" + (tbird.Savings * -1) + ")"); }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                }
//-----Logout  --------------------------------------------------------------------------------------
                                if (keyPress.Key == ConsoleKey.L)
                                {
                                    Console.WriteLine(bank.ToString(bank.GetAccountList()[bank.aReference]));
                                    Console.WriteLine("Good-Bye...\n\nPress Enter to continue");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Password does not match");
                            Thread.Sleep(500);
                        }
                    } 
                    else
                    {
                        Console.WriteLine("Please enter a valid username");
                    }
                }
//------ Quit ---------------------------------------------------------------------------------------
                else if (keyPress.Key == ConsoleKey.Q) {
                    Console.WriteLine();
                    Console.WriteLine("Good-Bye...");
                    Thread.Sleep(2500);
                    break; 
                }
                else {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid choice");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
