using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Project
    {
        public int projectId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string projectPoster { get; set; }
        public string projectUrl { get; set; }

        public string role { get; set; }
        public int studentId { get; set; }
        public string reflection { get; set; }

        // Getting projects done by the particular student.
        public int getProjectStudent(ref DataSet result)
        {
            // Read connection string "NPBookConnectionString" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings
                               ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a student record.
            SqlCommand cmd = new SqlCommand
                        ("SELECT * FROM Project " +
                        "INNER JOIN ProjectMember ON Project.ProjectID = ProjectMember.ProjectID " +
                        "WHERE ProjectMember.StudentID = @selectedStudentID", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the MentorID property of the Mentor class.
            cmd.Parameters.AddWithValue("@selectedStudentID", studentId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daProject = new SqlDataAdapter(cmd);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet.
            daProject.Fill(result, "ProjectDetails");

            // Close database connection
            conn.Close();

            // Return 0 when no error occurs.
            return 0;
        }

        public int getProjectDetails()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a project record.
            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Project " +
                "INNER JOIN ProjectMember ON Project.ProjectID = ProjectMember.ProjectID " +
                "WHERE ProjectMember.StudentID = @selectedStudentId AND ProjectMember.ProjectID = @selectedProjectId", conn);
           
            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the studentId and projectId property of the ProjectMember class.
            cmd.Parameters.AddWithValue("@selectedStudentId", studentId);
            cmd.Parameters.AddWithValue("@selectedProjectId", projectId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daProject = new SqlDataAdapter(cmd);

            // Created a DataSet object result
            DataSet result = new DataSet();

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "StudentDetails" in DataSet.
            daProject.Fill(result, "ProjectDetails");

            // Close database connection
            conn.Close();

            if (result.Tables["ProjectDetails"].Rows.Count > 0)
            {
                // Fill Student object with values from the DataSet
                DataTable table = result.Tables["ProjectDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Title"]))
                    title = table.Rows[0]["Title"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Description"]))
                    description = table.Rows[0]["Description"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["ProjectPoster"]))
                    projectPoster = table.Rows[0]["ProjectPoster"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["ProjectURL"]))
                    projectUrl = table.Rows[0]["ProjectURL"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Role"]))
                    role = table.Rows[0]["Role"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Reflection"]))
                    reflection = table.Rows[0]["Reflection"].ToString();

                return 0; // No error occurs
            }
            else
            {
                return -2; // Record not found
            }
        }

        public int addProjectStudent()
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
                ("INSERT INTO Project (Title,Description,ProjectPoster,ProjectUrl)" +
                "OUTPUT INSERTED.ProjectID " +
                "VALUES (@title, @description, @projectPoster, @projectUrl)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the name property of the SkillSet class.

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@projectPoster", projectPoster);
            cmd.Parameters.AddWithValue("@projectUrl", projectUrl);

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

        public int addProjectMember(string studentI, string projectId)
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
                ("SELECT * FROM Project " +
                "INNER JOIN ProjectMember ON Project.ProjectID = ProjectMember.ProjectID " +
                "WHERE ProjectMember.ProjectID = @selectedProjectId", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the name property of the SkillSet class.


            cmd.Parameters.AddWithValue("@selectedProjectId", projectId);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@reflection", reflection);

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

        public int addProjectReflection()
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
                ("SELECT * FROM Project " +
                "INNER JOIN ProjectMember ON Project.ProjectID = ProjectMember.ProjectID " +
                "WHERE ProjectMember.StudentID = @selectedStudentId AND ProjectMember.ProjectID = @selectedProjectId", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the name property of the SkillSet class.

            cmd.Parameters.AddWithValue("@selectedStudentId", studentId);
            cmd.Parameters.AddWithValue("@selectedProjectId", projectId);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@reflection", reflection);

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
    }
}