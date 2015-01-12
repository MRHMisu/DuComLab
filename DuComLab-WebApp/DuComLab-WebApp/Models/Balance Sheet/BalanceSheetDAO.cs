using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BalanceSheetDAO:DAO
    {
        

        public IEnumerable<BalanceSheet> GetMonthlyBaanceSheet(DateTime MonthStart, DateTime MonthEnd, int UnitPrice) 
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<BalanceSheet> BalanceSheet_list = new List<BalanceSheet>();
                SqlCommand command = new SqlCommand();

                command.CommandText = "SELECT Sellingdate as 'Date' ,COUNT(Sellingdate) as 'Number_of_Cards',(1*@UnitPrise) as 'Unit_Price',(COUNT(Sellingdate)*@UnitPrise) as 'Amount' FROM Cards where Sellingdate between @MonthStart and @MonthEnd group by SellingDate ORDER BY SellingDate ASC;";

                command.Parameters.AddWithValue("@MonthStart", MonthStart);
                command.Parameters.AddWithValue("@MonthEnd", MonthEnd);
                command.Parameters.AddWithValue("@UnitPrise", UnitPrice);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BalanceSheet BalanceSheet = new BalanceSheet();
                    BalanceSheet.Date = Convert.ToDateTime(reader["Date"]);
                    BalanceSheet.NumberOfCards = Convert.ToInt32(reader["Number_of_Cards"]);
                    BalanceSheet.UnitPrice = Convert.ToInt32(reader["Unit_Price"]);
                    BalanceSheet.Amount = Convert.ToInt32(reader["Amount"]);

                    BalanceSheet_list.Add(BalanceSheet);

                }

                return BalanceSheet_list;

            }
        
        
        
        }  

    }
}
