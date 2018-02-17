using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Company
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDowns();
                var User = Membership.GetUser().UserName;
                var context = new HireMeEntities();
                FilluserData();

                 txtCompanyEmail.Text = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().Email;
                txtCompanyEmail.Enabled = false;
            }
        }

        private void FilluserData()
        {
            var context = new HireMeEntities();

            var User = Membership.GetUser().UserName;
         var  UserId= context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
            var obj = context.Companies.Where(x => x.UserId == UserId).FirstOrDefault();
            txtCompanyName.Text = obj.Name;
            txtPhoneNumber.Text = obj.PhoneNumber.ToString();
            txtWebSite.Text = obj.WebSite;
            ddlCountry.SelectedValue = obj.Country.ToString();
            ddlCity.DataSource = context.Lookups.Where(x => x.ParentId == obj.Country).ToList(); ;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Id";
            ddlCity.DataBind();
            ddlCity.SelectedValue = obj.City.ToString();
            ddlIndustry.SelectedValue = obj.Industry.ToString();


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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var User = Membership.GetUser().UserName;

            var context = new HireMeEntities();
            DAL.Company obj = new DAL.Company();
            obj.Name = txtCompanyName.Text;
            obj.Industry = Convert.ToInt32(ddlIndustry.SelectedValue);
            obj.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text);
            //obj.co = Convert.ToInt32(txtCompanyEmail.Text);
            obj.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            obj.City = Convert.ToInt32(ddlCity.SelectedValue);
            obj.WebSite = txtWebSite.Text;
            obj.UserId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;

            context.Companies.Add(obj);
            context.SaveChanges();

        }
    }
}