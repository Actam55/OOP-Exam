using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;
using System.Text.RegularExpressions;

namespace OOP_Exam.Models
{
    public class Tallysystem : ITallysystem
    {
        private List<User> _users = UsersFromCvsFile();
        public List<Product> _products = ProductsFromCvsFile(); //En liste af produkter som skal hentes fra vores fil
        List<Transaction> transactions = new List<Transaction>(); //En liste af alle transaktioner
        public List<User> Users
        {    //En liste af brugere som nok skal hentes fra vores fil
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
        public int MyProperty { get; set; }
        public IEnumerable<Product> ActiveProducts()
        {
            List<Product> list = new();
            foreach (Product product in _products)
            {
                if (product.Active == true)
                {
                    list.Add(product);
                }
            }
            return list;
        }

        public event User.UserBalanceNotification UserBalanceWarning; //Missing

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            return new InsertCashTransaction(user, amount);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            return new BuyTransaction(user, product);
        }

        public void ExecuteTransaction(Transaction transaction) //Jeg ved ikke helt hvad den her skal
        {
            transactions.Add(transaction);
            transaction.Execute();
        }

        public Product GetProductByID(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
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
            foreach (User user in Users)
            {
                if (user.Username.Equals(username))
                {
                    return user;
                }
            }
            return null;
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
                User user = new User(userData[1], userData[2], userData[3], Convert.ToDecimal(userData[4]), userData[5], Convert.ToInt32(userData[0])); //Skal tilpasses
                usersList.Add(user);
            }
            return usersList;
        }

        public static List<Product> ProductsFromCvsFile() //Procudt name is a little confusing
        {
            List<Product> productList = new();
            string[] cvsProductLines = File.ReadAllLines(@"..\..\..\Data\products.csv");

            for (int i = 1; i < cvsProductLines.Length; i++)
            {
                string[] productData = cvsProductLines[i].Split(';');
                bool isActive = (Convert.ToInt32(productData[3]) == 1); // sætter en string "1" eller "0" til true eller false
                Product product = new Product(StripHTML(productData[1]).Trim(new char[] { '"' }), Convert.ToDecimal(productData[2]), isActive, false, Convert.ToInt32(productData[0])); //Check false om det er nødvendigt eller skal fjernes fra constructor
                productList.Add(product);
            }
            return productList;
        }
        static string StripHTML(string inputString) //Using regex to remove all HTML tags
        {
            string HTML_TAG_PATTERN = "<.*?>";
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }
    }
}
