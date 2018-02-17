using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Company
{
    public partial class CompanyRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDowns();
                divSuccess.Visible = false;
                Guid userId = new Guid(Request.QueryString["UserId"]);
                var context = new HireMeEntities();

                txtCompanyEmail.Text = context.aspnet_Membership.Where(x => x.aspnet_Users.UserId == userId).FirstOrDefault().Email;
                txtCompanyEmail.Enabled = false;
            }
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
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Enabled = true;
            var context = new HireMeEntities();

            int parentId = Convert.ToInt32(ddlCountry.SelectedValue);
            ddlCity.DataSource = context.Lookups.Where(x => x.ParentId == parentId).ToList(); ;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Id";
            ddlCity.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Guid userId = new Guid(Request.QueryString["UserId"]);
            var context = new HireMeEntities();
            DAL.Company obj = new DAL.Company();
            obj.Name = txtCompanyName.Text;
            obj.Industry = Convert.ToInt32(ddlIndustry.SelectedValue);
            obj.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
            //obj.co = Convert.ToInt32(txtCompanyEmail.Text);
            obj.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            obj.City = Convert.ToInt32(ddlCity.SelectedValue);
            obj.WebSite = txtWebSite.Text;
            obj.UserId = userId;

            context.Companies.Add(obj);
            context.SaveChanges();
            divSuccess.Visible = true;
        }
    }
}