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
//using OOP_Exam.Controller;

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

            //ITallysystem tallysystem = new TallySystem();
            //ITallysystemUI ui = new TallySystemCLI(tallysystem);
            //TallysystemController sc = new TallysystemController(ui, tallysystem);
            //
            //ui.Start();

            string FinalMail = "";
            string mail = "l.1999   @hotmail.dk";
            int count = 0;

            foreach (char charecter in mail)
            {
                if (charecter == '@')
                {
                    count++;
                }
            }
            if (count != 1)
            {
                Console.WriteLine("Invalid mail");
            }
            else
            {
                string[] substrings = mail.Split('@');
                string localPart = substrings[0];
                string domain = substrings[1];

                if (!Regex.IsMatch(localPart, @"^[a-z0-9.]+$"))
                {
                    Console.WriteLine("Local part is invalid");
                }
                else if (!Regex.IsMatch(domain, @"^[a-zA-Z0-9-.]") && !domain.Contains(".") && domain.EndsWith(".") && domain.StartsWith(".") && domain.EndsWith("-") && domain.StartsWith("-"))
                {
                    Console.WriteLine("Domain is invalid");
                }
                else
                {
                    FinalMail = mail;
                }
            }
                Console.WriteLine(FinalMail);
        }
    }
}