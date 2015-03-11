using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CyberCenter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    public class ClientServices:IClientServices
    {
        String connectionString = ConfigurationManager.ConnectionStrings["DUCyberCenter"].ConnectionString;
        public bool IsValidUser(string CardNumber,string PinNumber)
        {
            bool IsValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT CardNumber,PinNumber,SellingDate FROM Cards WHERE CardNumber=@CardNumber AND PinNumber=@PinNumber AND SellingDate IS NOT NULL";
                command.Connection = connection;
                command.Parameters.AddWithValue("@CardNumber",CardNumber);
                command.Parameters.AddWithValue("@PinNumber",PinNumber);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                if (datatable.Rows.Count > 0)
                {
                    IsValid = true;
                }

            }

            return IsValid;
        }

        public bool IsActive(string CardNumber) 
        {
            int IsActive = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select count(CardNumber) from ActiveSession where CardNumber=@CardNumber;";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();

                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    IsActive = Convert.ToInt32(outputParam);

                }
            }
            if (IsActive >= 1) return true;
            else return false;


        
        }

        public void ToBeInActive(string CardNumber) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from ActiveSession where CardNumber=@CardNumber;";
                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();                
            }
        
        }

        public void InsertIntoActiveSession(string CardNumber, string PcName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO ActiveSession(CardNumber,PcName,StartingTime) VALUES(@CardNumber,@PcName,GETDATE());";
                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Parameters.AddWithValue("@PcName", PcName);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public int getCardUsageIdAfterInsertingStartingTime(string CardNumber, string PcName)
        {
            DateTime StartingTime = DateTime.Now;
            DateTime FinishingTime = StartingTime;
            int CardUsageID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO CardUsage(CardNumber,PcName,StartingTime,FinishingTime) OUTPUT INSERTED.CardUsageId VALUES(@CardNumber,@PcName,@StartingTime,@FinishingTime);";
                command.Connection = connection;
                command.Parameters.AddWithValue("@CardNumber",CardNumber);
                command.Parameters.AddWithValue("@PcName",PcName);
                command.Parameters.AddWithValue("@StartingTime",StartingTime);
                command.Parameters.AddWithValue("@FinishingTime",FinishingTime);

                connection.Open();
                CardUsageID = (Int32)command.ExecuteScalar();
            }
            return CardUsageID;
        }

        public int getUsingTime(string CardNumber)
        {
            Int32 UsingTime = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "select sum(UsingTime) from CardUsage where CardNumber=@CardNumber; ";
                command.Connection = connection;
                command.Parameters.AddWithValue("@CardNumber", CardNumber);

                connection.Open();
                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    UsingTime = Convert.ToInt32(outputParam);
                
                }
                
               
            }
            return UsingTime;
        }

        public void UpdateFinishingTime(int CardUsageId)
        {
            DateTime FinishingTime = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE CardUsage SET FinishingTime=@FinishingTime  WHERE CardUsageId=@CardUsageId;";
                command.Connection = connection;
                command.Parameters.AddWithValue("@FinishingTime", FinishingTime);
                command.Parameters.AddWithValue("@CardUsageId", CardUsageId);
                connection.Open();
                command.ExecuteNonQuery();      
            }
            
        } 

        public bool IsCardExperiedByDate(string CardNumber)
        {
            int DateDifference = 0;
            DateTime ExpiredDate = DateTime.Today;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT DATEDIFF(day,SellingDate,@ExpiredDate) from Cards WHERE CardNumber=@CardNumber;";
                command.Connection = connection;
                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Parameters.AddWithValue("@ExpiredDate", ExpiredDate);
                connection.Open();


                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    DateDifference = Convert.ToInt32(outputParam);

                }
                else {
                    DateDifference = (Int32)command.ExecuteScalar();
                }      
            }
            if (DateDifference > 180)
            {

                return true;
            }
            else
            {
                return false;

            }
        }

        public DataSet ViewCardUsage(string CardNumber)
        {
            DataSet dataset;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "select CardUsage.CardNumber,PcName,StartingTime,FinishingTime,UsingTime as 'Using Time(Seconds)',(UsingTime/60) as 'Using Time(Minitues)', (180-DATEDIFF(day,SellingDate,(CONVERT(date, FinishingTime)))) as 'Card Validity (Days)' from CardUsage,Cards where (Cards.CardNumber=@CardNumber and CardUsage.CardNumber=@CardNumber) order by StartingTime;";
                command.Connection = connection;
                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                dataset = new DataSet();

                adapter.Fill(dataset);

                command.ExecuteNonQuery();

            }
            return dataset;

        }
    }
}
