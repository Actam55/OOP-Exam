using OOP_Exam.Interfaces;
using OOP_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Commands
{
    internal class AddCreditsCommand : ICommand
    {
        private readonly ITallysystemUI _ui;
        private readonly ITallysystem _tallySystem;
        private readonly string[] _commands;
        public AddCreditsCommand(ITallysystemUI ui, ITallysystem tallySystem, string[] commands)
        {
            _ui = ui;
            _tallySystem = tallySystem;
            _commands = commands;
        }

        public void Execute()
        {
            User user = _tallySystem.GetUserByUsername(_commands[1]);
            user.Balance += Convert.ToInt32(_commands[2]);
            _ui.DisplayUI();
        }
    }
}
