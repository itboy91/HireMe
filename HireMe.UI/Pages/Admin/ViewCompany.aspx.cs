using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Admin
{
    public partial class ViewCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDowns();
            
                FillUserData();
              
            }
        }

        private void FillUserData()
        {

            Guid userId = new Guid(Request.QueryString["UserId"]);
            var context = new HireMeEntities();
            txtCompanyEmail.Text = context.aspnet_Membership.Where(x => x.UserId == userId).FirstOrDefault().Email;
            txtCompanyEmail.Enabled = false;
            var user = context.Companies.Where(x => x.UserId == userId).FirstOrDefault();
            txtCompanyName.Text = user.Name;
            txtPhoneNumber.Text = user.PhoneNumber.ToString();
            txtWebSite.Text= user.WebSite;
            ddlCountry.SelectedValue = user.Country.ToString();
            ddlCity.SelectedValue = user.City.ToString();
            ddlIndustry.SelectedValue = user.Industry.ToString();
            txtCompanyEmail.Enabled = false;
            ddlIndustry.Enabled = false;
            ddlCountry.Enabled = false;
            ddlCity.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtWebSite.Enabled = false;
            txtCompanyName.Enabled = false;
        }

        private void FillDropDowns()
        {
            var context = new HireMeEntities();
            ///Industry
            ddlIndustry.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 3).ToList(); ;
            ddlIndustry.DataTextField = "Name";
            ddlIndustry.DataValueField = "Id";
            ddlIndustry.DataBind();
            /// countrys
            ddlCountry.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 20).ToList(); ;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Id"; 
            ddlCountry.DataBind();

            ddlCity.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 21).ToList(); ;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Id";
            ddlCity.DataBind();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Enabled = true;
            var context = new HireMeEntities();

           

        }

        protected void ddlGraduationCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new HireMeEntities();

            //ddlGraduationUniversity.Enabled = true;
            //int parentId = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
            //ddlGraduationUniversity.DataSource = context.Lookups.Where(x => x.ParentId == parentId).ToList(); ;
            //ddlGraduationUniversity.DataTextField = "Name";
            //ddlGraduationUniversity.DataValueField = "Id";
            //ddlGraduationUniversity.DataBind();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Admin/CompanyList.aspx");

        }
    }
}