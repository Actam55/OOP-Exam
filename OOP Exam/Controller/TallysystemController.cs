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
        //private readonly Dictionary<string, ICommand> adminCommands = new();


        public TallysystemController(ITallysystemUI ui, ITallysystem tallysystem)
        {
            _tallySystem = tallysystem;
            _ui = ui;
            CommandParser2 = new TallysystemCommandParser2(ui, tallysystem);
            ui.CommandEntered += CommandParser2.ParseCommand; //add a new method
            tallysystem.UserBalanceWarning += tallysystem.DisplayLowFunds; //Might not need to be here
        }
    }
}