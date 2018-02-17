using HireMe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HireMe.UI.Pages.Company
{
    public partial class PostJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new HireMeEntities();
            /// jobtype

            ddlJobType.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 5).ToList(); ;
            ddlJobType.DataTextField = "Name";
            ddlJobType.DataValueField = "Id";
            ddlJobType.DataBind();


            /// level of experience 


            ddlExperienceLevel.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 4).ToList(); ;
            ddlExperienceLevel.DataTextField = "Name";
            ddlExperienceLevel.DataValueField = "Id";
            ddlExperienceLevel.DataBind();



            ddlRole.DataSource = context.Lookups.Where(x => x.LookupCategoryId == 3).ToList(); 
            ddlRole.DataTextField = "Name";
            ddlRole.DataValueField = "Id";
            ddlRole.DataBind();


            





        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new HireMeEntities();

            lstSkils.DataSource= context.Lookups.Where(x => x.LookupCategoryId == 3).ToList();
            lstSkils.DataTextField = "Name";
            lstSkils.DataValueField = "Id";
            lstSkils.DataBind();
        }
    }
}