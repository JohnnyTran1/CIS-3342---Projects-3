using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using OnlineDatingSiteLibrary;

namespace Project_3_Online_Dating_Site
{
    public partial class Matching : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string strSQL;
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32( Session["UserID"].ToString());
                MatchingClass matchingClass = new MatchingClass();
                matchingClass.GetMatchingProfiles(userId);

                rptMatching.DataSource = matchingClass.GetMatchingProfiles(userId);
                rptMatching.DataBind();
            }
        }

        protected void rptMatching_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Unmatch")
            {
                int LikeSecondId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32( Session["UserID"].ToString());

                MatchingClass matching = new MatchingClass();
                matching.DeleteMatch(userId, LikeSecondId);

                rptMatching.DataSource = matching.GetMatchingProfiles(userId);
                rptMatching.DataBind();
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("Home.aspx");
        }

        protected void btnViewProfile_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("ViewProfile.aspx");
        }

        protected void btnViewLikes_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("Likes.aspx");
        }

        protected void btnViewMatches_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("Matching.aspx");
        }

        protected void btnViewDate_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("Date.aspx");
        }

        protected void btnDatePlan_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("DatePlans.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }

        
}