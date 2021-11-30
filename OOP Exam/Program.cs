using OOP_Exam.Models;
using OOP_Exam.Interfaces;
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
    class Program
    {
        static void Main(string[] args)
        {
            //List<Product> products = TallySystem.ProductsFromCvsFile();
            //Product lajs = new("lajs", 5, true, true);
            //products.Add(lajs);
            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product);
            //}

            ITallysystem tallysystem = new TallySystem();
            ITallysystemUI ui = new TallySystemCLI(tallysystem);

            ui.Start();
        }
    }
}