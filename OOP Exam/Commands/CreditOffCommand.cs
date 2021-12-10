using OOP_Exam.Interfaces;
using OOP_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Commands
{
    public class CreditOffCommand : ICommand
    {
        private readonly ITallysystemUI _ui;
        private readonly ITallysystem _tallySystem;
        private string[] _commands;
        public CreditOffCommand(ITallysystemUI ui, ITallysystem tallySystem, string[] commands)
        {
            _ui = ui;
            _tallySystem = tallySystem;
            _commands = commands;
        }

        public void Execute()
        {
            Product product = _tallySystem.GetProductByID(Convert.ToInt32(_commands[1]));
            product.CanBeBoughtOnCredit = false;
            _ui.DisplayUI();
        }
    }
}

