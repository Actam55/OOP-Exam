using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Models;
using OOP_Exam.Interfaces;

namespace OOP_Exam.Controller
{
    public class TallysystemCommandParser
    {
        private readonly ITallysystem Tallysystem;
        private readonly ITallysystemUI Ui;
        public TallysystemCommandParser(ITallysystemUI ui, ITallysystem tallysystem)
        {
            Ui = ui;
            Tallysystem = tallysystem;
        }
        public void ParseCommand(string command) //Switch for all commands maybe
        {
            string[] commands = command.Split(' ');
            User user = Tallysystem.GetUserByUsername("ndavo");

            string username = commands[0];

            bool success = int.TryParse(commands[1], out int productId); //Tries to parse to int, if it can success == true

            if (!success)
            {
                throw new Exception("");
            }

            Product product = Tallysystem.GetProductByID(productId);
            IEnumerable<Product> products = Tallysystem.ActiveProducts();
            if (!products.Contains(product))
            {
                throw new Exception("Item not active");
            }
            Tallysystem.BuyProduct(user, product);
            Ui.DisplayUserBuysProduct(Tallysystem.BuyProduct(user, product));
        }
    }
}
//Måske funktioner til hver type af kommando, som køb(bruger, produktId, mængde = 1);