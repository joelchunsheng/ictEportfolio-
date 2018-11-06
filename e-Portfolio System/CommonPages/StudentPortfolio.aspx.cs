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
    public partial class StudentPortfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayStudent();
            }
        }

        private void displayStudent()
        {
            string strConn = ConfigurationManager.ConnectionStrings
                             ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                             ("SELECT * FROM Student ", conn);


            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();
            // Use DataAdapter to fetch data to a table "EmailDetails" in DataSet.
            daStudent.Fill(result, "studentDetails");
            conn.Close();

            gvStudentPortfolio.DataSource = result.Tables["studentDetails"];
            gvStudentPortfolio.DataBind();
        }

        protected void gvStudentPortfolio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the page index to the page clicked by user
            gvStudentPortfolio.PageIndex = e.NewPageIndex;
            // Display records on the new page.
            displayStudent();
        }
    }
}