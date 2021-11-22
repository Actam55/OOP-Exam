using OOP_Exam.Models;
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
            List<Product> users = Stregsystem.ProductsFromCvsFile();
            foreach (Product product in users)
            {
                Console.WriteLine(product.ID);
            }
        }
    }
}