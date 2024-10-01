using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project_3_Online_Dating_Site
{
    public partial class MemberProfile : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "";

                //objCommand.Parameters.AddWithValue("@EnterStreet", streetValue);
                //objCommand.Parameters.AddWithValue("@EnterUserID", userId); 
                State();
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "InsertProfile";

                SqlParameter inputparameterHideProfile = new SqlParameter("@EnterStatus", chkHideProfile.Checked);
                objCommand.Parameters.Add(inputparameterHideProfile);

                SqlParameter inputparameterStreet = new SqlParameter("@EnterStreet", txtStreet.Text);
                objCommand.Parameters.Add(inputparameterStreet);

                SqlParameter inputparameterCity = new SqlParameter("@EnterCity", txtCity.Text);
                objCommand.Parameters.Add(inputparameterCity);

                SqlParameter inputparameterState = new SqlParameter("@EnterState", ddlState.SelectedValue);
                objCommand.Parameters.Add(inputparameterState);

                SqlParameter inputparameterZipCode = new SqlParameter("@EnterZipCode", Int32.Parse(txtZipCode.Text));
                objCommand.Parameters.Add(inputparameterZipCode);

                SqlParameter inputparameterPhoneNumber = new SqlParameter("@EnterPhoneNumber", txtPhoneNumber.Text);
                objCommand.Parameters.Add(inputparameterPhoneNumber);

                SqlParameter inputparameterOccupation = new SqlParameter("@EnterOccupation", txtOccupation.Text);
                objCommand.Parameters.Add(inputparameterOccupation);

                SqlParameter inputparameterAge = new SqlParameter("@EnterAge", Int32.Parse(txtAge.Text));
                objCommand.Parameters.Add(inputparameterAge);

                SqlParameter inputparameterWeight = new SqlParameter("@EnterWeight", Int32.Parse(txtWeight.Text));
                objCommand.Parameters.Add(inputparameterWeight);

                SqlParameter inputparameterPhotoURL = new SqlParameter("@EnterPhotoURL", txtProfilePhotoURL.Text);
                objCommand.Parameters.Add(inputparameterPhotoURL);

                SqlParameter inputparameterInterests = new SqlParameter("@EnterInterests", txtInterests.Text);
                objCommand.Parameters.Add(inputparameterInterests);

                SqlParameter inputparameterLikes = new SqlParameter("@EnterLikes", txtLikes.Text);
                objCommand.Parameters.Add(inputparameterLikes);

                SqlParameter inputparameterDislikes = new SqlParameter("@EnterDislikes", txtDislikes.Text);
                objCommand.Parameters.Add(inputparameterDislikes);

                SqlParameter inputparameterFavoriteRestaurant = new SqlParameter("@EnterFavoriteRestaurant", txtFavoritesRestaurants.Text);
                objCommand.Parameters.Add(inputparameterFavoriteRestaurant);

                SqlParameter inputparameterFavoriteMovie = new SqlParameter("@EnterFavoriteMovie", txtFavoritesMovies.Text);
                objCommand.Parameters.Add(inputparameterFavoriteMovie);

                SqlParameter inputparameterFavoriteBook = new SqlParameter("@EnterFavoriteBook", txtFavoritesBooks.Text);
                objCommand.Parameters.Add(inputparameterFavoriteBook);

                SqlParameter inputparameterFavoritePoem = new SqlParameter("@EnterFavoritePoem", txtFavoritesPoems.Text);
                objCommand.Parameters.Add(inputparameterFavoritePoem);

                SqlParameter inputparameterFavoriteQuote = new SqlParameter("@EnterFavoriteQuote", txtFavoritesQuotes.Text);
                objCommand.Parameters.Add(inputparameterFavoriteQuote);

                SqlParameter inputparameterFavoriteSaying = new SqlParameter("@EnterFavoriteSaying", txtFavoriteSayings.Text);
                objCommand.Parameters.Add(inputparameterFavoriteSaying);

                SqlParameter inputparameterGoals = new SqlParameter("@EnterGoals", txtGoals.Text);
                objCommand.Parameters.Add(inputparameterGoals);

                string commitmentTypeValue = Request.Form["QCommitmentType"];
                SqlParameter inputparameterCommitmentType = new SqlParameter("@EnterCommitmentType", commitmentTypeValue);
                objCommand.Parameters.Add(inputparameterCommitmentType);

                SqlParameter inputparameterDescription = new SqlParameter("@EnterDescription", txtDescription.Text);
                objCommand.Parameters.Add(inputparameterDescription);

                String UserId = Session["UserID"].ToString();

                SqlParameter inputParameterUserId = new SqlParameter("@EnterUserID", Int32.Parse(UserId));
                objCommand.Parameters.Add(inputParameterUserId);

                SqlParameter outputParameterProfileId = new SqlParameter("@ProfileId", SqlDbType.Int);
           // https://stackoverflow.com/questions/290652/get-output-parameter-value-in-ado-net
                outputParameterProfileId.Direction = ParameterDirection.Output;
                // receive and store a value returned  from my query
                objCommand.Parameters.Add(outputParameterProfileId);


                //objDB.DoUpdateUsingCmdObj(objCommand);
                objDB.DoUpdate(objCommand);

                //int ProfileId = (int)objCommand.Parameters["@ProfileId"].Value;

                //lbl1.Text = UserId.ToString();
                //lbl2.Text = ProfileId.ToString();

                Session["UserID"] = UserId;
                Response.Redirect("Home.aspx");
            }


        }

        protected void rfvStreet_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0

            args.IsValid = !string.IsNullOrWhiteSpace(txtStreet.Text);

        }

        protected void rfvCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, @"^[a-zA-Z]+( [a-zA-Z]+)*$");
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
            //Only contains 10 digits numbers
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10}$");

        }

        protected void rfvProfilePhotoURL_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtProfilePhotoURL.Text);
        }

        protected void rfvOccupation_ServerValidate(object source, ServerValidateEventArgs args)
        {//https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
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
            args.IsValid = !string.IsNullOrWhiteSpace(txtLikes.Text);;
        }

        protected void rfvDislikes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtDislikes.Text);
        }

        protected void rfvGoals_ServerValidate(object source, ServerValidateEventArgs args)
        {

            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtGoals.Text); ;
        }

        protected void rfvFavoriteResaurant_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesRestaurants.Text); ;
        }

        protected void rfvFavoriteMovies_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesMovies.Text); ;
        }

        protected void rfvFavoriteBooksServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesBooks.Text); ;
        }

        protected void rfvFavoritePoems_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesPoems.Text); ;
        }

        protected void rfvFavoriteQuotes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoritesQuotes.Text); ;
        }

        protected void rfvFavoriteSayings_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtFavoriteSayings.Text); ;
        }

        protected void rfvCommitmentType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            string selectedValue = Request.Form["QCommitmentType"];
            args.IsValid = !string.IsNullOrEmpty(selectedValue);
        }

        protected void rfvDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtDescription.Text); ;
        }

        protected void rfvInterests_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtInterests.Text); ;
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