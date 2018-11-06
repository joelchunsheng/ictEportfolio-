using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_Portfolio_System.ParentPackage
{
    public partial class ConfirmNewAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblParentName.Text = Request.QueryString["name"];
            lblEmail.Text = Request.QueryString["emailAddr"];
        }
    }
}