using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Models
{
    public class TallySystemCLI : ITallysystemUI
    {
        public ITallysystem TallySystem { get; set; }

        public TallySystemCLI(ITallysystem tallySystem)
        {
            TallySystem = tallySystem;
        }
        public void Close()
        {
            Environment.Exit(0);
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"Admin command {adminCommand}, was not recognized");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"Insuficcient balance on account. Current balance is: {user.Balance}. Cost of product is: {product.Price}");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"Product: ${product} could not be found");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"Command {command} contains too many arguments");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine($"{transaction.Product} has been purchased.");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            if (count > 1)
                Console.WriteLine($"{count}{transaction.Product}'s have been purchased.");
            else
                Console.WriteLine($"{transaction.Product} has been purchased.");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user);
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User: {username} could not be found");
        }

        public void Start()
        {
            DisplayUserInputField();
            DisplayProductCatalog();
            //Console.Read();
            //Console.CursorLeft = 3;
            //Console.CursorTop = 3;
        }

        void DisplayUserInputField()
        {
            Console.WriteLine($"Quickbuy:    \n");
        }

        void DisplayProductCatalog() //Needs to be divided for better view
        {
            IEnumerable<Product> products = TallySystem.ActiveProducts();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
