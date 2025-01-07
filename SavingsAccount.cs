using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevExamPaper
{
    internal class SavingsAccount : Account
    {
        // Constants
        private const decimal INTEREST_RATE = 0.06M;
        // Constructors
        public SavingsAccount(string firstName, string lastName, decimal balance, DateTime interestDate, string accountNumber)
            : base(firstName, lastName, balance, interestDate, accountNumber) { }
        //methods
        public override void CalculateInterest()
        {
            // Check if interest has been set in previous year
            DateTime allowedDate = DateTime.Now.AddYears(-1);
            if (allowedDate >= InterestDate)
            {
                Balance = Balance + (Balance + INTEREST_RATE);
                InterestDate = DateTime.Now;
            }
        }
    }
}
