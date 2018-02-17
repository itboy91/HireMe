using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Company
{
    public partial class ViewIndividualProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid userId = new Guid(Request.QueryString["UserId"]);
                FillUserData(userId);
                HandlePageRequest();
            }
        }

        private void HandlePageRequest()
        {
            var context = new HireMeEntities();
            RequestedCv obj = new RequestedCv();
            var User = Membership.GetUser().UserName;
            var comapnyId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
            Guid userId = new Guid(Request.QueryString["UserId"]);

            var request = context.RequestedCvs.Where(x => x.IndividualId == userId && x.CompanyId == comapnyId).FirstOrDefault();
            if (request != null)
            {
                if (request.IsUnlocked == false)
                {
                    divUnderProcess.Style.Add("display", "block");
                    divUnlockAcount.Style.Add("display", "none");
                    divContactInfo.Style.Add("display", "none");
                }
                else
                {
                    divUnderProcess.Style.Add("display", "none");
                    divUnlockAcount.Style.Add("display", "none");
                    divContactInfo.Style.Add("display", "block");
                }
            }


        }

        private void FillUserData(Guid userId)
        {
            var context = new HireMeEntities();
            var user = context.Individuals.Where(aat => aat.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                ltrName.Text = user.Name;
                imgProfile.ImageUrl = "data:image/png;base64," + GetIMageBase64(user.ImageUrl);
                ltrCover.Text = user.CoverLetter;
                lblBirthOfDate.Text = user.BobMonth + "/" + user.BdDDay + "/" + user.BobYear;
                lblLocation.Text = context.Lookups.Where(x => x.Id == user.Location).FirstOrDefault().Name;
                lblNationality.Text= context.Lookups.Where(x => x.Id == user.Location).FirstOrDefault().Name;
                lblNationality.Text= context.Lookups.Where(x => x.Id == user.Nationality).FirstOrDefault().Name;
                lblGender.Text= context.Lookups.Where(x => x.Id == user.Gender).FirstOrDefault().Name;
                lblRelationshipStatus.Text= context.Lookups.Where(x => x.Id == user.RelationshipStatus).FirstOrDefault().Name;
                lblAbilityToTravel.Text= context.Lookups.Where(x => x.Id == user.AbilityToTravel).FirstOrDefault().Name;
                lblFieldOfBusiness.Text = context.Lookups.Where(x => x.Id == user.FieldOfBusiness).FirstOrDefault().Name;
                var lstSkills = context.UserSkills.Where(x => x.UserId == user.UserId).ToList();
                string Skillstxt = "";
                foreach (var item in lstSkills)
                {
                    var skill= context.Lookups.Where(x => x.Id == item.SkillId).FirstOrDefault().Name;
                    Skillstxt += "<span class=\"label label-info\">" + skill + "</span>  ";
                    lblSkiles.Text = Skillstxt;

                }
                lblGraduationCountry.Text = context.Lookups.Where(x => x.Id == user.GraduationCountry).FirstOrDefault().Name;
                lblGraduationUniversity.Text= context.Lookups.Where(x => x.Id == user.GraduationUniversity).FirstOrDefault().Name;
                lblPhone.Text = user.Phone.ToString();
                LblTypeOfEmployment.Text= context.Lookups.Where(x => x.Id == user.TypeOfEmployment).FirstOrDefault().Name;
                lblYearsOfExperience.Text= context.Lookups.Where(x => x.Id == user.YearsOfExperience).FirstOrDefault().Name;
                lblMinimumSalary.Text = user.MinimumSalary.ToString();
                lblEmoloymentHistory.Text = user.EmploymentHistory;
                lblEmil.Text= context.aspnet_Membership.Where(x => x.UserId == user.UserId).FirstOrDefault().Email;
                //txtPhone.Text = user.Phone.ToString();
                //ddlDay.SelectedValue = user.BdDDay.ToString();
                //ddlMonth.SelectedIndex = Convert.ToInt32(user.BobMonth);
                //ddlYear.SelectedValue = user.BobYear.ToString();
                //ddlYearsOfExperience.SelectedValue = user.YearsOfExperience.ToString();
                //ddlTypeOfEmployment.SelectedValue = user.TypeOfEmployment.ToString();

            }
            //throw new NotImplementedException();
        }

        public string GetIMageBase64(string path)
        {
            if (path != null)
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(path);
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            return "";
        }

        protected void btnUnlockAcount_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            RequestedCv obj = new RequestedCv();
            var User = Membership.GetUser().UserName;
            var comapnyId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
            Guid userId = new Guid(Request.QueryString["UserId"]);

            obj.CompanyId = comapnyId;
            obj.IndividualId = userId;
            obj.IsUnlocked = false;
            context.RequestedCvs.Add(obj);
            context.SaveChanges();

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();

            Guid userId = new Guid(Request.QueryString["UserId"]);

            var user = context.Individuals.Where(aat => aat.UserId == userId).FirstOrDefault();
            if (user.CvAttachment != null)
            {


                string path = user.CvAttachment; //get physical file path from server
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
    }
}