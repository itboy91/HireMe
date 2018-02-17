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
    public partial class IndividualProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDownload.Visible = false;
            divSuccess.Visible = false;


            if (!IsPostBack)
            {
                FillDropDowns();
                FillUserData();

                var context = new HireMeEntities();

            }
        }

        private void FillUserData()
        {
            var User = Membership.GetUser().UserName;

            var context = new HireMeEntities();
            var user = context.Individuals.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault();
            var useremail = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().Email;
            txtEmail.Text = useremail;
            if (user != null)
            {
                btnDownload.Visible = true;
                //fill user Data
                txtFullName.Text = user.Name;
                Image1.ImageUrl = "data:image/png;base64," + GetIMageBase64(user.ImageUrl);
                Image1.Visible = true;
                txtPhone.Text = user.Phone.ToString();
                ddlDay.SelectedValue = user.BdDDay.ToString();
                ddlMonth.SelectedValue = user.BobMonth;
                ddlYear.SelectedValue = user.BobYear.ToString();
                ddlYearsOfExperience.SelectedValue = user.YearsOfExperience.ToString();
                ddlTypeOfEmployment.SelectedValue = user.TypeOfEmployment.ToString();
                ddlFieldOfBusiness.SelectedValue = user.FieldOfBusiness.ToString();
                lstSkils.Enabled = true;
                var lstSkills = context.UserSkills.Where(x => x.UserId == user.UserId).ToList();
                lstSkils.DataSource = context.Lookups.Where(x => x.ParentId == user.FieldOfBusiness).ToList(); ;
                lstSkils.DataTextField = "Name";
                lstSkils.DataValueField = "Id";
                lstSkils.DataBind();
                ddlLocation.SelectedValue = user.Location.ToString();
                ddlNationality.SelectedValue = user.Location.ToString();
                ddlTypeOfEmployment.SelectedValue = user.TypeOfEmployment.ToString();
                ddlAbilityToTravel.SelectedValue = user.AbilityToTravel.ToString();
                ddlRelationshipStatus.SelectedValue = user.AbilityToTravel.ToString();
                ddlGraduationCountry.SelectedValue = user.GraduationCountry.ToString();
                ddlGraduationUniversity.SelectedValue = user.GraduationUniversity.ToString();
                ddlAcademicDegree.SelectedValue = user.AcademicDegree.ToString();
                ddlGendr.SelectedValue = user.Gender.ToString();
                ddlRelationshipStatus.SelectedValue = user.RelationshipStatus.ToString();
                txtCoverletter.Text = user.CoverLetter.ToString();
                txtEmploymentHistory.Text = user.EmploymentHistory.ToString();

                ///txtMinimumSalary.txt=user.MinimumSalary














                lstSkils.SelectionMode = ListSelectionMode.Multiple;

                foreach (var item in lstSkills)
                {
                    if (lstSkils.Items.Count!=0)
                    lstSkils.Items.FindByValue(item.SkillId.ToString()).Selected = true;

                }

                ddlGraduationUniversity.Enabled = true;
                ddlGraduationUniversity.DataSource = context.Lookups.Where(x => x.ParentId == user.GraduationCountry).ToList(); ;
                ddlGraduationUniversity.DataTextField = "Name";
                ddlGraduationUniversity.DataValueField = "Id";
                ddlGraduationUniversity.DataBind();

                ddlGraduationUniversity.SelectedValue = user.GraduationUniversity.ToString();


            }


        }

        private void FillDropDowns()
        {
            var context = new HireMeEntities();


            /// location

            ddlLocation.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 20).ToList(); ;
            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "Id";
            ddlLocation.Items.Insert(0, new ListItem("Please Select a location", "Please Select a location"));
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, "Please select");

            /// fill gender
            /// 
            ddlGendr.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 1).ToList(); ;
            ddlGendr.DataTextField = "Name";
            ddlGendr.DataValueField = "Id";


            ddlGendr.DataBind();

            ddlGendr.Items.Insert(0, "Please select");
            //ddlGendr.Items.Insert(0, new ListItem("please select this field", "please select this field"));
            ///Field of busnnies

            ddlFieldOfBusiness.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 3).ToList(); ;
            ddlFieldOfBusiness.DataTextField = "Name";
            ddlFieldOfBusiness.DataValueField = "Id";

            ddlFieldOfBusiness.DataBind();


            ///

            ddlAbilityToTravel.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 24).ToList(); ;
            ddlAbilityToTravel.DataTextField = "Name";
            ddlAbilityToTravel.DataValueField = "Id";
            ddlAbilityToTravel.DataBind();
            ddlAbilityToTravel.Items.Insert(0, "Please select");
            ////

            ddlRelationshipStatus.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 25).ToList(); ;
            ddlRelationshipStatus.DataTextField = "Name";
            ddlRelationshipStatus.DataValueField = "Id";
            ddlRelationshipStatus.DataBind();
            ddlRelationshipStatus.Items.Insert(0, "Please select");

            ///years of experience

            ddlYearsOfExperience.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 4).ToList(); ;
            ddlYearsOfExperience.DataTextField = "Name";
            ddlYearsOfExperience.DataValueField = "Id";
            ddlYearsOfExperience.DataBind();
            ddlYearsOfExperience.Items.Insert(0, "Please select");


            ///type of employment

            ddlTypeOfEmployment.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 5).ToList(); ;
            ddlTypeOfEmployment.DataTextField = "Name";
            ddlTypeOfEmployment.DataValueField = "Id";
            ddlTypeOfEmployment.DataBind();
            ddlTypeOfEmployment.Items.Insert(0, "Please select");


            ///academic degree

            ddlAcademicDegree.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 6).ToList(); ;
            ddlAcademicDegree.DataTextField = "Name";
            ddlAcademicDegree.DataValueField = "Id";
            ddlAcademicDegree.DataBind();
            ddlAcademicDegree.Items.Insert(0, "Please select");



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
            ddlNationality.Items.Insert(0, "Please select");

            ddlNationality.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 17).ToList(); ;
            ddlNationality.DataTextField = "Name";
            ddlNationality.DataValueField = "Id";
            ddlNationality.DataBind();


        }
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlFieldOfBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSkils.Enabled = true;

            int parentId = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);


            var context = new HireMeEntities();

            lstSkils.DataSource = context.Lookups.Where(x => x.ParentId == parentId).ToList();
            lstSkils.DataTextField = "Name";
            lstSkils.DataValueField = "Id";
            lstSkils.DataBind();

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
                var userId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User.UserName).FirstOrDefault().UserId;
                DAL.Individual obj = new DAL.Individual();
                obj.Name = txtFullName.Text;
                obj.UserId = userId;
                obj.Phone = Convert.ToInt32(txtPhone.Text);
                obj.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                obj.Gender = Convert.ToInt32(ddlGendr.SelectedValue);
                obj.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
                obj.BobMonth = (ddlLocation.SelectedValue);
                obj.BdDDay = Convert.ToInt32(ddlDay.SelectedValue);
                obj.BobYear = Convert.ToInt32(ddlYear.SelectedValue);
                obj.FieldOfBusiness = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
                obj.GraduationCountry = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
                //obj.GraduationUniversity = Convert.ToInt32(ddlGraduationUniversity.SelectedValue);
                obj.YearsOfExperience = Convert.ToInt32(ddlYearsOfExperience.SelectedValue);
                obj.TypeOfEmployment = Convert.ToInt32(ddlTypeOfEmployment.SelectedValue);
                obj.AbilityToTravel = Convert.ToInt32(ddlAbilityToTravel.SelectedValue);
                obj.MinimumSalary = Convert.ToInt32(txtMinimumSalary.Text);
                obj.EmploymentHistory = txtEmploymentHistory.Text;

                obj.RelationshipStatus = Convert.ToInt32(ddlRelationshipStatus.SelectedValue);
                obj.CoverLetter = txtCoverletter.Text;
                obj.AcademicDegree = Convert.ToInt32(ddlAcademicDegree.SelectedValue);
                if (fuCv.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fuCv.FileName);
                        string savePath = "D:\\Project\\uploads\\" + userId;
                        fuCv.SaveAs(savePath + filename);
                        obj.CvAttachment = savePath + filename;
                    }
                    catch (Exception ex)
                    {
                    }
                }

                foreach (ListItem item in lstSkils.Items)
                {
                    if (item.Selected)
                    {
                        UserSkill objskill = new UserSkill();
                        objskill.UserId = userId;
                        objskill.SkillId = Convert.ToInt32(item.Value);
                        context.UserSkills.Add(objskill);

                    }
                }
                context.Individuals.Add(obj);
                context.SaveChanges();
                divSuccess.Visible = true;
            }
            else
            {
                user.Name = txtFullName.Text;
                user.UserId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User.UserName).FirstOrDefault().UserId;
                user.Phone = Convert.ToInt32(txtPhone.Text);
                user.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                user.Gender = Convert.ToInt32(ddlGendr.SelectedValue);
                user.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
                user.BobMonth = (ddlMonth.SelectedValue);
                user.BdDDay = Convert.ToInt32(ddlDay.SelectedValue);
                user.BobYear = Convert.ToInt32(ddlYear.SelectedValue);
                user.FieldOfBusiness = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
                user.GraduationCountry = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
                user.GraduationUniversity = Convert.ToInt32(ddlGraduationUniversity.SelectedValue);
                user.YearsOfExperience = Convert.ToInt32(ddlYearsOfExperience.SelectedValue);
                user.TypeOfEmployment = Convert.ToInt32(ddlTypeOfEmployment.SelectedValue);
                user.AcademicDegree = Convert.ToInt32(ddlAcademicDegree.SelectedValue);
                user.AbilityToTravel = Convert.ToInt32(ddlAbilityToTravel.SelectedValue);
                user.MinimumSalary = Convert.ToInt32(txtMinimumSalary.Text);
                user.EmploymentHistory = txtEmploymentHistory.Text;
                user.CoverLetter = txtCoverletter.Text;
                user.RelationshipStatus = Convert.ToInt32(ddlRelationshipStatus.SelectedValue);
                if (fuCv.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fuCv.FileName);
                        string savePath = "D:\\Project\\uploads\\" + user.UserId;
                        fuCv.SaveAs(savePath + filename);
                        user.CvAttachment = savePath + filename;
                    }
                    catch (Exception ex)
                    {
                    }


                }
                context.UserSkills.RemoveRange(context.UserSkills.Where(r => r.UserId == user.UserId));
                foreach (ListItem item in lstSkils.Items)
                {
                    if (item.Selected)
                    {
                        UserSkill obj = new UserSkill();
                        obj.UserId = user.UserId;
                        obj.SkillId = Convert.ToInt32(item.Value);
                        context.UserSkills.Add(obj);

                    }
                }
                context.SaveChanges();


            }
            divSuccess.Visible = true;

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            var User = Membership.GetUser();


            var user = context.Individuals.Where(aat => aat.aspnet_Users.UserName == User.UserName).FirstOrDefault();
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();


            var User = Membership.GetUser();


            var user = context.aspnet_Users.Where(x => x.UserName == User.UserName).FirstOrDefault();
            var individual = context.Individuals.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (individual == null)
            {
               var obj = new DAL.Individual();
                string savePath = "D:\\Project\\Images\\" + user.UserId;
                obj.UserId = user.UserId;
                if (fubImage.HasFile)
                {
                    if (!File.Exists(savePath))
                    {
                        System.IO.Directory.CreateDirectory(savePath);
                    }
                    try
                    {
                        string filename = Path.GetFileName(fubImage.FileName);
                        //filename = filename + user.UserId;
                        fubImage.SaveAs(savePath + "//" + filename);
                        obj.ImageUrl = savePath + "//" + filename;
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
                string savePath = "D:\\Project\\Images\\" + user.UserId;
                if (fubImage.HasFile)
                {
                    if (!File.Exists(savePath))
                    {
                        System.IO.Directory.CreateDirectory(savePath);
                    }
                    try
                    {
                        string filename = Path.GetFileName(fubImage.FileName);
                        //filename = filename + user.UserId;
                        fubImage.SaveAs(savePath + "//" + filename);
                        individual.ImageUrl = savePath + "//" + filename;
                    }
                    catch (Exception ex)
                    {
                    }
                    context.SaveChanges();

                }

            }

          

            System.IO.Stream fs = fubImage.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
            Image1.Visible = true;
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



    }
}