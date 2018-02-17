using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Common
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divAlert.Visible = false;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
         var x=   Membership.GetUser();
          if(  x.ChangePassword(txtOldPassword.Text, txtNewPassword.Text))
            {
                divSuccess.Visible = true;
                divAlert.Visible = false;
            }
            else
            {
                divAlert.Visible = true;
                divSuccess.Visible = false;

            }


        }
    }
}