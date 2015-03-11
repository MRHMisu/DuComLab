using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CyberCenter
{
    [ServiceContract]
    public interface IClientServices
    {
        [OperationContract]
        bool IsValidUser(string CardNumber, string PinNumber);
        [OperationContract]
        bool IsActive(string CardNumber);

        [OperationContract]
        void ToBeInActive(string CardNumber);

        [OperationContract]
        void InsertIntoActiveSession(string CardNumber, string PcName); 

        [OperationContract]
        int getCardUsageIdAfterInsertingStartingTime(string CardNumber,string PcName);
        
        [OperationContract]
        int getUsingTime(string CardNumber);

        [OperationContract]
        void UpdateFinishingTime(int CardUsageId);
        [OperationContract]
        bool IsCardExperiedByDate(string CardNumber);

        [OperationContract]
        DataSet ViewCardUsage(string CardNumber);

    }
}
