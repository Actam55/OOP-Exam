using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Models
{
    public class SeasonalProduct : Product
    {
        public SeasonalProduct(string name, decimal price, bool canBeBoughtOnCredit, DateTime seasonStartDate, DateTime seasonEndDate)
        {
            Id = _nextID;
            _nextID++;
            Name = name;
            Price = price * 0.01m;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }

        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public override bool Active
        {
            get
            {
                if(SeasonStartDate < DateTime.Now && SeasonEndDate > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
