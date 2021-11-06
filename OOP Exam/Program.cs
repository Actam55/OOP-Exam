using System;
using OOP_Exam.Models;

namespace OOP_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's ace this exam, let's fucking goooooo!!!");

            User lars = new("Lars", "Hansen", "l.1999@hotmail.dk", 100m);
            User pog = new("Pog", "champ", "Pog@chat.chimp", 10000m);

            Console.WriteLine("Lars:" + lars.ID);
            Console.WriteLine("Pog:" + pog.ID);
        }
    }
}
