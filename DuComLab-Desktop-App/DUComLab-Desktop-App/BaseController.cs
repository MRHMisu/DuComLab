using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberCenterClient
{
   abstract public class BaseController
   {
       protected int CardUsageId = 0;
       protected int TotalUsingTime = 0;
       protected string PinNumber;
       protected string PcName;
       public string CardNumber;
       public ProxyClientServices ProxyServices = new ProxyClientServices();


   }
}
