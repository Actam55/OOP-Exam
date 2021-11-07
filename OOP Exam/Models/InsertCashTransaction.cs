using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {
        }

        public override void Execute()
        {
            User.Balance += Amount;
        }

        public override string ToString()
        {
            return $"Type of transaction: Deposit, Amount: {Amount}, User: {User.FirstName} {User.LastName}, Date: {Date}, ID: {ID}";
        }
    }
}
