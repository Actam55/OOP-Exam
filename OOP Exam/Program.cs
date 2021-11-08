using System;
using OOP_Exam.Models;
using System.Collections.Generic;

namespace OOP_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's ace this exam, let's fucking goooooo!!!");

            User pog = new("Pog", "champ", "Pog@chat.chimp", 10000m);
            User lars = new("Lars", "Hansen", "l.1999@hotmail.dk", 100m);

            //Console.WriteLine("Lars:" + lars.Balance);
            //Console.WriteLine("Pog:" + pog.ID);
            //InsertCashTransaction insert = new InsertCashTransaction(lars, 50);
            //insert.Execute();
            //Console.WriteLine("Lars:" + lars.Balance);
            //Console.WriteLine(insert.ToString());

            List<User> list = new List<User>();
            list.Add(lars);
            list.Add(pog);

            list.Sort();
            list.ForEach(User => Console.WriteLine(User.FirstName));
            Console.WriteLine(lars);
        }
    }
}
    