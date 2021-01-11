using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 10000);
            Console.WriteLine($"Accout {account.Number} was created for {account.Owner} with {account.Balance}.\n\n");

            account.MakeWithdrawal(14.750m, DateTime.Now, "Hammock");
            account.MakeWithdrawal(500, DateTime.Now, "PS5");

            Console.WriteLine("\n\nWould you like to see a list of all your transactions?\nEnter 0: No\tor\tEnter 1: Yes");
            var userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 0:
                    Console.WriteLine("Thank you for banking with us");
                    break;
                case 1:
                    Console.WriteLine("\n\n"+account.GetAccountHistory());
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }





            /* TESTS: uncomment all code below once to run tests*/

            ///* Test that the initial balances must be positive */
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch(ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

            ///* Test for a negative balance */
            //try
            //{
            //    account.MakeWithdrawal(75000, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}
        }
    }
}
