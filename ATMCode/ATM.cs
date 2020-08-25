using System;
using System.Collections.Generic;
using System.Text;

namespace ATMCode
{
    public class ATM
    {
        static public decimal Balance = 10.00m;
        static public List<string> transHistory = new List<string>();
        public static void Main(string[] args)
        {
            try
            {
                UserInterface();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UserInterface()
        {
            Console.WriteLine("Hello, welcome to the Automated Teller Machine.");
            Console.WriteLine("What would you like to do?");

            string resume = "1";
            while(resume == "1")
            {
                Console.WriteLine("Press 1 to view your balance, 2 to make a deposit, 3 to make a withdrawal, or 4 to view transaction history.");
                string action = Console.ReadLine();

                string transaction = "";
                if (action == "1")
                {
                    decimal balance = ViewBalance();
                    transaction = $"Viewed balance of {balance}.";
                }
                else if(action == "2")
                {
                    Console.WriteLine("How much would you like to deposit?");
                    string deposit = Console.ReadLine();
                    decimal deposited = Deposit(Convert.ToDecimal(deposit));
                    transaction = $"Deposited {deposit} into your account. Balance became {deposited}.";
                }
                else if(action == "3")
                {
                    Console.WriteLine("How much would you like to withdraw?");
                    string withdrawal = Console.ReadLine();
                    Withdraw(Convert.ToDecimal(withdrawal));
                    decimal withdrawn = ViewBalance();
                    transaction = $"Withdrew {withdrawal} from your account. Balance became {withdrawn}.";
                }
                else if(action == "4")
                {
                    foreach(string trans in transHistory)
                    {
                        Console.WriteLine(trans);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }
                transHistory.Add(transaction);
                Console.WriteLine("Would you like to do something else? If yes, press 1. If no, press return.");
                resume = Console.ReadLine();
            }
            Console.WriteLine("Transaction complete. Thank you, and have a nice day.");
        }

        public static decimal ViewBalance()
        {
            Console.WriteLine("Your balance is {0}.", Balance);
            return Balance;
        }

        public static decimal Withdraw(decimal number)
        {
            if(Balance > number)
            {
                Balance -= number;
                Console.WriteLine("You withdrew {0}. Your new balance is {1}.", number, Balance);
                return number;
            }
            else
            {
                Console.WriteLine("Withdrawal amount larger than current balance. Withdrawal canceled.");
                return 0;
            }
        }

        public static decimal Deposit(decimal number)
        {
            if (number <= 0)
            {
                Console.WriteLine("Deposit amount must be larger than 0. Deposit canceled.");
            }
            else
            {
                Balance += number;
            }
            return ViewBalance();
        }
    }
}
