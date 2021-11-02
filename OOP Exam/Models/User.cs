using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public class User
    {
        public User(int iD, string firstName, string lastName, string username)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

    }
}
