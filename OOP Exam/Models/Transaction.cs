using OOP_Exam.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public abstract class Transaction
    {
        private static int _nextID = 1;
        private int _id;
        private decimal _amount;
        private User _user;
        private DateTime _date;
        public Transaction(User user, decimal amount)
        {
            _id = _nextID;
            _nextID++;
            Date = DateTime.Now;
            Amount = amount;
            User = user;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }
        public User User
        {
            get
            {
                return User;
            }
            set
            {
                if (value == null)
                {
                    throw new NoUserForTransactionException();
                }
                _user = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return Date;
            }
            set
            {
                _date = value;
            }
        }
        public override string ToString()
        {
            return $"{_id} {User} {Amount} {Date.ToLongDateString()}";
        }

        public abstract void Execute();
    }
}
