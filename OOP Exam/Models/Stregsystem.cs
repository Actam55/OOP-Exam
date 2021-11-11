using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Models
{
    class Stregsystem : IStregsystem
    {
        List<User> users { get; } //En liste af brugere som nok skal hentes fra vores fil
        List<Product> products; //En liste af produkter som skal hentes fra vores fil
        List<Transaction> transactions; //En liste af transaktioner, ved ej om det er alle eller kun for en specifik bruger
        public IEnumerable<Product> ActiveProducts => throw new NotImplementedException();

        public event User.UserBalanceNotification UserBalanceWarning;

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            return new InsertCashTransaction(user, amount);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            return new BuyTransaction(user, product);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            ExecuteTransaction(transaction);
        }

        public Product GetProductByID(int id)
        {
            foreach (Product product in products)
            {
                if (product.ID == id)
                {
                    return product;
                }
            }
            throw new Exception("Product does not exist. Please try again with a new product ID"); //Skal muligvis gøres mere specifik
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count) //Check om den bruger listen af transaktioner korrekt. Skal tage de nyest først.
        {
            List<Transaction> list = new List<Transaction>();
            foreach (Transaction transaction in transactions)
            {
                if (list.Count == count)
                {
                    return list;
                }
                else if (transaction.User.Equals(user))
                {
                    list.Add(transaction);
                }
            }
            return list;
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(Func<User, bool> predicate) //Vi tjekker for hver bruger i vores liste om de opfylder predicate, og returnere alle der gør
        {
            List<User> list = new List<User>();
            foreach (User user in users)
            {
                if (predicate(user))
                {
                    list.Add(user);
                }
            }
            return list;
        }
    }
}
