using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using OnlineDatingSiteLibrary;

namespace Project_3_Online_Dating_Site
{
    public partial class ModifyProfile : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                State();

                int userId = Convert.ToInt32(Session["UserID"].ToString());
                ModifyProfileClass modifyProfile = new ModifyProfileClass();
                DataRow row = modifyProfile.GetProfileData(userId);
                

                txtUserName.Text = row["Username"].ToString();
                txtFullName.Text = row["FullName"].ToString();
                txtEmail.Text = row["EmailAddress"].ToString();
                txtPassword.Text = row["Password"].ToString();
                txtVerifyPassword.Text = row["Password"].ToString();
                txtStreet.Text = row["Street"].ToString();
                txtCity.Text = row["City"].ToString();
                ddlState.SelectedValue = row["State"].ToString();
                txtZipCode.Text = row["ZipCode"].ToString();
                txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                txtOccupation.Text = row["Occupation"].ToString();
                txtAge.Text = row["Age"].ToString();
                txtWeight.Text = row["Weight"].ToString();
                txtProfilePhotoURL.Text = row["PhotoURL"].ToString();
                txtInterests.Text = row["Interests"].ToString();
                txtLikes.Text = row["Likes"].ToString();
                txtDislikes.Text = row["Dislikes"].ToString();
                txtFavoritesRestaurants.Text = row["FavoriteRestaurant"].ToString();
                txtFavoritesBooks.Text = row["FavoriteBook"].ToString();
                txtFavoritesMovies.Text = row["FavoriteMovie"].ToString();
                txtFavoritesPoems.Text = row["FavoritePoem"].ToString();
                txtFavoritesQuotes.Text = row["FavoriteQuote"].ToString();
                txtFavoriteSayings.Text = row["FavoriteSaying"].ToString();
                txtGoals.Text = row["Goals"].ToString();
                string commitmentTypeValue = row["CommitmentType"].ToString();
                PrefillCommitmentType(commitmentTypeValue);
                txtDescription.Text = row["Description"].ToString();
                if (row["Status"] != DBNull.Value)
                {
                    chkHideProfile.Checked = Convert.ToBoolean(row["Status"]);
                }
                else
                {
                    chkHideProfile.Checked = false;
                }

                Session["UserID"] = userId;
                //PrefillCommitmentType(commitmentTypeValue);
            }
        }

         private void State()
        {
            SqlCommand objCommandState = new SqlCommand();
            objCommandState.CommandType = CommandType.StoredProcedure;
            objCommandState.CommandText = "DisplayState";
            ddlState.DataSource = objDB.GetDataSet(objCommandState);
            //https://cis-iis2.temple.edu/users/pascucci/cis3342/StoredProcedureExample3_codebehind.htm
            //Pascuii webstie talks about datatextfield and datavalue field
            ddlState.DataTextField = "USStateAbbreviations";
            ddlState.DataValueField = "USStateAbbreviations";
            ddlState.DataBind();


            ddlState.Items.Insert(0, new ListItem("--Select a State--", ""));
            ddlState.Items.RemoveAt(1);
            //DataSet ds = objDB.GetDataSet(objCommand);
        }

        private void PrefillCommitmentType(string commitmentTypeValue)
        {
            switch (commitmentTypeValue)
            {
                case "CasualDating":
                    radCasualDating.Checked = true;
                    break;
                case "ExclusiveDating":
                    radExclusiveDating.Checked = true;
                    break;
                case "CommittedRelationship":
                    radCommittedRelationship.Checked = true;
                    break;
                case "Engaged":
                    radEngaged.Checked = true;
                    break;
                case "OpenRelationship":
                    radOpenRelationship.Checked = true;
                    break;
                case "FriendsWithBenefits":
                    radFriendsWithBenefits.Checked = true;
                    break;
                default:
                    break;
            }
        }

        protected void rfvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"(?=.*[a-zA-Z0-9]).*@$");
        }

        protected void rfvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtFullName.Text, @"^[a-zA-Z]+( [a-zA-Z]+)*$");
        }

        protected void rfvUserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text, @"^[a-zA-Z0-9]+$");
        }

        protected void rfvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-zA-Z])(?=.*\d).+$");
        }

        protected void rfvStreet_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtStreet.Text);
        }

        protected void rfvCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, @"^[a-zA-Z]]+( [a-zA-Z]+)*$");
        }

        protected void rfvState_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = ddlState.SelectedValue != "";
        }

        protected void rfvZipCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtZipCode.Text, @"^[0-9]+$");
        }

        protected void rfvPhoneNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10}$");
        }

        protected void rfvProfilePhotoURL_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtProfilePhotoURL.Text);
        }

        protected void rfvOccupation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtOccupation.Text, @"^[a-zA-Z]+$");
        }

        protected void rfvAge_ServerValidate(object source, ServerValidateEventArgs args)
        {

            int age;
            bool isValidAge = int.TryParse(txtAge.Text, out age) && age >= 18 && age <= 100;
            args.IsValid = isValidAge;
        }

        protected void rfvWeight_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtWeight.Text, @"^[0-9]+$");
        }

        protected void rfvLikes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtLikes.Text);
        }

        protected void rfvInterests_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtInterests.Text);
        }

        protected void rfvDislikes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtDislikes.Text);
        }

        protected void rfvGoals_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtGoals.Text);
        }

        protected void rfvDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtDescription.Text); 
        }

        protected void rfvFavoriteResaurant_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesRestaurants.Text);
        }

        protected void rfvFavoriteMovies_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesMovies.Text);
        }

        protected void rfvFavoriteBooksServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesBooks.Text);
        }

        protected void rfvFavoritePoems_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesPoems.Text);
        }

        protected void rfvFavoriteQuotes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesQuotes.Text);

        }

        protected void rfvFavoriteSayings_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoriteSayings.Text);
        }

        protected void rfvCommitmentType_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            

            int userId = Convert.ToInt32( Session["UserID"].ToString());
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string emailAddress = txtEmail.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string state = ddlState.SelectedValue;
            int zipCode = int.Parse(txtZipCode.Text);
            string phoneNumber = txtPhoneNumber.Text;
            string occupation = txtOccupation.Text;
            int age = int.Parse(txtAge.Text);
            int weight = int.Parse(txtWeight.Text);
            string photoURL = txtProfilePhotoURL.Text;
            string interests = txtInterests.Text;
            string likes = txtLikes.Text;
            string dislikes = txtDislikes.Text;
            string favoriteRestaurant = txtFavoritesRestaurants.Text;
            string favoriteMovie = txtFavoritesMovies.Text;
            string favoriteBook = txtFavoritesBooks.Text;
            string favoritePoem = txtFavoritesPoems.Text;
            string favoriteQuote = txtFavoritesQuotes.Text;
            string favoriteSaying = txtFavoriteSayings.Text;
            string goals = txtGoals.Text;
            string commitmentType = GetSelectedCommitmentType();
            string description = txtDescription.Text;
            bool status = chkHideProfile.Checked;

            ModifyProfileClass modifyProfile = new ModifyProfileClass();
            modifyProfile.UpdateProfile(userId, username, password, fullName, 
                emailAddress, street, city, state, zipCode, phoneNumber, occupation, 
                age, weight, photoURL, interests, likes, dislikes, favoriteRestaurant, 
                favoriteMovie, favoriteBook, favoritePoem, favoriteQuote, favoriteSaying, goals, 
                commitmentType, description, status);

            //lbl2.Text = UserId.ToString();

            //SqlParameter outputParameterProfileId = new SqlParameter("@ProfileID", SqlDbType.Int);
            //outputParameterProfileId.Direction = ParameterDirection.Output;
            //objCommand.Parameters.Add(outputParameterProfileId);


            //objDB.DoUpdateUsingCmdObj(objCommand);

            //int ProfileId = (int)objCommand.Parameters["@ProfileId"].Value;

            //lbl1.Text = UserId.ToString();
            //lbl2.Text = ProfileId.ToString();

            Session["UserID"] = userId;
            Response.Redirect("ViewProfile.aspx");

        }

        private string GetSelectedCommitmentType()
        {
            if (radCasualDating.Checked)
                return radCasualDating.Value;
            if (radExclusiveDating.Checked)
                return radExclusiveDating.Value;
            if (radCommittedRelationship.Checked)
                return radCommittedRelationship.Value;
            if (radEngaged.Checked)
                return radEngaged.Value;
            if (radOpenRelationship.Checked)
                return radOpenRelationship.Value;
            if (radFriendsWithBenefits.Checked)
                return radFriendsWithBenefits.Value;

            return null;
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

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

