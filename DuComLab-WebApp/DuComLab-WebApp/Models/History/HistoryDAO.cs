using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class HistoryDAO:DAO
    {

        public List<History> ShowHisroty(DateTime StartDate, DateTime EndDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<History> HistoryList = new List<History>();
                SqlCommand command = new SqlCommand();

                command.CommandText = "select CardUsage.CardNumber,PcName,StartingTime,FinishingTime,UsingTime as UsingTimeInSeconds,(UsingTime/60) as UsingTimeInMinitues,(180-DATEDIFF(day,SellingDate,(CONVERT(date, FinishingTime)))) as CardValidityInDays from CardUsage,Cards where (Cards.CardNumber=CardUsage.CardNumber) and StartingTime between @StartDate and @EndDate order by StartingTime;";

                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    History History = new History();
                    History.CardNumber = reader["CardNumber"].ToString();
                    History.PcName = reader["PcName"].ToString();
                    History.StartingTime = Convert.ToDateTime(reader["StartingTime"]);
                    History.FinishingTime = Convert.ToDateTime(reader["FinishingTime"]);
                    History.UsingTimeInSeconds = Convert.ToInt32(reader["UsingTimeInSeconds"]);
                    History.UsingTimeInMinitues = Convert.ToInt32(reader["UsingTimeInMinitues"]);
                    History.CardValidityInDays = Convert.ToInt32(reader["CardValidityInDays"]);
                    HistoryList.Add(History);

                }

                return HistoryList;

            }


        }

    }
}
