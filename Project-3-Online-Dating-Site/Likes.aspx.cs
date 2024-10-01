using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.Common;
using OnlineDatingSiteLibrary;
namespace Project_3_Online_Dating_Site
{
    public partial class Likes : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string strSQL;
        SqlCommand objCommand = new SqlCommand();
        LikeClass likeClass = new LikeClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32( Session["UserID"].ToString());



                rptLikeTheUserAccount.DataSource = likeClass.LikesTheUserAccount(userId);
                rptLikeTheUserAccount.DataBind();


                rptUserLikes.DataSource = likeClass.UserLikes(userId);
                rptUserLikes.DataBind();
            }
        }

        protected void rptLikeTheUserAccount_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.mobilecontrols.command.commandname?view=netframework-4.8.1
            //
            if (e.CommandName == "LikeThemBack")
            {
                int userId = Convert.ToInt32( Session["UserID"].ToString());

                int selectedUserId = Convert.ToInt32( e.CommandArgument.ToString());

                likeClass.LikingUser(userId, selectedUserId);

                likeClass.Matching(userId, selectedUserId);

            }
        }

        protected void rptUserLikes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Decline")
            {
                int likeeId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32( Session["UserID"].ToString());

                likeClass.DeleteUserLike(userId, likeeId);


                rptUserLikes.DataSource = likeClass.UserLikes(userId);
                rptUserLikes.DataBind();

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