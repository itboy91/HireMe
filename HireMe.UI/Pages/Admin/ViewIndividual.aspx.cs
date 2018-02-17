using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Admin
{
    public partial class ViewIndividual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDowns();
                Guid userId = new Guid(Request.QueryString["UserId"]);
                FillUserData(userId);
            }
               
        }

        private void FillUserData(Guid userId)
        {
            var context = new HireMeEntities();
            var user = context.Individuals.Where(aat => aat.UserId == userId).FirstOrDefault();
            txtEmail.Text = user.aspnet_Users.aspnet_Membership.Email;
            if (user != null)
            {
                txtFullName.Text = user.Name;
                txtPhone.Text = user.Phone.ToString();
                ddlDay.SelectedValue=user.BdDDay.ToString();
                ddlMonth.SelectedValue = user.BobMonth;
                ddlYear.SelectedValue = user.BobYear.ToString();
                ddlYearsOfExperience.SelectedValue = user.YearsOfExperience.ToString();
                ddlTypeOfEmployment.SelectedValue = user.TypeOfEmployment.ToString();
                
            }

        }

        private void FillDropDowns()
        {
            var context = new HireMeEntities();


            /// location

            ddlLocation.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 20).ToList(); ;
            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "Id";
            ddlLocation.DataBind();

            /// fill gender
            /// 
            ddlGendr.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 1).ToList(); ;
            ddlGendr.DataTextField = "Name";
            ddlGendr.DataValueField = "Id";
            ddlGendr.DataBind();

            ///Field of busnnies
            ddlFieldOfBusiness.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 3).ToList(); ;
            ddlFieldOfBusiness.DataTextField = "Name";
            ddlFieldOfBusiness.DataValueField = "Id";
            ddlFieldOfBusiness.DataBind();


            ///years of experience

            ddlYearsOfExperience.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 4).ToList(); ;
            ddlYearsOfExperience.DataTextField = "Name";
            ddlYearsOfExperience.DataValueField = "Id";
            ddlYearsOfExperience.DataBind();


            ///type of employment
            ddlTypeOfEmployment.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 5).ToList(); ;
            ddlTypeOfEmployment.DataTextField = "Name";
            ddlTypeOfEmployment.DataValueField = "Id";
            ddlTypeOfEmployment.DataBind();



            ///academic degree

            ddlAcademicDegree.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 6).ToList(); ;
            ddlAcademicDegree.DataTextField = "Name";
            ddlAcademicDegree.DataValueField = "Id";
            ddlAcademicDegree.DataBind();

            ddlSkiles.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 10).ToList(); ;
            ddlSkiles.DataTextField = "Name";
            ddlSkiles.DataValueField = "Id";
            ddlSkiles.DataBind();


            /// date of birth

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;
            var last50Years = from n in Enumerable.Range(0, 50)
                              select DateTime.Now.Year - n;
            ddlYear.DataSource = last50Years;
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, "Year");

            var lstDay = Enumerable.Range(1, 31);
            ddlDay.DataSource = lstDay;
            ddlDay.DataBind();
            ddlDay.Items.Insert(0, "Day");


            ddlMonth.DataSource = DateTimeFormatInfo.CurrentInfo.MonthNames;
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, "month");


            /// Graduation countriy 


            ddlGraduationCountry.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 18).ToList(); ;
            ddlGraduationCountry.DataTextField = "Name";
            ddlGraduationCountry.DataValueField = "Id";
            ddlGraduationCountry.DataBind();


            /// 	Nationality

            ddlNationality.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 17).ToList(); ;
            ddlNationality.DataTextField = "Name";
            ddlNationality.DataValueField = "Id";
            ddlNationality.DataBind();


        }

        protected void ddlFieldOfBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSkiles.Enabled = true;
            var context = new HireMeEntities();

            int parentId = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
            ddlSkiles.DataSource = context.Lookups.Where(x => x.ParentId == parentId).ToList(); ;
            ddlSkiles.DataTextField = "Name";
            ddlSkiles.DataValueField = "Id";
            ddlSkiles.DataBind();

        }

        protected void ddlGraduationCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new HireMeEntities();

            ddlGraduationUniversity.Enabled = true;
            int parentId = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
            ddlGraduationUniversity.DataSource = context.Lookups.Where(x => x.ParentId == parentId).ToList(); ;
            ddlGraduationUniversity.DataTextField = "Name";
            ddlGraduationUniversity.DataValueField = "Id";
            ddlGraduationUniversity.DataBind();

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();

            Guid userId = new Guid(Request.QueryString["UserId"]);

            var user = context.Individuals.Where(aat => aat.UserId == userId).FirstOrDefault();
            if (user.CvAttachment != null)
            {


                string path =user.CvAttachment; //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;

                            Default:
                            type = "";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + name);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End(); //give POP to user for file downlaod
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}