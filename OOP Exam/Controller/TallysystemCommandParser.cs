using OOP_Exam.Commands;
using OOP_Exam.Exceptions;
using OOP_Exam.Interfaces;
using OOP_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Controller
{
    public class TallysystemCommandParser
    {
        private readonly ITallysystem _tallySystem;
        private readonly ITallysystemUI _ui;
        private readonly Dictionary<string, ICommand> adminCommands = new();

        public TallysystemCommandParser(ITallysystemUI ui, ITallysystem tallysystem)
        {
            _ui = ui;
            _tallySystem = tallysystem;
        }
        private void InitializeAdminCommands(string[] command)
        {
            adminCommands.Add(":q", new QuitCommand(_ui));
            adminCommands.Add(":quit", new QuitCommand(_ui));
            adminCommands.Add(":activate", new ActivateProductCommand(_ui, _tallySystem, command));
            adminCommands.Add(":crediton", new CreditOnCommand(_ui, _tallySystem, command));
            adminCommands.Add(":creditoff", new CreditOffCommand(_ui, _tallySystem, command));
            adminCommands.Add(":deactivate", new DeactivateProductCommand(_ui, _tallySystem, command));
            adminCommands.Add(":addcredits", new AddCreditsCommand(_ui, _tallySystem, command));
        }
        public void ParseCommand(string command)
        {
            string[] commands = command.Split(' ');
            InitializeAdminCommands(commands);
            try
            {
                if (command[0] == ':')
                {
                    adminCommands[$"{commands[0]}"].Execute();
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
                            _ui.DisplayTooManyArgumentsError(command);
                            break;
                        default:
                            _ui.DisplayGeneralError(command);
                            break;
                    }
                }
            }
            catch (ProductNotFoundException)
            {
                _ui.DisplayProductNotFound(commands[1]);
            }
            catch (UserNotFoundException)
            {
                _ui.DisplayUserNotFound(commands[1]);
            }
            catch (KeyNotFoundException)
            {
                _ui.DisplayAdminCommandNotFoundMessage(commands[0]);
            }
            catch (CannotSetSeasonalProductException)
            {
                _ui.DisplayGeneralError("Cannot change active status of seasonal product");
            }
            catch (ArgumentException)
            {
                _ui.DisplayAdminCommandNotFoundMessage(commands[0]);
            }
            catch (InsufficientCreditsException)
            {
                try
                {
                    _ui.DisplayInsufficientCash(_tallySystem.GetUserByUsername(commands[0]), _tallySystem.GetProductByID(Convert.ToInt32(commands[2])), Convert.ToInt32(commands[1]));
                }
                catch (IndexOutOfRangeException)
                {
                    _ui.DisplayInsufficientCash(_tallySystem.GetUserByUsername(commands[0]), _tallySystem.GetProductByID(Convert.ToInt32(commands[1])), 1);
                }
            }
            catch (FormatException)
            {
                _ui.DisplayGeneralError($"{command} is not a valid command");
            }
            adminCommands.Clear();
        }

        public void DisplayInfoCommand(string username)
        {
            User user = _tallySystem.GetUserByUsername(username);
            _ui.DisplayUserInfo(user);
        }
        public void BuyCommand(string username, string productIdString, string amountString = "1")
        {
            User user = _tallySystem.GetUserByUsername(username);
            int productId = Convert.ToInt32(productIdString);
            Product product = _tallySystem.GetProductByID(productId);
            int amount = Convert.ToInt32(amountString);
            for (int i = 0; i < amount; i++)
            {
                _tallySystem.ExecuteTransaction(_tallySystem.BuyProduct(user, product));
            }
            _ui.DisplayUserBuysProduct(amount, _tallySystem.BuyProduct(user, product));
        }
    }
}