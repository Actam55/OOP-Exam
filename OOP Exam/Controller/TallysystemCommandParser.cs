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
            if (!String.IsNullOrEmpty(command))
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
                            ActivateProduct(commands[1]);
                            break;
                        case ":deactivate":
                            DeactivateProduct(commands[1]);
                            break;
                        case ":crediton":
                            break;
                        case ":creditoff":
                            break;
                        case ":addcredits":
                            AddCreditsToUser(commands[1], commands[2]);
                            break;
                        default:
                            Ui.DisplayAdminCommandNotFoundMessage(commands[0]);
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
                            BuyCommand(commands[0], commands[2], commands[1]);
                            break;
                        case > 3:
                            Ui.DisplayAdminCommandNotFoundMessage(command);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Ui.DisplayGeneralError("No command was found.");
            }
        }
        private void DisplayInfoCommand(string username) //Display user info
        {
            User user = Tallysystem.GetUserByUsername(username);
            if (user != null)
                Ui.DisplayUserInfo(user);
            else
                Ui.DisplayUserNotFound(username);
        }
        private void BuyCommand(string username, string productIdString, string amountString = "1") //Find better name than productIdString
        {
            User user = Tallysystem.GetUserByUsername(username);
            if (user == null)
            {
                Ui.DisplayUserNotFound(username);
            }
            else
            {
                bool idSuccess = int.TryParse(productIdString, out int productId); //Tries to parse to int, if it can success == true
                bool amountSuccess = int.TryParse(amountString, out int amount);
                if (idSuccess)
                {
                    if (amountSuccess)
                    {
                        Product product = Tallysystem.GetProductByID(productId);
                        if (product != null)
                        {
                            if (user.Balance > product.Price * amount)
                            {
                                Tallysystem.ExecuteTransaction(Tallysystem.BuyProduct(user, product));
                                Ui.DisplayUserBuysProduct(amount, Tallysystem.BuyProduct(user, product));
                            }
                            else
                            {
                                Ui.DisplayInsufficientCash(user, product, amount);
                            }
                        }
                        else
                        {
                            Ui.DisplayProductNotFound(productIdString);
                        }
                    }
                    else
                    {
                        Ui.DisplayGeneralError($"{amountString} is not valid amount");
                    }
                }
                else
                {
                    Ui.DisplayProductNotFound(productIdString);
                }
            }
        }
        private void ActivateProduct(string productIdString)
        {
            bool idSuccess = int.TryParse(productIdString, out int productId); //Tries to parse to int, if it can success == true
            if (idSuccess)
            {
                Product product = Tallysystem.GetProductByID(productId);
                if (product is SeasonalProduct)
                {
                    Ui.DisplayGeneralError("Cannot change active status of seasonal product");
                }
                else
                {
                    if (product != null)
                    {
                        product.Active = true;
                        Console.Clear();
                        Ui.Start();
                    }
                    else
                    {
                        Ui.DisplayProductNotFound(productIdString);
                    }
                }
            }
            else
            {
                Ui.DisplayProductNotFound(productIdString);
            }
        }
        private void DeactivateProduct(string productIdString)
        {
            bool idSuccess = int.TryParse(productIdString, out int productId); //Tries to parse to int, if it can success == true
            if (idSuccess)
            {
                Product product = Tallysystem.GetProductByID(productId);
                if (product != null)
                {
                    product.Active = false;
                    Console.Clear();
                    Ui.Start();
                }
                else
                {
                    Ui.DisplayProductNotFound(productIdString);
                }
            }
            else
            {
                Ui.DisplayProductNotFound(productIdString);
            }
        }
        private void AddCreditsToUser(string username, string creditsToAdd)
        {
            bool creditSuccess = int.TryParse(creditsToAdd, out int credits);
            User user = Tallysystem.GetUserByUsername(username);
            if (user != null)
            {
                if (!creditSuccess)
                {
                    Ui.DisplayGeneralError($"{creditsToAdd} is not a valid amount of credits to add");
                }
                else
                {
                    user.Balance += credits;
                }
            }
            else
            {
                Ui.DisplayUserNotFound(username);
            }
        }
    }
}
//Måske funktioner til hver type af kommando, som køb(bruger, produktId, mængde = 1);

//private void MultiBuyCommand(string username, string amountString, string productIdString) //To buy multiple products
//{
//    bool success = int.TryParse(amountString, out int amount); //Tries to parse to int, if it can success == true
//    if (!success)
//    {
//        throw new Exception("");
//    }
//    else
//    {
//        for (int i = 0; i < amount; i++)
//        {
//            BuyCommand(username, productIdString);
//        }
//    }
//}
//private void DisplayInvalidInputCommand(string invalidString)
//{
//    Ui.DisplayTooManyArgumentsError(invalidString);
//}