using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP_Exam.Models
{
    public class User
    {
        private static int _nextID = 1;
        public int ID
        {
            get
            {
                return _id;
            }
        }
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
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9_]+$"))
                {
                    _userName = value;
                }
                else
                    throw new ArgumentException("Give proper username >:(");
            }
        }
        public string Email { get; set; } //Find proper regex or write method for email check
        public decimal Balance { get; set; } //Alert user when they broke

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        public User(string firstName, string lastName, string email, decimal balance)
        {
            _id = _nextID;
            _nextID++;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _balance = balance;
        }

        public override string ToString()
        {
            return $"{_userName} {_lastName} {_email}";
        }
    }
}
