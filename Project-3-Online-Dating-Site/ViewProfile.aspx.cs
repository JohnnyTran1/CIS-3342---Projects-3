using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using OnlineDatingSiteLibrary;


namespace Project_3_Online_Dating_Site
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcommand = new SqlCommand();
        string strSQL;
        public void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                int userId =Convert.ToInt32( Session["UserID"].ToString());
                ProfileData profileData = new ProfileData();
                DataRow row = profileData.GetProfilaData(userId);
               
                lblUserUsername.Text = row["Username"].ToString();
                lblUserFullName.Text = row["FullName"].ToString();
                lblUserEmail.Text = row["EmailAddress"].ToString();
                lblUserPassword.Text = row["Password"].ToString();
                lblUserAddress.Text = row["Street"].ToString() + " " +row["City"].ToString() + ", " + row["State"].ToString() + " " + row["ZipCode"].ToString();
                lblUserPhoneNumber.Text = row["PhoneNumber"].ToString();
                lblUserOccupation.Text = row["Occupation"].ToString();
                lblUserAge.Text = row["Age"].ToString();
                lblUserWeight.Text = row["Weight"].ToString() + " lbs";
                imgDisplayPhotoURL.ImageUrl = row["PhotoURL"].ToString();
                lblUserInterests.Text = row["Interests"].ToString();
                lblUserLikes.Text = row["Likes"].ToString();
                lblUserDislikes.Text = row["Dislikes"].ToString();
                lblUserFavoriteRestaurant.Text = row["FavoriteRestaurant"].ToString();
                lblUserFavoriteBook.Text = row["FavoriteBook"].ToString();
                lblUserFavoriteMovie.Text = row["FavoriteMovie"].ToString();
                lblUserFavoritePoem.Text = row["FavoritePoem"].ToString() ; 
                lblUserFavoriteQuote.Text = row["FavoriteQuote"].ToString();
                lblUserFavoriteSaying.Text = row["FavoriteSaying"].ToString();
                lblUserGoals.Text = row["Goals"].ToString();
                lblUserCommitmentType.Text = row["CommitmentType"].ToString();
                lblUserDescription.Text = row["Description"].ToString();

                Session["UserID"] = userId;


            }

        }

        protected void btnEditProfile_Click1(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("ModifyProfile.aspx");
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