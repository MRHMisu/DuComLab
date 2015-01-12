using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class RegestrationDAO:DAO
    {

        public bool IsCardUnsoldAndUnRegisteredWhileRegitered(string CardNumber)
        {
            int valid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select count(CardNumber) from Cards where CardNumber=@CardNumber and SellingDate is null  and StudentId is null;";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();

                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    valid = Convert.ToInt32(outputParam);

                }


            }
            if (valid == 1) return true;
            else return false;


        }

        public bool IsValidCardInDataBase(string CardNumber) 
        {
            int valid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = "select count(CardNumber) from Cards where CardNumber=@CardNumber and SellingDate is not null  and StudentId is not null;";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();

                var outputParam = command.ExecuteScalar();

                if (!(outputParam is DBNull))
                {
                    valid = Convert.ToInt32(outputParam);

                }


            }
            if (valid == 1) return true;
            else return false;
            
        
        }

        public int GetStudentIdAfterInsertStudentInfo(Student Student)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Student(Name,DepartmentName,DepartmentRoll,AcademicYear,AttachedHallName ) OUTPUT INSERTED.StudentId VALUES(@Name ,@DepartmentName ,@DepartmentRoll ,@AcademicYear,@AttachedHallName );";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Name", Student.Name);
                command.Parameters.AddWithValue("@DepartmentName", Student.DepartmentName);
                command.Parameters.AddWithValue("@DepartmentRoll", Student.DepartmentRoll);
                command.Parameters.AddWithValue("@AcademicYear", Student.AcademicYear);
                command.Parameters.AddWithValue("@AttachedHallName", Student.AttachedHallName);
                connection.Open();
                Student.StudentId = (Int32)command.ExecuteScalar();
            }
            return Student.StudentId;

        }

        public void UpdateCardsTableWithStudentId(string CardNumber, int StudentId)
        {
            DateTime SellingDate = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "Update Cards Set  SellingDate=@SellingDate,StudentId=@StudentId where CardNumber=@CardNumber;";
                command.Connection = connection;
                command.Parameters.AddWithValue("@SellingDate", SellingDate);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                command.Parameters.AddWithValue("@CardNumber", CardNumber);

                connection.Open();
                command.ExecuteNonQuery();

            }

        }

        public void RegisterStudent(Regestration studentRegistration)
        {

            studentRegistration.StudentId= GetStudentIdAfterInsertStudentInfo(studentRegistration);
            UpdateCardsTableWithStudentId(studentRegistration.CardNumber, studentRegistration.StudentId);


        }
    }
}
