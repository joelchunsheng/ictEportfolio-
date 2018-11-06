using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Mentor
    {
        public int mentorId { get; set; }
        public string name { get; set; }
        public string  email { get; set; }
        public string password { get; set; }

        public int add()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT SQL statement 
            // which will return the auto-generated StudentID after insertion,
            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
                ("INSERT INTO Mentor (Name, EmailAddr)" +
                "OUTPUT INSERTED.MentorID " +
                "VALUES(@name, @email)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the respective class's property.
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);

            // Open a database connection
            conn.Open();

            // ExecuteScalar is used to retrieve the auto-generated 
            // MentorID after executing the INSERT SQL statement 
            int id = (int)cmd.ExecuteScalar();

            // Close database connection
            conn.Close();

            // Return id when no error occurs
            return id;
        }

        public bool isEmailExist(string email)
        {
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT * FROM Mentor WHERE EmailAddr = @selectedEmail", conn);

            cmd.Parameters.AddWithValue("@selectedEmail", email);

            SqlDataAdapter daEmail = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();
            // Use DataAdapter to fetch data to a table "EmailDetails" in DataSet.
            daEmail.Fill(result, "EmailDetails");
            conn.Close();

            if (result.Tables["EmailDetails"].Rows.Count > 0)
                return true; // The email given exists
            else
                return false; // The email given does not exist
        }

        public int getMentorStudent(ref DataSet result)
        {
            // Read connection string "NPBookConnectionString" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings
                               ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a student record.
            SqlCommand cmd = new SqlCommand
                        ("SELECT * FROM Student WHERE MentorID = @selectedMentorId", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the MentorID property of the Mentor class.
            cmd.Parameters.AddWithValue("@selectedMentorId", mentorId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daMentor = new SqlDataAdapter(cmd);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "MenteeDetails" in DataSet.
            daMentor.Fill(result, "MenteeDetails");

            // Close database connection
            conn.Close();

            // Return 0 when no error occurs.
            return 0;
        }

        public int update()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an SQL statement 
            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
                ("UPDATE Mentor SET Password = @password " +
                "WHERE MentorID = @selectedMentorID", conn);

            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@selectedMentorID", mentorId);

            // Open a database connection
            conn.Open();

            // ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();

            // Close database connection
            conn.Close();

            // Check if update successful
            if (count > 0) // at least 1 row updated
                return 0; // update successful
            else
                return -2; // no update done
        }
    }
}