using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int id)
        {

        }
    }
}
