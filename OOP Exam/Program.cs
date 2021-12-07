using OOP_Exam.Models;
using OOP_Exam.Interfaces;
using OOP_Exam.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public delegate void TallysystemEvent(string command);
    class Program
    {
        static void Main(string[] args)
        {
            Product sProduct = new SeasonalProduct("Seasonla product", 100, true, new DateTime(2021, 1, 1), new DateTime(2022, 1, 1));
            
            ITallysystem tallysystem = new Tallysystem();
            ITallysystemUI ui = new TallySystemCLI(tallysystem); //publisher
            TallysystemController sc = new TallysystemController(ui, tallysystem); //Listener

            tallysystem.Products.Add(sProduct);

            ui.Start();
            sc.ToString();
        }
    }
}