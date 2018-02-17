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
    public partial class RequestedProfiles : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGridView();
        }

       

        protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
                if (Status == "Loced")
                {
                    LinkButton lnkLock = (LinkButton)e.Row.FindControl("lnkLock");
                    lnkLock.Visible = false;
                }
                else
                {

                    LinkButton lnkunlock = (LinkButton)e.Row.FindControl("lnkunlock");
                    lnkunlock.Visible = false;
                }
            }
        }

    

        private void FillGridView(string Name = "")
        {
            try
            {
                var context = new HireMeEntities();

                var list = context.RequestedCvs.ToList();
                //if (Name != "")
                //{
                //    listCompany = listCompany.Where(x => x.UserName.Contains(Name)).ToList();
                //}
                var query = from emp in list
                            select new
                            {
                                Status = emp.IsUnlocked == false ?
                               "Loced" : "Unlocked ",
                                CompanyName = context.Companies.Where(x => x.UserId == emp.CompanyId).FirstOrDefault().Name,
                                IndividualName = context.Individuals.Where(x => x.UserId == emp.IndividualId).FirstOrDefault().Name,
                                Id = emp.Id
                            };

                grdCompany.PageSize = 1000000000;
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
           
                FillGridView();
          

        }

        protected void lnkunlock_Command(object sender, CommandEventArgs e)
        {
            var context = new HireMeEntities();

            var id = Convert.ToInt32(e.CommandArgument.ToString());
            var user = context.RequestedCvs.Where(x => x.Id == id).FirstOrDefault();
            user.IsUnlocked = true;
            context.SaveChanges();
            FillGridView();

        }

        protected void lnkLock_Command(object sender, CommandEventArgs e)
        {
            var context = new HireMeEntities();

            var id = Convert.ToInt32(e.CommandArgument.ToString());
            var user = context.RequestedCvs.Where(x => x.Id == id).FirstOrDefault();
            user.IsUnlocked = false;
            context.SaveChanges();
            FillGridView();

        }
    }
}