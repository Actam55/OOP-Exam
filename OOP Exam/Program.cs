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

            User pog = new("Pog", "champ", "Peepo_44", "Pog@chat.chimp", 10000m);
            User lars = new("Lars", "Hansen", "Actam55", "l.1999@hotmail.dk", 100m);

            List<User> list = new List<User>();
            list.Add(lars);
            list.Add(pog);

            list.Sort();
            foreach (User item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}