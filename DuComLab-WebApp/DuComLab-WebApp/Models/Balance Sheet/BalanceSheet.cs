using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class BalanceSheet
    {
        public DateTime Date { get; set; }
        public int NumberOfCards { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }

    }
}
