﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exceptions
{
    internal class NoUserForTransactionException : Exception
    {
        public NoUserForTransactionException(string message) : base(message)
        {

        }
    }
}
