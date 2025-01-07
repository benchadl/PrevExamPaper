using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevExamPaper
{
    internal abstract class Account
    {
        #region properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Balance { get; set; }

        public DateTime InterestDate { get; set; }  // Captures date of interset so interest is only added once per year

        #endregion properties 

        #region constructors
        public Account(string firstName, string lastName, decimal balance, DateTime interestDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            InterestDate = interestDate;
                
        }

        public Account()
        {
            
        }

        public Account(string firstName, string lastName) :this(firstName, lastName, 0,DateTime.Now) { }
        #endregion constructors

        #region methods
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount) 
                Balance -= amount;
        }

        public abstract void CalculateInterest();

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
        #endregion methods
    }
}
