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
        public Product Product { get; }
        public int Count { get; set; }

        public BuyTransaction(User user, Product product, int count) : base(user, product.Price)
        {
            Product = product;
            Count = count;
        }
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
            if (User.Balance - Product.Price * Count < 0 && !Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException("Insufficient balance");
            }
            User.Balance -= Product.Price * Count;
        }
    }
}
