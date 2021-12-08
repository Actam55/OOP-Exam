using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Commands;
using OOP_Exam.Interfaces;
using OOP_Exam.Models;

namespace OOP_Exam.Controller
{
    public class TallysystemController
    {
        private readonly ITallysystem _tallySystem;
        private readonly ITallysystemUI _ui;
        private readonly TallysystemCommandParser CommandParser;
        private readonly TallysystemCommandParser2 CommandParser2;
        private readonly Dictionary<string, ICommand> adminCommands = new();

        public TallysystemController(ITallysystemUI ui, ITallysystem tallysystem)
        {
            InitializeAdminCommands();
            _tallySystem = tallysystem;
            _ui = ui;
            CommandParser = new TallysystemCommandParser(ui, tallysystem);
            ui.CommandEntered += CommandParser.ParseCommand; //add a new method
            tallysystem.UserBalanceWarning += tallysystem.DisplayLowFunds;
        }

        private void InitializeAdminCommands()
        {
            adminCommands.Add(":q", new QuitCommand(_ui));
            adminCommands.Add(":quit", new QuitCommand(_ui));
            //adminCommands.Add(":activate", new ActivateProductCommand(_ui, _tallySystem, ));
        }
    }
}