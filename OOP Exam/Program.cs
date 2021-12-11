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
            User lars = new("Lars", "Hansen", "gamer", 0, "gamer@mail.dk");
            SeasonalProduct summerBeer = new("Winter beer", 5000, true, new DateTime(2021, 12, 1), new DateTime(2022, 1, 1));
            

            ITallysystem tallysystem = new Tallysystem();
            tallysystem.Users.Add(lars);
            tallysystem.Products.Add(summerBeer);
            ITallysystemUI ui = new TallySystemCLI(tallysystem); //publisher
            TallysystemController sc = new TallysystemController(ui, tallysystem); //Listener


            ui.Start();
        }
    }
}