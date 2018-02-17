using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Common
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          //string UsernName=  txtUsername.Text;
          //string PassWord = txtPassword.Text;

          //  if (Membership.ValidateUser(UsernName, PassWord))
          //  {
          //      Session["user"] = User.Identity.Name;
          //      FormsAuthentication.RedirectFromLoginPage(UsernName, true);
          //      //FormsAuthentication.SetAuthCookie("UsernName", true);
          //      Response.Redirect("~/Demo1.aspx");
            
          //  }
          //  else
          //  {
          //      lbluserNmae.Text = "you SHOULD BE ABROVID";
          //  }


        }

        protected void singlebutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Individual/Register.aspx");

        }
    }
}