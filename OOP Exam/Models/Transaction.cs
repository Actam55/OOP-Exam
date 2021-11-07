using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public abstract class Transaction
    {
        public Transaction(User user, decimal amount)
        {
            _id = _nextID;
            _nextID++;
            Date = DateTime.Now;
            Amount = amount;
            User = user;
        }

        private static int _nextID = 1;
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public User User { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public override string ToString()
        {
            return $"{_id} {User} {Amount} {Date.ToLongDateString()}";
        }

        public abstract void Execute();
    }
}
