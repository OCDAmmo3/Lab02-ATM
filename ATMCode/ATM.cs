using System;
using System.Collections.Generic;
using System.Text;

namespace ATMCode
{
    public class ATM
    {
        static public decimal Balance = 10.00m;
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
            Console.WriteLine("Do things");
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal number)
        {
            return number;
        }
    }
}
