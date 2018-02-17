using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Individual
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillUserData();
                FillDropDowns();
                var context = new HireMeEntities();

            }
        }

        private void FillUserData()
        {
            var User = Membership.GetUser().UserName;
            var context = new HireMeEntities();
            var user = context.Individuals.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault();
            if (user != null)
            {
                //fill user Data
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            var User = Membership.GetUser();
            var user = context.Individuals.Where(x => x.aspnet_Users.UserName == User.UserName).FirstOrDefault();
            if (user == null)
            {
                // add new record 
                DAL.Individual obj = new DAL.Individual();
                obj.Name = txtFullName.Text;
                obj.UserId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User.UserName).FirstOrDefault().UserId;
                obj.Phone = Convert.ToInt32(txtPhone.Text);
                obj.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                obj.Gender = Convert.ToInt32(ddlGendr.SelectedValue);
                obj.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
                obj.BobMonth = (ddlLocation.SelectedValue);
                obj.BdDDay = Convert.ToInt32(ddlDay.SelectedValue);
                obj.BobYear = Convert.ToInt32(ddlYear.SelectedValue);
                obj.FieldOfBusiness = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
                obj.GraduationCountry = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
                obj.GraduationUniversity = Convert.ToInt32(ddlGraduationUniversity.SelectedValue);
                obj.YearsOfExperience = Convert.ToInt32(ddlYearsOfExperience.SelectedValue);
                obj.TypeOfEmployment = Convert.ToInt32(ddlTypeOfEmployment.SelectedValue);
                obj.AcademicDegree = Convert.ToInt32(ddlAcademicDegree.SelectedValue);
                if (fuCv.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fuCv.FileName);
                        string savePath = "D:\\Project\\uploads\\";
                        fuCv.SaveAs(savePath + filename);
                        obj.CvAttachment = savePath + filename;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                context.Individuals.Add(obj);
                context.SaveChanges();
            }
            else
            {
                user.Name = txtFullName.Text;
                user.UserId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User.UserName).FirstOrDefault().UserId;
                user.Phone = Convert.ToInt32(txtPhone.Text);
                user.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                user.Gender = Convert.ToInt32(ddlGendr.SelectedValue);
                user.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
                user.BobMonth = (ddlLocation.SelectedValue);
                user.BdDDay = Convert.ToInt32(ddlDay.SelectedValue);
                user.BobYear = Convert.ToInt32(ddlYear.SelectedValue);
                user.FieldOfBusiness = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
                user.GraduationCountry = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
                user.GraduationUniversity = Convert.ToInt32(ddlGraduationUniversity.SelectedValue);
                user.YearsOfExperience = Convert.ToInt32(ddlYearsOfExperience.SelectedValue);
                user.TypeOfEmployment = Convert.ToInt32(ddlTypeOfEmployment.SelectedValue);
                user.AcademicDegree = Convert.ToInt32(ddlAcademicDegree.SelectedValue);
                if (fuCv.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fuCv.FileName);
                        string savePath = "D:\\Project\\uploads\\";
                        fuCv.SaveAs(savePath + filename);
                        user.CvAttachment = savePath + filename;
                    }
                    catch (Exception ex)
                    {
                    }


                }


            }
        }
    }
}