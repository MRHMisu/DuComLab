using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class Card
    {

        public string CardNumber { get; set; }
        public string PinNumber { get; set; }
        public Card(string CardNumber,string PinNumber) 
        {
            this.CardNumber = CardNumber;
            this.PinNumber = PinNumber;
        
        }
      }
}
