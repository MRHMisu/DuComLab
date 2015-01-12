using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class CardDAO:DAO
    {
        public bool ISExsistCardDate(string CardNumber) 
        {
            int ISExsistCardDate = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select count(CardNumber) from Cards where CardNumber=@CardNumber;";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();

                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    ISExsistCardDate = Convert.ToInt32(outputParam);

                }
            }
            if (ISExsistCardDate >= 1) return true;
            else return false;


        }
        public void SaveCardsListIntoDataBase(List<Card> CardList)
        {

            List<string> statement = insertStatement(CardList);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                for (int i = 0; i < statement.Count;i++ )
                {
                    command.CommandText = statement[i];
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }



        }

        private List<string> insertStatement(List<Card> CardList) 
        {
            List<string> executeStatement = new List<string>();
            string cardNumber;
            string pinNumber;
            string insertStatement;

            foreach (Card _card in CardList) 
            {
                cardNumber = _card.CardNumber;
                pinNumber = _card.PinNumber;
                insertStatement = "INSERT INTO Cards(CardNumber,PinNumber) VALUES" + "('" + cardNumber + "','" + pinNumber + "');";
                executeStatement.Add(insertStatement);
            }
            return executeStatement;
        
        }

    }
}
