using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Suggestion
    {
        public int suggestionId { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string dateCreated { get; set; }
        public int mentorId { get; set; }
        public int studentId { get; set; }

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
                ("INSERT INTO Suggestion (MentorID, StudentID, Description, DateCreated, Status)" +
                "OUTPUT INSERTED.SuggestionID " +
                "VALUES(@mentorId, @studentId, @description, @dateCreated, @status)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the respective class's property.
            cmd.Parameters.AddWithValue("@mentorId", mentorId);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
            cmd.Parameters.AddWithValue("@status", status);

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

        public int update()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an UPDATE SQL statement 
            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
                ("UPDATE Suggestion SET Status = @status " +
                "WHERE StudentID = @selectedStudentID " ,conn);

            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            SqlCommand cmd2 = new SqlCommand
                ("SELECT * FROM Student WHERE StudentID = @selectedStudentID", conn);
            cmd2.Parameters.AddWithValue("@selectedStudentID", studentId);
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd2);
            DataSet result = new DataSet();
            daStudent.Fill(result, "SuggestionDetails");
            DataTable dtStudent = result.Tables["SuggestionDetails"];


            if (status != null) // execute if a status is provided
                cmd.Parameters.AddWithValue("@status", status);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@status", dtStudent.Rows[0]["Status"]);

            cmd.Parameters.AddWithValue("@selectedStudentID", studentId);

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

        public int getsuggestion(ref DataSet result)
        {
            // Read connection string "NPBookConnectionString" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings
                               ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a student record.
            SqlCommand cmd = new SqlCommand
                        ("SELECT * FROM Suggestion " +
                        "INNER JOIN Mentor ON Mentor.MentorID = Suggestion.MentorID " +
                        "WHERE Suggestion.StudentID = @selectedStudentID AND Status ='N' ", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the MentorID property of the Mentor class.
            cmd.Parameters.AddWithValue("@selectedStudentID", studentId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daSuggestion = new SqlDataAdapter(cmd);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet.
            daSuggestion.Fill(result, "SuggestionDetails");

            // Close database connection
            conn.Close();

            // Return 0 when no error occurs.
            return 0;
        }
    }
}