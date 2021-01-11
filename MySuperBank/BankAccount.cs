using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    class BankAccount
    {
        /* The Properties */
        public string Number { get; }
        public string Owner { get; set; }

        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in allTransactions)
                {
                    balance = balance + transaction.Amount;
                }
                return balance;
            }
        }

        /* The Constructor */
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            accountNumberSeed++;
        }

        /* The Methods */
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);
            Console.WriteLine($"You made a withdrawl, your current balance is {Balance}");
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            /* HEADER */
            report.AppendLine("Date\t\tAmount\t\tNote");
            report.AppendLine("--------------------------------------------------------------");

            foreach (var transaction in allTransactions)
            {
                /* ROWS */
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t\t{transaction.Notes}");
            }

            return report.ToString();
        }



    }
}
