using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Individual
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divAlert.Visible = false;
            divSuccess.Visible = false;
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status;

            MembershipUser newUser = Membership.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, "color", "black", true, out status);

            Membership.GetUser(txtUsername.Text);
            if (status == 0)
            {
                AddUserType(txtUsername.Text, 220);
                string UsernName = txtUsername.Text;
                string PassWord = txtPassword.Text;

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
                    Response.Redirect("../../Pages/Individual/IndividualProfile");

                }
                else
                {
                    //lbluserNmae.Text = "you SHOULD BE ABROVID";
                }
            }
            else
            {
                divAlert.Visible = true;
            }
        }
        /// <summary>
        /// ابعث user nsmr 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userTypeId"></param>
        private void AddUserType(string userName, int userTypeId)
        {
            var context = new HireMeEntities();

            Guid UserId = context.aspnet_Users.Where(x => x.UserName == userName).FirstOrDefault().UserId;
            var obj = new UserType();
            obj.UserId = UserId;
            obj.UserType_lookupId = userTypeId;
            context.UserTypes.Add(obj);
            context.SaveChanges();
            if (userTypeId == 221)
                Response.Redirect("~/Pages/Company/CompanyRegister.aspx?UserId=" + UserId);
            

        }

        protected void btnRegisterCompany_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status;

            MembershipUser newUser = Membership.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, "color", "black", false, out status);

          
            if (status == 0)
            {
                AddUserType(txtUsername.Text, 221);
            }
            else
            {
                divAlert.Visible = true;
            }
        }
    }
}