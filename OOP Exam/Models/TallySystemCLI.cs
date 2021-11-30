using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Models
{
    internal class TallySystemCLI : ITallysystemUI
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
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"Product: ${product} could not be found");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            throw new NotImplementedException();
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
