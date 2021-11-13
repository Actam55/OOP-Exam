using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP_Exam.Models
{
    public class User : IComparable
    {
        private static int _nextID = 1;
        public int ID { get; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value ?? "";
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value ?? "";
            }
        }
        public string Username
        {
            get
            {
                return _userName;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-z0-9_]+$"))
                {
                    _userName = value;
                }
                else
                    throw new ArgumentException("Give proper username >:(");
            }
        }
        public string Email { get; set; } //Find proper regex or write method for email check
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        } 


        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;
        
        public delegate void UserBalanceNotification(User user, decimal balance);

        public User(string firstName, string lastName,string username, decimal balance, string email)
        {
            ID = _nextID;
            _nextID++;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Name: {FirstName + ' ' + LastName, -20} Email: {Email, -20}";
        }

        public int CompareTo(object obj)
        {
            User user = obj as User;
            if (ID < user.ID)
                return 1;
            else if (ID > user.ID)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is User user && Username == user.Username;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username);
        } 
    }
}
