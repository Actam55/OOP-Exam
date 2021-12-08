using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Exceptions;

namespace OOP_Exam.Models
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            Product = product;
        }
        public Product Product { get; }
        //public decimal Amount { get; set; } I'm not sure what he want's here
        public override string ToString()
        {
            return $"Tranaction type: Buy, Price: {Product.Price}, User: {User.FirstName} {User.LastName}, Date: {Date}, ID: {ID}";
        }

        public override void Execute()
        {
            if (!Product.Active)
            {
                throw new InactiveProductException("Product is no longer active");
            }
            if (User.Balance - Product.Price < 0 && !Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException("Insufficient balance");
            }
            User.Balance -= Product.Price;
        }
    }
}
