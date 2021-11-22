using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Models
{
    class Stregsystem : IStregsystem
    {
        private List<User> _users = UsersFromCvsFile();//En liste af brugere som nok skal hentes fra vores fil
        private List<Product> _products = ProductsFromCvsFile(); //En liste af produkter som skal hentes fra vores fil
        List<Transaction> transactions; //En liste af transaktioner, ved ej om det er alle eller kun for en specifik bruger
        
        
        
        public List<User> Users
        {
            get
            {
                return _users;
            }
        }
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        
        public IEnumerable<Product> ActiveProducts()
        {
            List<Product> list = new();
            foreach (Product product in Products)
            {
                if (product.Active == true)
                {
                    list.Add(product);
                }
            }
            return list;
        }

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
            foreach (Product product in Products)
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
            foreach (User user in Users)
            {
                if (predicate(user))
                {
                    list.Add(user);
                }
            }
            return list;
        }

        public static List<User> UsersFromCvsFile()
        {
            List<User> usersList = new();
            string[] cvsUserLines = File.ReadAllLines(@"..\..\..\Data\users.csv");

            for (int i = 1; i < cvsUserLines.Length; i++)
            {
                string[] userData = cvsUserLines[i].Split(',');
                User user = new User(userData[1], userData[2], userData[3], Convert.ToDecimal(userData[4]), userData[5]); //Skal tilpasses
                usersList.Add(user);
            }
            return usersList;
        }

        public static List<Product> ProductsFromCvsFile()
        {
            List<Product> productList = new();
            string[] cvsProductLines = File.ReadAllLines(@"..\..\..\Data\products.csv");

            for (int i = 1; i < cvsProductLines.Length; i++)
            {
                string[] productData = cvsProductLines[i].Split(';');
                bool isActive = (Convert.ToInt32(productData[3]) == 1); // sætter en string "1" eller "0" til true eller false
                Product product = new Product(productData[1], Convert.ToDecimal(productData[2]), isActive, false); //Check false om det er nødvendigt eller skal fjernes fra constructor
                productList.Add(product);
            }
            return productList;
        }
    }
}
