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
        private readonly TallysystemController _controller;

        public TallysystemCommandParser2(ITallysystemUI ui, ITallysystem tallysystem, TallysystemController controller)
        {
            _ui = ui;
            _tallySystem = tallysystem;
            _controller = controller;
        }
        public void ParseCommand(string command)
        {
            string[] commands = command.Split(' ');
        }
    }
}