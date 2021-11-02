using System;
using OOP_Exam.Models;

namespace OOP_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's ace this exam, let's fucking goooooo!!!");

            User lars = new(1, "Lars", "Hansen", "Actam");

            Console.WriteLine(lars.Username);
        }
    }
}
