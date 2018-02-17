using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HireMe.DAL;
using System.Web.Security;

namespace HireMe.UI
{
    public partial class Demo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool x = this.Context.User.Identity.IsAuthenticated;
            string messge = "Welcom User :";
            lbl1.Text = messge+ Membership.GetUser().UserName;
            //var context = new HireMeEntities();
            //var x=context.Lookups.Include()

        }
        
    }
}