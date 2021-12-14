﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Exceptions;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Models
{
    public class TallySystemCLI : ITallysystemUI
    {
        private ITallysystem _tallySystem;
        public event TallysystemEvent CommandEntered;
        public TallySystemCLI(ITallysystem tallySystem)
        {
            _tallySystem = tallySystem;
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

        public void DisplayInsufficientCash(User user, Product product, int amount = 1)
        {
            Console.WriteLine($"Insuficcient balance on account. Current balance is: {user.Balance}. Cost of product is: {product.Price * amount}");
        }

        public void DisplayProductNotFound(string productId)
        {
            Console.WriteLine($"A product with id: {productId} could not be found");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"Command {command} contains too many arguments");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            if (count > 1)
                Console.WriteLine($"{count} * {transaction.Product.Name}'s have been purchased.");
            else
                Console.WriteLine($"{transaction.Product.Name} has been purchased.");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user);
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User: {username} could not be found");
        }

        protected virtual void OnCommandEntered(string command)
        {
            if (CommandEntered != null)
            {
                CommandEntered(command);
            }
        }

        public void Start() //Maybe clear console before writing, so ready for new input?
        {
            DisplayUI();

            while (true)
            {
                Console.SetCursorPosition(10, 0);
                string command = Console.ReadLine();
                string[] commands = command.Split(new char[] { ' ' });
                Console.SetCursorPosition(0, 30);
                DisplayUI();
                OnCommandEntered(command);
            }
        }
        public void DisplayUI()
        {
            Console.Clear();
            DisplayUserInputField();
            DisplayProductCatalog();
        }
        void DisplayUserInputField()
        {
            Console.WriteLine($"Quickbuy:    \n");
        }

        void DisplayProductCatalog()
        {
            IEnumerable<Product> products = _tallySystem.ActiveProducts();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
