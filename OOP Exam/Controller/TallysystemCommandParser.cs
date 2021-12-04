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

            if (command[0] == ':')
            {
                switch (commands[0])
                {
                    case ":quit":
                        Ui.Close();
                        break;
                    case ":q":
                        Ui.Close();
                        break;
                    case ":activate":
                        break;
                    case ":deactivate":
                        break;
                    case ":crediton":
                        break;
                    case ":creditoff":
                        break;
                    case ":addcredits":
                        break;

                }
            }
            else
            {
                switch (commands.Length)
                {
                    case 1:
                        DisplayInfoCommand(commands[0]);
                        break;
                    case 2:
                        BuyCommand(commands[0], commands[1]);
                        break;
                    case 3:
                        MultiBuyCommand(commands[0], commands[1], commands[2]);
                        break;
                    case > 3:
                        DisplayInvalidInputCommand(command);
                        break;
                    default:
                        break;
                }
            }
        }
        private void DisplayInfoCommand(string username) //Display user info
        {
            User user = Tallysystem.GetUserByUsername(username);
            Ui.DisplayUserInfo(user);
        }
        private void BuyCommand(string username, string productIdString) //Find better name than productIdString
        {
            User user = Tallysystem.GetUserByUsername(username);
            bool success = int.TryParse(productIdString, out int productId); //Tries to parse to int, if it can success == true
            if (!success)
            {
                throw new Exception("");
            }
            Product product = Tallysystem.GetProductByID(productId);

            Tallysystem.ExecuteTransaction(Tallysystem.BuyProduct(user, product));
            Ui.DisplayUserBuysProduct(Tallysystem.BuyProduct(user, product));
        }
        private void MultiBuyCommand(string username, string amountString, string productIdString) //To buy multiple products
        {
            bool success = int.TryParse(amountString, out int amount); //Tries to parse to int, if it can success == true
            if (!success)
            {
                throw new Exception("");
            }

            for (int i = 0; i < amount; i++)
            {
                BuyCommand(username, productIdString);
            }
        }
        private void DisplayInvalidInputCommand(string invalidString)
        {
            Ui.DisplayTooManyArgumentsError(invalidString);
        }
    }
}
//Måske funktioner til hver type af kommando, som køb(bruger, produktId, mængde = 1);