using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    
    public class StudentDAO:DAO
    {
        public Student GetStudenInfo(string CardNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Student student = new Student();
                SqlCommand command = new SqlCommand();

                command.CommandText = "select  * from Student where StudentId=(select StudentId from Cards where CardNumber=@CardNumber);";

                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.Name = reader["Name"].ToString();
                    student.DepartmentName = reader["DepartmentName"].ToString();
                    student.DepartmentRoll = reader["DepartmentRoll"].ToString();
                    student.AcademicYear = reader["AcademicYear"].ToString();
                    student.AttachedHallName = reader["AttachedHallName"].ToString();
                }

                return student;

            }


        }
        public Student GetStudenInfoForEditing(int StudentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Student student = new Student();
                SqlCommand command = new SqlCommand();

                command.CommandText = "select  * from Student where StudentId=@StudentId;";

                command.Parameters.AddWithValue("@StudentId", StudentId);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.Name = reader["Name"].ToString();
                    student.DepartmentName = reader["DepartmentName"].ToString();
                    student.DepartmentRoll = reader["DepartmentRoll"].ToString();
                    student.AcademicYear = reader["AcademicYear"].ToString();
                    student.AttachedHallName = reader["AttachedHallName"].ToString();
                }

                return student;

            }


        }

        public void UpdateStudentInfoWithStudentId(Student Student)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "Update Student set Name=@Name,DepartmentName=@DepartmentName,DepartmentRoll=@DepartmentRoll,AcademicYear=@AcademicYear,AttachedHallName=@AttachedHallName where  StudentId=@StudentId ;";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Name", Student.Name);
                command.Parameters.AddWithValue("@DepartmentName", Student.DepartmentName);
                command.Parameters.AddWithValue("@DepartmentRoll", Student.DepartmentRoll);
                command.Parameters.AddWithValue("@AcademicYear", Student.AcademicYear);
                command.Parameters.AddWithValue("@AttachedHallName", Student.AttachedHallName);
                command.Parameters.AddWithValue("@StudentId", Student.StudentId);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

    }
}
