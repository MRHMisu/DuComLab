using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class ParticularCardUsageDAO:DAO
    {
        public List<History> ShowParticularCardHisroty(string CardNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<History> ParticularCardUsageList = new List<History>();
                SqlCommand command = new SqlCommand();

                command.CommandText = "select CardUsage.CardNumber,PcName,StartingTime,FinishingTime,UsingTime as UsingTimeInSeconds,(UsingTime/60) as UsingTimeInMinitues,(180-DATEDIFF(day,SellingDate,(CONVERT(date, FinishingTime)))) as CardValidityInDays from CardUsage,Cards where (Cards.CardNumber=@CardNumber and CardUsage.CardNumber=@CardNumber) order by StartingTime;";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    History particularCardUsageHistory = new History();
                    particularCardUsageHistory.CardNumber = reader["CardNumber"].ToString();
                    particularCardUsageHistory.PcName = reader["PcName"].ToString();
                    particularCardUsageHistory.StartingTime = Convert.ToDateTime(reader["StartingTime"]);
                    particularCardUsageHistory.FinishingTime = Convert.ToDateTime(reader["FinishingTime"]);
                    particularCardUsageHistory.UsingTimeInSeconds = Convert.ToInt32(reader["UsingTimeInSeconds"]);
                    particularCardUsageHistory.UsingTimeInMinitues = Convert.ToInt32(reader["UsingTimeInMinitues"]);
                    particularCardUsageHistory.CardValidityInDays = Convert.ToInt32(reader["CardValidityInDays"]);
                    ParticularCardUsageList.Add(particularCardUsageHistory);

                }

                return ParticularCardUsageList;

            }


        }

    }
}
