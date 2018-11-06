using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Message
    {
        public int messageId { get; set; }
        public int fromId { get; set; }
        public int toId { get; set; }
        public string dateTimePosted { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string parentName { get; set; }

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
                ("INSERT INTO Message(FromID, ToID, Title, Text) " +
                "OUTPUT INSERTED.MessageID " +
                "VALUES(@parentId, @mentorId, @title, @text)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the respective class's property.
            cmd.Parameters.AddWithValue("@parentId", fromId);
            cmd.Parameters.AddWithValue("@mentorId", toId);
            cmd.Parameters.AddWithValue("@title", title);
            //cmd.Parameters.AddWithValue("@dateTimePosted", dateTimePosted);
            cmd.Parameters.AddWithValue("@text", text);
            
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
        //public int add()
        //{
        //    // Read connection string "Student_EPortfolio" from web.config file.
        //    string strConn = ConfigurationManager.ConnectionStrings
        //                        ["Student_EPortfolio"].ToString();

        //    // Instantiate a SqlConnection object with the Connection String read.
        //    SqlConnection conn = new SqlConnection(strConn);

        //    // Instantiate a SqlCommand object, supply it with an INSERT SQL statement 
        //    // which will return the auto-generated StudentID after insertion,
        //    // and the connection object for connecting to the database.
        //    SqlCommand cmd = new SqlCommand
        //        ("INSERT INTO Message(FromID, ToID, DateTimePosted, Text) " +
        //        "OUTPUT INSERTED.MessageID " +
        //        "VALUES( @parentId, @mentorId, @dateTimePosted, @text)", conn);

        //    // Define the parameter used in SQL statement, value for the 
        //    // parameter is retrieved from the respective class's property.
        //    cmd.Parameters.AddWithValue("@mentorId", toId);

        //    if (toId != 0)
        //        cmd.Parameters.AddWithValue("@mentorId", toId);
        //    else
        //        cmd.Parameters.AddWithValue("@mentorId", DBNull.Value);

        //    if (fromId != 0)
        //        cmd.Parameters.AddWithValue("@parentId ", fromId);
        //    else
        //        cmd.Parameters.AddWithValue("@parentId", DBNull.Value);

        //    cmd.Parameters.AddWithValue("@dateTimePosted", dateTimePosted);
        //    cmd.Parameters.AddWithValue("@text", text);

        //    // Open a database connection
        //    conn.Open();

        //    // ExecuteScalar is used to retrieve the auto-generated 
        //    // MentorID after executing the INSERT SQL statement t
        //    int id = (int)cmd.ExecuteScalar();

        //    // Close database connection
        //    conn.Close();

        //    // Return id when no error occurs
        //    return id;
        //}

        public int getMessageDetails(ref DataSet result)
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a message record + parent name.
            SqlCommand cmd = new SqlCommand
                ("SELECT m.MessageID, p.ParentName, m.fromID, m.DateTimePosted, m.Title, m.Text " +
                "FROM Message m " +
                "INNER JOIN Parent p ON m.FromID = p.ParentID " +
                "WHERE m.ToID = @toID ORDER BY m.DateTimePosted DESC", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the fromId property of the Message class.
            cmd.Parameters.AddWithValue("@toID", toId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "MessageDetails" in DataSet.
            daStudent.Fill(result, "MessageDetails");
            if (result.Tables["MessageDetails"].Rows.Count > 0)
            {
                // Fill Student object with values from the DataSet
                DataTable table = result.Tables["MessageDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["MessageID"]))
                    messageId = Convert.ToInt32(table.Rows[0]["MessageID"]);
                if (!DBNull.Value.Equals(table.Rows[0]["FromID"]))
                    fromId = Convert.ToInt32(table.Rows[0]["FromID"]);
                if (!DBNull.Value.Equals(table.Rows[0]["ParentName"]))
                    parentName = table.Rows[0]["ParentName"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["DateTimePosted"]))
                    dateTimePosted = table.Rows[0]["DateTimePosted"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Title"]))
                    title = table.Rows[0]["Title"].ToString();
                if (!DBNull.Value.Equals(table.Rows[0]["Text"]))
                    text = table.Rows[0]["Text"].ToString();

                return 0; // No error occurs
            }
            else
            {
                return -2; // Record not found
            }
        }
        //test
        //public bool isMessageExist(string emailAddr)
        //{
        //    string strConn = ConfigurationManager.ConnectionStrings
        //                        ["Student_EPortfolio"].ToString();

        //    SqlConnection conn = new SqlConnection(strConn);
        //    SqlCommand cmd = new SqlCommand
        //                     ("SELECT * FROM Message WHERE Title = @title AND Text = @text", conn);

        //    cmd.Parameters.AddWithValue("@title", title);
        //    cmd.Parameters.AddWithValue("@text", text);

        //    SqlDataAdapter daEmail = new SqlDataAdapter(cmd);
        //    DataSet result = new DataSet();

        //    conn.Open();
        //    // Use DataAdapter to fetch data to a table "EmailDetails" in DataSet.
        //    daEmail.Fill(result, "MessageDetails");
        //    conn.Close();

        //    if (result.Tables["MessageDetails"].Rows.Count > 0)
        //        return true; // The email given exists
        //    else
        //        return false; // The email given does not exist
        //}
    }
}