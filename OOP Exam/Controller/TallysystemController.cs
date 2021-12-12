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
        private readonly TallysystemCommandParser CommandParser2;

        public TallysystemController(ITallysystemUI ui, ITallysystem tallysystem)
        {
            _tallySystem = tallysystem;
            _ui = ui;
            CommandParser2 = new TallysystemCommandParser(_ui, _tallySystem);
            ui.CommandEntered += CommandParser2.ParseCommand; //adds a new command to a list of commands to be run
            tallysystem.UserBalanceWarning += tallysystem.DisplayLowFunds; //Might not need to be here
        }
    }
}