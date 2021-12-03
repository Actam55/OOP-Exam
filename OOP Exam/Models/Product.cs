using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public class Product
    {
        private static int _nextID = 1838; //Might need to be changed for more dynamic ID

        public int Id //Id need to be handled in a way so all id's are unique
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value ?? "";
            }
        }
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        public bool CanBeBoughtOnCredit { get; set; } //Im not sure I understand this

        private int _id;
        private string _name;
        private decimal _price;
        private bool _active;

        public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit) //Constructor no given ID 
        {
            Id = _nextID;
            _nextID++;
            Name = name;
            Price = price * 0.01m;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit, int id) //Constructor for given ID
        {
            Id = id;
            Name = name;
            Price = price * 0.01m;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"ID: {Id, -5} Name: {Name, -35} Price: {Price}kr,-";
        }
    }
}
