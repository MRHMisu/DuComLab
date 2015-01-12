using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class ActiveUserDAO : DAO
    {
        public List<ActiveUser> GetActiveUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ActiveUser> ActiveUserList = new List<ActiveUser>();
                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from ActiveSession;";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ActiveUser Active_User = new ActiveUser();
                    Active_User.CardNumber = reader["CardNumber"].ToString();
                    Active_User.PcName = reader["PcName"].ToString();
                    Active_User.StartingTime = Convert.ToDateTime(reader["StartingTime"]);
                    ActiveUserList.Add(Active_User);
                }
                return ActiveUserList;

            }
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


        public void RefreshActiveUserList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from ActiveSession;";
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void RefreshActiveUserListForParticularCard(string CardNumber)
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


        
    }
}
