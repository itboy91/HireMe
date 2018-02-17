using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Controls.Common
{
    public partial class NavBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divlogIn.Style.Add("display", "none");
            Divinv.Style.Add("display", "none");
            divCompany.Style.Add("display", "none");
            divAdmin.Style.Add("display", "none");



            bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1 == false)
            {
                divlogIn.Style.Add("display", "block");
            }
            else
            {
                var context = new HireMeEntities();

                var User = Membership.GetUser().UserName;
                var userId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
                var userType = context.UserTypes.Where(x => x.UserId == userId).FirstOrDefault().UserType_lookupId;
                if (userType == 221)
                {
                    ltrUserName.Text = User;

                    divCompany.Style.Add("display", "block");
                }

                if (userType == 220)
                {
                    litrINdivName.Text = User;

                    Divinv.Style.Add("display", "block");
                }
                if (userType == 222)
                {
                    litrAdminName.Text = User;

                    divAdmin.Style.Add("display", "block");
                }

            }


        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string UsernName = txtuserName.Text;
            string PassWord = txtpassword.Text;
            MembershipUser mu = Membership.GetUser(UsernName);
            if (mu.IsApproved)
            {

                if (Membership.ValidateUser(UsernName, PassWord))
                {
                    var context = new HireMeEntities();

                    Session["user"] = HttpContext.Current.User.Identity;
                    FormsAuthentication.RedirectFromLoginPage(UsernName, true);
                    //FormsAuthentication.SetAuthCookie("UsernName", true);
                    //var User = Membership.GetUser().UserName;
                    //var userId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
                    //var userType = context.UserTypes.Where(x => x.UserId == userId).FirstOrDefault().UserType_lookupId;
                    //ltrUserName.Text = User;
                    //if (userType == 221)
                    //{
                    //    Response.Redirect("../../Pages/Company/MyFavorite");
                    //}
                    Response.Redirect("../../Pages/Common/HomePage");

                }
                else
                {
                    lblLogInError.Text = "wrong password or username";
                }

            }
            else
            {
                lblLogInError.Text = "you SHOULD BE ABROVID";
            }
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Roles.DeleteCookie();
            Session.Clear();
            Response.Redirect("~/Pages/Common/LogIn.aspx");
        }
    }
}