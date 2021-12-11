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
        private int _nextID = 12; //skal måske ændres for at blive mere dynamisk
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;
        public delegate void UserBalanceNotification(User user, decimal balance);

        public User(string firstName, string lastName, string username, decimal balance, string email)
        {
            Id = _nextID;
            _nextID++;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Balance = balance * 0.01m;
        }
        public User(string firstName, string lastName, string username, decimal balance, string email, int id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Balance = balance * 0.01m;
        }

        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value ?? ""; //Måske giv et default navn som "Default firstname"
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
                _lastName = value ?? "";//Måske giv et default navn som "Default lastname"
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
                    throw new ArgumentException("Username is not valid");
            }
        }
        public string Email     //Find proper regex or write method for email check
        {
            get
            {
                return _email;
            }
            set
            {
                if (CheckEmail(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException($"'{value}' is not a valid email");
                }
            }
        }
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value; //Introducer delegate som opgaven siger!!!!
            }
        }

        public override string ToString()
        {
            return $"Name: {FirstName + ' ' + LastName}\nEmail: {Email}\nID: {Id}\nBalance: {Balance}";
        }

        public int CompareTo(object obj)
        {
            User user = obj as User;
            if (Id < user.Id)
                return 1;
            else if (Id > user.Id)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is User user && Id == user.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username);
        }

        private bool CheckEmail(string email) //maybe a better name and should be checked through more
        {
            string[] substrings = email.Split('@');

            if (substrings.Length != 2)
            {
                return false;
            }

            string localPart = substrings[0];
            string domain = substrings[1];

            if (CheckLocalAndDomain(localPart, domain))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckLocalAndDomain(string localPart, string domain) //maybe a better name
        {
            if (!Regex.IsMatch(localPart, @"^[a-zA-Z0-9_.-]+$") && !Regex.IsMatch(domain, @"^[a-zA-Z0-9-.]+$") || !domain.Contains(".") || domain.EndsWith(".") || domain.StartsWith(".") || domain.EndsWith("-") || domain.StartsWith("-"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

