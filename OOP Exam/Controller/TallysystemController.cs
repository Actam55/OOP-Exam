using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Interfaces;
using OOP_Exam.Models;

namespace OOP_Exam.Controller
{
    public class TallysystemController
    {
        private readonly ITallysystem Tallysystem;
        private readonly ITallysystemUI Ui;
        private readonly TallysystemCommandParser CommandParser;

        public TallysystemController(ITallysystemUI ui, ITallysystem tallysystem)
        {
            Tallysystem = tallysystem;
            Ui = ui;
            CommandParser = new(ui, tallysystem);
            ui.CommandEntered += CommandParser.ParseCommand;
        }
    }
}