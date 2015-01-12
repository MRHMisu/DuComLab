using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class History
    {
        public string CardNumber { get; set; }
        public string PcName { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime FinishingTime { get; set; }
        public int UsingTimeInSeconds { get; set; }
        public int UsingTimeInMinitues { get; set; }
        public int CardValidityInDays { get; set; }


    }
}
