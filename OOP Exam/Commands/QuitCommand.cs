using OOP_Exam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Controller
{
    public class QuitCommand : ICommand
    {
        private readonly ITallysystemUI _ui;
        public QuitCommand(ITallysystemUI ui)
        {
            _ui = ui;
        }

        public void Execute()
        {
            _ui.Close();
        }
    }
}
