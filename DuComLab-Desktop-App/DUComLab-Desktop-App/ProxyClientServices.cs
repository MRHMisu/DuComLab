using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CyberCenterClient.CyberCenterServices;
using System.Data;

namespace CyberCenterClient
{
    public class ProxyClientServices : IClientServices
    {
        public ClientServicesClient ProxyService = new ClientServicesClient("BasicHttpBinding_IClientServices");
        public bool IsValidUser(string CardNumber, string PinNumber)
        {
            return ProxyService.IsValidUser(CardNumber, PinNumber);
        }

        public bool IsActive(string CardNumber)
        {
            return ProxyService.IsActive(CardNumber);
        }

        public void ToBeInActive(string CardNumber)
        {
            ProxyService.ToBeInActive(CardNumber);
        }

        public void InsertIntoActiveSession(string CardNumber, string PcName)
        {
            ProxyService.InsertIntoActiveSession(CardNumber, PcName);
           
        }

        public int getCardUsageIdAfterInsertingStartingTime(string CardNumber, string PcName)
        {
            return ProxyService.getCardUsageIdAfterInsertingStartingTime(CardNumber,PcName);
        }

        public int getUsingTime(string CardNumber)
        {
            return ProxyService.getUsingTime(CardNumber);
        }

        public void UpdateFinishingTime(int CardUsageId)
        {
            ProxyService.UpdateFinishingTime(CardUsageId);
        }

        public bool IsCardExperiedByDate(string CardNumber)
        {
            return ProxyService.IsCardExperiedByDate(CardNumber);
        }

        public DataSet ViewCardUsage(string CardNumber)
        {
            return ProxyService.ViewCardUsage(CardNumber);
        }
    }
}
