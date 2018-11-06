using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class SkillSet
    {
        public int skillSetId { get; set; }
        public int skillSetId2 { get; set; }
        public string name { get; set; }

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
                ("INSERT INTO SkillSet (SkillSetName)" +
                "OUTPUT INSERTED.SkillSetID " +
                "VALUES (@name)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the name property of the SkillSet class.
            cmd.Parameters.AddWithValue("@name", name);

            // Open a database connection
            conn.Open();

            // ExecuteScalar is used to retrieve the auto-generated 
            // SkillSetID after executing the INSERT SQL statement 
            int id = (int)cmd.ExecuteScalar();

            // Close database connection
            conn.Close();

            // Return id when no error occurs
            return id;
        }

        public bool isSkillExist(string skill)
        {
            string strConn = ConfigurationManager.ConnectionStrings
                                         ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT * FROM SkillSet WHERE SkillSetName = @selectedSkillSet", conn);

            cmd.Parameters.AddWithValue("@selectedSkillSet", skill);

            SqlDataAdapter daSkillSet = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();
            // Use DataAdapter to fetch data to a table "SkillDetails" in DataSet.
            daSkillSet.Fill(result, "SkillDetails");
            conn.Close();

            if (result.Tables["SkillDetails"].Rows.Count > 0)
                return true; // The skill given exists
            else
                return false; // The skill given does not exist
        }

        public int getSkillStudent(ref DataSet result) // gets students who has the particular skill selected by mentors
        {
            // Read connection string "NPBookConnectionString" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings
                               ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a student record.
            SqlCommand cmd = new SqlCommand
                        ("SELECT DISTINCT s.StudentID, sk.SkillSetID, s.Name, s.Course, s.Photo, s.Status " +
                        "FROM StudentSkillSet sk " +
                        "INNER JOIN Student s ON sk.StudentID = s.StudentID " +
                        "WHERE SkillSetID = @selectedSkillSetId", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the SkillSetID property of the SkillSet class.
            cmd.Parameters.AddWithValue("@selectedSkillSetId", skillSetId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daSkillSet = new SqlDataAdapter(cmd);
            

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "StudentDetails" in DataSet.
            daSkillSet.Fill(result, "StudentDetails");

            // Close database connection
            conn.Close();

            // Return 0 when no error occurs.
            return 0;
        }

        public int getTwoSkillStudent(ref DataSet result)
        {
            // Read connection string "NPBookConnectionString" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings
                               ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves the number of times a student record is found with more than one search entry.
            SqlCommand cmdCount = new SqlCommand
                ("SELECT DISTINCT sk.StudentID, s.Name, s.Course, s.Photo, s.Status, COUNT(*) AS Count " +
                "FROM StudentSkillSet sk " +
                "INNER JOIN Student s ON sk.StudentID = s.StudentID " +
                "WHERE(SkillSetID = @selectedSkillSetId1) or(SkillSetID = @selectedSkillSetId2) " +
                "GROUP BY sk.StudentID, s.Name, s.Course, s.Photo, s.Status " +
                "HAVING COUNT(*) > 1", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the SkillSetID property of the SkillSet class.
            cmdCount.Parameters.AddWithValue("@selectedSkillSetId1", skillSetId);
            cmdCount.Parameters.AddWithValue("@selectedSkillSetId2", skillSetId2);

            SqlDataAdapter daSkillSets2 = new SqlDataAdapter(cmdCount);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "StudentDetails" in DataSet.
            daSkillSets2.Fill(result, "SpecifiedStudentDetails");

            // Close database connection
            conn.Close();

            // Return 0 when no error occurs.
            return 0;
        }
    }
}