﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System.App_Code
{
    public class ViewingRequest
    {
        public int viewingRequestId { get; set; }
        public int parentId { get; set; }
        public string studentName { get; set; }
        public int studentId { get; set; }
        public char status { get; set; }
        public DateTime dateCreated { get; set; }

        public int request()
        {
            //Read connection string "NPBookConnectionString" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT SQL statement 
            // which will return the auto-generated StaffID after insertion,
            // and the connection object for connecting to the database.

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO ViewingRequest (parentId, studentName, Status) OUTPUT INSERTED.ViewingRequestID VALUES(@parentId, @studentName, 'P')", conn);

            //Define parameters
            cmd.Parameters.AddWithValue("@studentName", studentName);
            cmd.Parameters.AddWithValue("@parentId", parentId);


            //Connection to database must be opened before any ops are made
            conn.Open();

            //ExecuteScalar used to retrieve the autogenerated staff ID after executing the insert sql statemen
            int id = (int)cmd.ExecuteScalar();

            //Connection should be closed after operations
            conn.Close();

            //No error
            return id;
        }

        


    }

}