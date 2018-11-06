using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Student
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string emailAddr { get; set; }
        public string course { get; set; }
        public string mentor { get; set; }
        public string password { get; set; }
        public string photo { get; set; }
        public string requestId { get; set; }
        public string description { get; set; }
        public string achievement { get; set; }
        public string externalLink { get; set; }
        public string status { get; set; }
        public int projectId { get; set; }
        public string leaderId { get; set; }

        public int mentorId { get; set; }

        public List<string> studentSkillList { get; set; } = new List<string>();

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
                ("INSERT INTO Student (Name, EmailAddr, Course, MentorID)" +
                "OUTPUT INSERTED.StudentID " +
                "VALUES (@name, @email, @course, @mentor)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the respective class's property.
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", emailAddr);
            cmd.Parameters.AddWithValue("@course", course);

            if (mentor != null)
            {
                cmd.Parameters.AddWithValue("@mentor", mentor);

                // Open a database connection
                conn.Open();

                // ExecuteScalar is used to retrieve the auto-generated 
                // StudentID after executing the INSERT SQL statement 
                int id = (int)cmd.ExecuteScalar();

                // Close database connection
                conn.Close();

                // Return id when no error occur
                return id;
            }

            else
                return -2;

           
        }

        public bool isEmailExist(string email)
        {
            string strConn = ConfigurationManager.ConnectionStrings
                                         ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT * FROM Student WHERE EmailAddr = @selectedEmail", conn);

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
                ("UPDATE Student SET Photo = @photo, Status = @status " +
                "WHERE StudentID = @selectedStudentID", conn);

            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            SqlCommand cmd2 = new SqlCommand
                ("SELECT * FROM Student WHERE StudentID = @selectedStudentID", conn);
            cmd2.Parameters.AddWithValue("@selectedStudentID", studentId);
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd2);
            DataSet result = new DataSet();
            daStudent.Fill(result, "StudentDetails");
            DataTable dtStudent = result.Tables["StudentDetails"];

            if (photo != null) // execute if a photo is provided
                cmd.Parameters.AddWithValue("@photo", photo);
            else // execute if a photo is NOT provided
            {
                if (DBNull.Value.Equals(dtStudent.Rows[0]["Photo"]))
                    cmd.Parameters.AddWithValue("@photo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@photo", dtStudent.Rows[0]["Photo"]);
            }

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

        public void Accept()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with SQL statement 

            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
            ("UPDATE ViewingRequest SET Status = 'A' , StudentID = @studentID "  + 
            "WHERE ViewingRequest.ViewingRequestID = @selectedRequestID", conn);


  
            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the requestId property of the Student class.
            cmd.Parameters.AddWithValue("@selectedRequestID", requestId);
            cmd.Parameters.AddWithValue("@studentID", studentId);

            // Open a database connection
            conn.Open();

            // ExecuteNonQuery is used for UPDATE and DELETE
            cmd.ExecuteNonQuery();

            // Close database connection
            conn.Close();
        }

        public void Reject()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with SQL statement UPDATE
            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
                ("UPDATE ViewingRequest SET Status = 'R' " +
                "WHERE ViewingRequest.ViewingRequestID = @selectedRequestID", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the requestId property of the Student class.
            cmd.Parameters.AddWithValue("@selectedRequestID", requestId);

            // Open a database connection
            conn.Open();

            // ExecuteNonQuery is used for UPDATE and DELETE
            cmd.ExecuteNonQuery();

            // Close database connection
            conn.Close();
        }

        public int getPortfolioDetails()
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a student record.
            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Student WHERE StudentID = @selectedStudentID", conn);
            SqlCommand cmd2 = new SqlCommand
               ("SELECT SkillSetName " +
               "FROM SkillSet " +
               "INNER JOIN StudentSkillSet ON SkillSet.SkillSetID = StudentSkillSet.SkillSetID " +
               "WHERE SkillSet.SkillSetID = StudentSkillSet.SkillSetID AND StudentID = @selectedStudentID", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the studentId property of the Student class.
            cmd.Parameters.AddWithValue("@selectedStudentID", studentId);
            cmd2.Parameters.AddWithValue("@selectedStudentID", studentId);


            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);
          

            // Created a DataSet object result
            DataSet result = new DataSet();

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "StudentDetails" in DataSet.
            daStudent.Fill(result, "StudentDetails");
   

            // Add skills into a list
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    studentSkillList.Add(reader.GetString(0));
                }
            }

            // Close database connection
            conn.Close();

            if (result.Tables["StudentDetails"].Rows.Count > 0)
            {
                // Fill Student object with values from the DataSet
                DataTable table = result.Tables["StudentDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                    name = table.Rows[0]["Name"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Photo"]))
                    photo = table.Rows[0]["Photo"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Description"]))
                    description = table.Rows[0]["Description"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Achievement"]))
                    achievement = table.Rows[0]["Achievement"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["ExternalLink"]))
                    externalLink = table.Rows[0]["ExternalLink"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["EmailAddr"]))
                    emailAddr = table.Rows[0]["EmailAddr"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Status"]))
                    status = table.Rows[0]["Status"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["MentorID"]))
                    mentorId = Convert.ToInt32(table.Rows[0]["MentorID"]);

                return 0; // No error occurs
            }
            else
            {
                return -2; // Record not found
            }
        }

        public int updatePortfolio() // Some errors
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            
            // Instantiate a SqlCommand object, supply it with an UPDATE SQL statement 
            // and the connection object for connecting to the database.
            SqlCommand cmd = new SqlCommand
                ("UPDATE Student SET Description = @description, Achievement = @achievement, ExternalLink = @externallink " +
                "WHERE StudentID = @selectedStudentID", conn);
            //Change This
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            SqlCommand cmd2 = new SqlCommand
                ("SELECT * FROM Student WHERE StudentID = @selectedStudentID", conn);
            cmd2.Parameters.AddWithValue("@selectedStudentID", studentId);
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd2);
            DataSet result = new DataSet();
            daStudent.Fill(result, "StudentDetails");
            DataTable dtStudent = result.Tables["StudentDetails"];





            if (description != "") // execute if a status is provided
                cmd.Parameters.AddWithValue("@description", description);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@description", dtStudent.Rows[0]["Description"]);

            if (achievement != "") // execute if a status is provided
                cmd.Parameters.AddWithValue("@achievement", achievement);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@achievement", dtStudent.Rows[0]["Achievement"]);

            if (externalLink != "") // execute if a status is provided
                cmd.Parameters.AddWithValue("@externalLink", externalLink);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@externalLink", dtStudent.Rows[0]["ExternalLink"]);






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

        //Helpful Codes

        public int SkillSetUpdate(string StudentID, string SkillID)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();
            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("IF NOT EXISTS "+
                                            "(SELECT * FROM StudentSkillSet WHERE StudentID = @StudentID and SkillSetID = @SkillID)"+
                                            " INSERT INTO StudentSkillSet(StudentID,SkillSetID) Values(@StudentID,@SkillID)", conn);

            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();
            daStudent.Fill(result, "StudentDetails");
            DataTable dtStudent = result.Tables["StudentDetails"];

            if (description != "") // execute if a status is provided
                cmd.Parameters.AddWithValue("@studentId", description);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@studentId", dtStudent.Rows[0]["Description"]);

            if (description != "") // execute if a status is provided
                cmd.Parameters.AddWithValue("@skillId", description);
            else // execute if a status is NOT provided
                cmd.Parameters.AddWithValue("@skillId", dtStudent.Rows[0]["Description"]);


            conn.Open();
            int count = cmd.ExecuteNonQuery();


            conn.Close();
            if (count > 0)
            {
                return 0;
            }
            else
                return -2;
        }

        public bool isIdExist(int studentId)
        {
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT * FROM STUDENT WHERE StudentID = @selectedID", conn);

            cmd.Parameters.AddWithValue("@selectedID", studentId);

            SqlDataAdapter daStudentID = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();
            // Use DataAdapter to fetch data to a table "IdDetails" in DataSet.
            daStudentID.Fill(result, "IdDetails");
            conn.Close();

            if (result.Tables["IdDetails"].Rows.Count > 0)
                return true; // The email given exists
            else
                return false; // The email given does not exist
        }

        public string getStudentName()
        {
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT Name FROM STUDENT WHERE StudentID = @selectedID", conn);

            cmd.Parameters.AddWithValue("@selectedID", studentId);

            SqlDataAdapter daStudentID = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();
            // Use DataAdapter to fetch data to a table "IdDetails" in DataSet.
            daStudentID.Fill(result, "IdName");
            conn.Close();


            if (result.Tables["IdName"].Rows.Count > 0)
            {
                //Fill Staff oject with values from the DataSet
                DataTable table = result.Tables["IdName"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                    name = table.Rows[0]["Name"].ToString();

                return name; //No error occurs
            }
            else
            {
                return "-2";//Record not found
            }

            //if (result.Tables["IdName"].Rows.Count > 0)
            //    return true; // The email given exists
            //else
            //    return false; // The email given does not exist
        }

        public int SkillSetDelete(string StudentID, string SkillID)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();
            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("DELETE FROM StudentSkillSet "+
                                            "WHERE StudentID = @StudentID and SkillSetID = @SkillSetID", conn);

            cmd.Parameters.AddWithValue("@studentId", StudentID);
            cmd.Parameters.AddWithValue("@skillsetId", SkillID);

            conn.Open();
            int count = cmd.ExecuteNonQuery();


            conn.Close();
            if (count > 0)
            {
                return 0;
            }
            else
                return -2;
        }

        public int AddProjectMembers(string StudentID, string ProjectID)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();
            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("INSERT INTO ProjectMember(ProjectID,StudentID,Role) Values(@ProjectID,@StudentID,'Member')", conn);
            cmd.Parameters.AddWithValue("@StudentID", StudentID);
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);



            conn.Open();
            int id = cmd.ExecuteNonQuery();


            conn.Close();
            return id;
        }

    }
}