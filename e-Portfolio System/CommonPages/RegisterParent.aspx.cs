using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_Portfolio_System.ParentPackage
{
    public partial class RegisterParent : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Parent objParent = new Parent();

                objParent.name = txtParentName.Text;
                objParent.emailAddr = txtParentEmail.Text;
                objParent.password = txtPassword.Text;
                objParent.add();

                Response.Redirect("ConfirmNewAccount.aspx?" + "&name=" + objParent.name + "&emailAddr=" + objParent.emailAddr);
            }
        }

        protected void cuvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Parent objParent = new Parent();
            

            if (objParent.isEmailExist(txtParentEmail.Text) == true)
                args.IsValid = false; //Raise error
            else
                args.IsValid = true; //No error

            
        }
    }
}