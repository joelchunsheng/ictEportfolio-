using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_Portfolio_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginId = txtId.Text.ToLower();
            string password = txtPassword.Text;

            // Checking for user type
            string userType = "";
            if (rdoSA.Checked == true)
                userType = "SA";
            else if (rdoStudent.Checked == true)
                userType = "Student";
            else if (rdoMentor.Checked == true)
                userType = "Mentor";
            else if (rdoParent.Checked == true)
                userType = "Parent";

            // Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings
                                ["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            // User Accounts
            if (loginId == "admin@ap.edu.sg" && password == "passAdmin" && userType == "SA")
            {
                Session["LoginID"] = loginId;
                Session["LoggedInTime"] = DateTime.Now.ToString();

                Response.Redirect("~/SystemAdmin/SAMain.aspx");
            }
            else if (userType == "Student")
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT * FROM Student " +
                    "WHERE EmailAddr = @selectedEmailAddr AND Password = @selectedPassword", conn);

                cmd.Parameters.AddWithValue("@selectedEmailAddr", loginId);
                cmd.Parameters.AddWithValue("@selectedPassword", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    Session["LoginID"] = loginId;
                    Session["StudentID"] = dt.Rows[0]["StudentID"];
                    Session["Name"] = dt.Rows[0]["Name"];
                    Session["LoggedInTime"] = DateTime.Now.ToString();

                    Response.Redirect("~/StudentPackage/StudentMain.aspx");
                }
                else
                    lblMessage.Text = "Invalid Login Credentials!";
            }
            else if (userType == "Mentor")
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT * FROM Mentor " +
                    "WHERE EmailAddr = @selectedEmailAddr AND Password = @selectedPassword", conn);

                cmd.Parameters.AddWithValue("@selectedEmailAddr", loginId);
                cmd.Parameters.AddWithValue("@selectedPassword", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    Session["LoginID"] = loginId;
                    Session["MentorID"] = dt.Rows[0]["MentorID"];
                    Session["Name"] = dt.Rows[0]["Name"];
                    Response.Redirect("~/MentorPackage/MentorMain.aspx");
                }
                else
                    lblMessage.Text = "Invalid Login Credentials!";
            }
            else if (userType == "Parent")
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT * FROM Parent " +
                    "WHERE EmailAddr = @selectedEmailAddr AND Password = @selectedPassword", conn);

                cmd.Parameters.AddWithValue("@selectedEmailAddr", loginId);
                cmd.Parameters.AddWithValue("@selectedPassword", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    Session["LoginID"] = loginId;
                    Session["ParentID"] = dt.Rows[0]["ParentID"];
                    Session["ParentName"] = dt.Rows[0]["ParentName"];
                    Session["emailAddr"] = dt.Rows[0]["emailAddr"];
                    Session["LoggedInTime"] = DateTime.Now.ToString();

                    Response.Redirect("~/ParentPackage/ParentMain.aspx");
                }
                else
                    lblMessage.Text = "Invalid Login Credentials!";
            }
            else
            {
                lblMessage.Text = "Invalid Login Credentials!";
            }
        }
    }
}