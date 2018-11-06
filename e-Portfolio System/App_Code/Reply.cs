using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public class Reply
    {
        public int replyId { get; set; }
        public int messageId { get; set; }
        public int mentorId { get; set; }
        public int parentId { get; set; }
        public string dateTimePosted { get; set; }
        public string text { get; set; }

        public string replyName { get; set; }

        public int replyCount { get; set; }

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
                ("INSERT INTO Reply(MessageID, MentorID, ParentID, DateTimePosted, Text) " +
                "OUTPUT INSERTED.ReplyID " +
                "VALUES(@messageId, @mentorId, @parentId, @dateTimePosted, @text)", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the respective class's property.
            cmd.Parameters.AddWithValue("@messageId", messageId);

            if (mentorId != 0)
                cmd.Parameters.AddWithValue("@mentorId", mentorId);
            else
                cmd.Parameters.AddWithValue("@mentorId", DBNull.Value);

            if (parentId != 0)
                cmd.Parameters.AddWithValue("@parentId ", parentId);
            else
                cmd.Parameters.AddWithValue("@parentId", DBNull.Value);

            cmd.Parameters.AddWithValue("@dateTimePosted", dateTimePosted);
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

        // Get reply details from both mentor and parent that replied to the particular message.
        public int getReplyDetails(ref DataSet result)
        {
            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a SELECT SQL
            // statement which retrieves all attributes of a message record + parent name.
            SqlCommand cmd = new SqlCommand
                ("SELECT r.ReplyID, r.Text, r.DateTimePosted, r.ParentID, r.MentorID, CONCAT(m.Name, p.ParentName) AS \"RepliedBy\" " +
                "FROM Reply r " +
                "FULL OUTER JOIN Mentor m ON m.MentorID = r.MentorID " +
                "FULL OUTER JOIN Parent p ON p.ParentID = r.ParentID " +
                "WHERE r.MessageID = @messageId ORDER BY DateTimePosted DESC", conn);

            // Define the parameter used in SQL statement, value for the 
            // parameter is retrieved from the messageId property of the Reply class.
            cmd.Parameters.AddWithValue("@messageId", messageId);

            // Instantiate a DataAdapter object, pass the SqlCommand
            // object created as parameter.
            SqlDataAdapter daReply = new SqlDataAdapter(cmd);

            // Open a database connection
            conn.Open();

            // Use DataAdapter to fetch data to a table "ReplyDetails" in DataSet.
            daReply.Fill(result, "ReplyDetails");

            // Close database connection
            conn.Close();

            if (result.Tables["ReplyDetails"].Rows.Count > 0)
            {
                DataTable dtReply = result.Tables["ReplyDetails"];

                // Fill Reply object with values from the DataSet
                if (!DBNull.Value.Equals(dtReply.Rows[0]["ReplyID"]))
                    replyId = Convert.ToInt32(dtReply.Rows[0]["ReplyID"]);
                if (!DBNull.Value.Equals(dtReply.Rows[0]["Text"]))
                    text = dtReply.Rows[0]["Text"].ToString();
                if (!DBNull.Value.Equals(dtReply.Rows[0]["DateTimePosted"]))
                    dateTimePosted = dtReply.Rows[0]["DateTimePosted"].ToString();

                // finding out whether the particular tuple was replied by the parent or mentor
                if (!DBNull.Value.Equals(dtReply.Rows[0]["RepliedBy"]))
                    replyName = dtReply.Rows[0]["RepliedBy"].ToString();

                return 0; // No error occurs
            }
            else
            {
                return -2; // Records not found
            }
        }
    }
}