﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Models;

namespace OOP_Exam.Interfaces
{
    public interface ITallysystemUI
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product, int amount);
        void DisplayGeneralError(string errorString);
        public void DisplayUI();
        void Start();
        event TallysystemEvent CommandEntered;
    }
}
