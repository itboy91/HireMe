using HireMe.DAL;
using HireMe.UI.DomainModel;
using HireMe.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Admin
{
    public partial class IndividualList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGridView();
        }

        protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            var context = new HireMeEntities();

            var userId = new Guid(e.CommandArgument.ToString());
            var user = context.aspnet_Membership.Where(x => x.UserId == userId).FirstOrDefault();
            user.IsApproved = false;
            context.SaveChanges();
            //send Eamil 
            EmailDTO dto = new EmailDTO();
            dto.AddressTo = user.Email;
            dto.Body = "Dear :" + user.aspnet_Users.UserName + "your acount is Deactivate ";
            dto.Subject = "HireMe";
            EmailHelper emailHelper = new EmailHelper();
            if (emailHelper.SendEmail(dto))
            {
                FillGridView();
            }


        }

        protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
                if (Status == "Active")
                {
                    LinkButton lnkDeactivate = (LinkButton)e.Row.FindControl("Actevaite");
                    lnkDeactivate.Visible = false;
                }
                else
                {

                    LinkButton lnkDeactivate = (LinkButton)e.Row.FindControl("Deactivate");
                    lnkDeactivate.Visible = false;
                }
            }
        }

        protected void grdCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            var userId = new Guid(e.CommandArgument.ToString());
            Response.Redirect("~/Pages/Admin/ViewIndividual.aspx?UserId=" + userId);
        }

        private void FillGridView(string Name = "")
        {
            try
            {
                var context = new HireMeEntities();
                var CompanyIds = context.UserTypes.Where(x => x.UserType_lookupId == 220).ToList().Select(x => x.aspnet_Users.UserId);
                CompanyIds.Count();
                var listCompany = context.aspnet_Users.Where(p => CompanyIds.Contains(p.UserId)).ToList();
                if (Name != "")
                {
                    listCompany = listCompany.Where(x => x.UserName.Contains(Name)).ToList();
                }
                var query = from emp in listCompany
                            select new
                            {
                                Status = emp.aspnet_Membership.IsApproved == true ?
                               "Active" : "Unactive ",
                                UserName = emp.aspnet_Membership.aspnet_Users.UserName,
                                Email = emp.aspnet_Membership.Email,
                                Id = emp.UserId
                            };

                grdCompany.PageSize = 100000;
                grdCompany.DataSource = query.ToList();
                grdCompany.DataBind();
            }
            catch (Exception ex)
            {

                //WebAPIWrapper.LogExceptionWithElmah(ex);
            }
        }

        protected void Actevaite_Command(object sender, CommandEventArgs e)
        {
            var context = new HireMeEntities();

            var userId = new Guid(e.CommandArgument.ToString());
            var user = context.aspnet_Membership.Where(x => x.UserId == userId).FirstOrDefault();
            user.IsApproved = true;
            context.SaveChanges();
            //send Eamil 
            EmailDTO dto = new EmailDTO();
            dto.AddressTo = user.Email;
            dto.Body = "Dear :" + user.Email + "your acount is Actevaite ";
            dto.Subject = "HireMe";
            EmailHelper emailHelper = new EmailHelper();
            if (emailHelper.SendEmail(dto))
            {
                FillGridView();
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillGridView(txtName.Text);
        }
    }
}