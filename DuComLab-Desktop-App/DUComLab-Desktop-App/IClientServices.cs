using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CyberCenterClient.CyberCenterServices;
namespace CyberCenterClient
{
   public interface IClientServices
   {
       bool IsValidUser(string CardNumber, string PinNumber);
       bool IsActive(string CardNumber);
       void ToBeInActive(string CardNumber);
       void InsertIntoActiveSession(string CardNumber,string PcName);
       int getCardUsageIdAfterInsertingStartingTime(string CardNumber, string PcName);
       int getUsingTime(string CardNumber);
       void UpdateFinishingTime(int CardUsageId);
       bool IsCardExperiedByDate(string CardNumber);
       DataSet ViewCardUsage(string CardNumber);
   }
}
