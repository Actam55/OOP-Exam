using OOP_Exam.Commands;
using OOP_Exam.Exceptions;
using OOP_Exam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Controller
{
    public class TallysystemCommandParser2
    {
        private readonly ITallysystem _tallySystem;
        private readonly ITallysystemUI _ui;
        private readonly Dictionary<string, ICommand> adminCommands = new();

        public TallysystemCommandParser2(ITallysystemUI ui, ITallysystem tallysystem)
        {
            _ui = ui;
            _tallySystem = tallysystem;
            
        }
        private void InitializeAdminCommands(string[] command) //Invoker
        {
            adminCommands.Add(":q", new QuitCommand(_ui)); //System.ArgumentException for some reason tries tp add a ned key of ":q" when enter ':' and then nothing
            adminCommands.Add(":quit", new QuitCommand(_ui));
            adminCommands.Add(":activate", new ActivateProductCommand(_ui, _tallySystem, command));
            adminCommands.Add(":deactivate", new DeactivateProductCommand(_ui, _tallySystem, command));
            adminCommands.Add(":addcredits", new AddCreditsCommand(_ui, _tallySystem, command));
        }
        public void ParseCommand(string command)
        {
            string[] commands = command.Split(' ');
            InitializeAdminCommands(commands);
            if (!String.IsNullOrEmpty(command) && command[0] == ':')
            {
                    adminCommands[$"{commands[0]}"].Execute();
            }
            else
            {
                switch (commands.Length)
                {
                    case 1:
                        //DisplayInfoCommand(commands[0]);
                        break;
                    case 2:
                        //BuyCommand(commands[0], commands[1]);
                        break;
                    case 3:
                        //BuyCommand(commands[0], commands[2], commands[1]);
                        break;
                    case > 3:
                        _ui.DisplayTooManyArgumentsError(command);
                        break;
                    default:
                        _ui.DisplayGeneralError(command);
                        break;
                }
            }
            adminCommands.Clear();
        }
    }
}