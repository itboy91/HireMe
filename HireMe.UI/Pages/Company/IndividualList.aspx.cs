using HireMe.DAL;
using HireMe.UI.DomainModel;
using HireMe.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Company
{
    public partial class IndividualList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                //this.BindRepeater();
                FillDlls();




            }
        }

        private void FillDlls()
        {
            var context = new HireMeEntities();



            ddlFieldOfBusiness.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 3).ToList(); ;
            ddlFieldOfBusiness.DataTextField = "Name";
            ddlFieldOfBusiness.DataValueField = "Id";
            ddlFieldOfBusiness.DataBind();

            ddlExperience.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 4).ToList(); ;
            ddlExperience.DataTextField = "Name";
            ddlExperience.DataValueField = "Id";
            ddlExperience.DataBind();

            ddlGraduationCountry.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 18).ToList(); ;
            ddlGraduationCountry.DataTextField = "Name";
            ddlGraduationCountry.DataValueField = "Id";
            ddlGraduationCountry.DataBind();


            ddlTypeOfEmployment.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 5).ToList(); ;
            ddlTypeOfEmployment.DataTextField = "Name";
            ddlTypeOfEmployment.DataValueField = "Id";
            ddlTypeOfEmployment.DataBind();

            ddlAcademicDegree.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 6).ToList(); ;
            ddlAcademicDegree.DataTextField = "Name";
            ddlAcademicDegree.DataValueField = "Id";
            ddlAcademicDegree.DataBind();



            ddlNationality.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 17).ToList(); ;
            ddlNationality.DataTextField = "Name";
            ddlNationality.DataValueField = "Id";
            ddlNationality.DataBind();


            ddlAbilityToTravel.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 24).ToList(); ;
            ddlAbilityToTravel.DataTextField = "Name";
            ddlAbilityToTravel.DataValueField = "Id";
            ddlAbilityToTravel.DataBind();



            ddlFieldOfBusiness.Items.Insert(0, "Please select");
            ddlExperience.Items.Insert(0, "Please select");
            ddlGraduationCountry.Items.Insert(0, "Please select");
            ddlTypeOfEmployment.Items.Insert(0, "Please select");
            ddlAcademicDegree.Items.Insert(0, "Please select");
            ddlNationality.Items.Insert(0, "Please select");
            ddlAbilityToTravel.Items.Insert(0, "Please select");
            ddlFieldOfBusiness.Items.Insert(0, "Please select");



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
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            var listIndividuals = context.Individuals.ToList();

            int FieldOfBusinesId = Convert.ToInt32(ddlFieldOfBusiness.SelectedValue);
            listIndividuals = listIndividuals.Where(x => x.FieldOfBusiness == FieldOfBusinesId).ToList();

            if (ddlAbilityToTravel.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlAbilityToTravel.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.AbilityToTravel == id).ToList();

            }
            if (ddlAcademicDegree.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlAcademicDegree.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.AcademicDegree == id).ToList();
            }
            if (ddlExperience.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlExperience.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.YearsOfExperience == id).ToList();
            }
            if (ddlGraduationCountry.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlGraduationCountry.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.GraduationCountry == id).ToList();
            }
            if (ddlNationality.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlNationality.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.Nationality == id).ToList();
            }if (ddlTypeOfEmployment.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(ddlTypeOfEmployment.SelectedValue);
                listIndividuals = listIndividuals.Where(x => x.TypeOfEmployment == id).ToList();
            }
            if(!string.IsNullOrEmpty(txtMinimumSalary.Text))
            {
                int min = Convert.ToInt32(txtMinimumSalary.Text);

                listIndividuals = listIndividuals.Where(x => x.MinimumSalary <= min).ToList();
            }

            var query = from emp in listIndividuals
                        select new
                        {
                            Name = emp.Name,
                            CoverLetter = emp.CoverLetter,
                            Percentage = GetSkillPercentage(emp.UserId),
                            ImageUrl = "data:image/png;base64," + GetIMageBase64(emp.ImageUrl),

                            //UserName = emp.aspnet_Membership.aspnet_Users.UserName,
                            //Email = emp.aspnet_Membership.Email,
                            Id = emp.UserId
                        };

            //grdCompany.PageSize = pagesize;
            rptUsers.DataSource = query.ToList().OrderByDescending(x => x.Percentage);
            rptUsers.DataBind();
        }
        
        private void BindRepeater()
        {
            var context = new HireMeEntities();
            var listIndividuals = context.Individuals.ToList();

            var query = from emp in listIndividuals
                        select new
                        {
                            Name = emp.Name,

                            Percentage = 0,
                            ImageUrl = "data:image/png;base64," + GetIMageBase64(emp.ImageUrl),
                            CoverLetter = emp.CoverLetter,

                            //UserName = emp.aspnet_Membership.aspnet_Users.UserName,
                            //Email = emp.aspnet_Membership.Email,
                            Id = emp.UserId
                        };

            //grdCompany.PageSize = pagesize;
            rptUsers.DataSource = query.ToList().OrderBy(x => x.Percentage); ;
            rptUsers.DataBind();
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
        
        public int GetSkillPercentage(Guid userId)
        {
            var context = new HireMeEntities();
            var lstUserSkils = context.UserSkills.Where(att => att.UserId == userId).ToList();
            if (lstUserSkils.Count() > 0)
            {
                var lstUserSkilsId = lstUserSkils.Select(x => x.SkillId);
                var lstSelectedSkils = new List<int>();
                foreach (ListItem item in lstSkils.Items)
                {
                    if (item.Selected)
                    {
                        lstSelectedSkils.Add(Convert.ToInt32(item.Value));

                    }
                }
                if (lstSelectedSkils.Count() > 0)
                {
                    var resultSet = lstUserSkilsId.Intersect<int>(lstSelectedSkils);
                    var xx = Convert.ToDouble(resultSet.Count());
                    var yy = Convert.ToDouble(lstSelectedSkils.Count());
                    double myPercentage = xx / yy * 100;
                    return Convert.ToInt32(myPercentage);
                }
                else
                {
                    return 0;
                }

            }
            else
                return 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            var UserIds = context.UserTypes.Where(x => x.UserType_lookupId == 220).ToList().Select(x => x.aspnet_Users.UserId);
            var listIndividuals = context.Individuals.Where(p => UserIds.Contains(p.UserId)).ToList();

            var query = from emp in listIndividuals
                        select new
                        {
                            Name = emp.Name,
                            CoverLetter = emp.CoverLetter,

                            Percentage = GetSkillPercentage(emp.UserId),
                            ImageUrl = "data:image/png;base64," + GetIMageBase64(emp.ImageUrl),

                            //UserName = emp.aspnet_Membership.aspnet_Users.UserName,
                            //Email = emp.aspnet_Membership.Email,
                            Id = emp.UserId
                        };

            //grdCompany.PageSize = pagesize;
            rptUsers.DataSource = query.ToList().OrderBy(x => x.Percentage);
            rptUsers.DataBind();
        }
        
        protected void lnkAddToFavorite_Command(object sender, CommandEventArgs e)
        {
            var User = Membership.GetUser().UserName;
            var context = new HireMeEntities();

            Guid indvId = new Guid(e.CommandArgument.ToString());
            CompanyFavourite obj = new CompanyFavourite();
            obj.IndividualId = indvId;
            obj.CompanyId = context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
            context.CompanyFavourites.Add(obj);
            context.SaveChanges();

            btnSearch_Click(sender, e);

        }

        protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var context = new HireMeEntities();

                var User = Membership.GetUser().UserName;
               Guid CompanyId= context.aspnet_Membership.Where(x => x.aspnet_Users.UserName == User).FirstOrDefault().UserId;
                HiddenField hfIndividualId = e.Item.FindControl("hfIndividualId") as HiddenField;
                Guid IndividualId = new Guid(hfIndividualId.Value);
                HtmlGenericControl divControl = e.Item.FindControl("divFavorite") as HtmlGenericControl;
                var IsFavorite = context.CompanyFavourites.Any(x => x.CompanyId == CompanyId && x.IndividualId == IndividualId);
                if (IsFavorite)
                    divControl.Visible = false;
            }
        }

        protected void lnkViewProfile_Command(object sender, CommandEventArgs e)
        {
            Guid indvId = new Guid(e.CommandArgument.ToString());
            Response.Redirect("~/Pages/Company/ViewIndividualProfile.aspx?UserId=" + indvId);
        }
    }
}
