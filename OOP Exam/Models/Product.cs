using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public class Product
    {
        private static int _nextID = 1;

        public int ID
        {
            get
            {
                return _id;
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

        public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            _id = _nextID;
            _nextID++;
            _name = name;
            _price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"{_id} {_name} {_price}";
        }
    }
}
