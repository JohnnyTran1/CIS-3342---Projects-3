using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace Project_3_Online_Dating_Site
{

    public partial class Home : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string strSQL;
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DisplayUsers";
                String UserId = Session["UserID"].ToString();
                SqlParameter inputParameterUserID = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
                objCommand.Parameters.Add(inputParameterUserID);
                
                rptUsers.DataSource = objDB.GetDataSet(objCommand);
                rptUsers.DataBind();

                State();
                CommitmentType();

                int incomingRequestsCount = IncomingRequestCount();
                lblIncomingRequests.Text = $"You have " + incomingRequestsCount +" incoming date request(s).";

                int incomingMatchesCount = IncomingMatchesCount();
                lblIncomingMatches.Text = $"You match with " + incomingMatchesCount +" user(s).";
            }
        }
        
        private void State()
        {
            SqlCommand objCommandState = new SqlCommand();
            objCommandState.CommandType = CommandType.StoredProcedure;
            objCommandState.CommandText = "DisplayState";

            ddlState.DataSource = objDB.GetDataSet(objCommandState);
            //Pascucci website stored procedure example 2 talks about datatxtfield and datavaluefield
            //https://cis-iis2.temple.edu/users/pascucci/cis3342/StoredProcedureExample2_codebehind.htm
            ddlState.DataTextField = "USStateAbbreviations";
            ddlState.DataValueField = "USStateAbbreviations";
            ddlState.DataBind();

            //DataSet ds = objDB.GetDataSet(objCommand);
        }

        private void CommitmentType()
        {
            SqlCommand objCommandCommitmentType = new SqlCommand();
            objCommandCommitmentType.CommandType = CommandType.StoredProcedure;
            objCommandCommitmentType.CommandText = "DisplayCommitmentType";

            ddlCommitmentType.DataSource = objDB.GetDataSet(objCommandCommitmentType);
            //Pascucci website stored procedure example 2 talks about datatxtfield and datavaluefield
            //https://cis-iis2.temple.edu/users/pascucci/cis3342/StoredProcedureExample2_codebehind.htm
            ddlCommitmentType.DataTextField = "CommitmentType";
            ddlCommitmentType.DataValueField = "CommitmentType";
            ddlCommitmentType.DataBind();
        }

        protected void btnViewProfile_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("ViewProfile.aspx");
        }


        protected void btnFilterSearch_Click(object sender, EventArgs e)
        {
            //SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "dbo.FilterDate";

            String userId = Session["UserID"].ToString();

            SqlParameter userIdParameter = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(userIdParameter);

            SqlParameter commitmentTypeParameter = new SqlParameter("@GetCommitmentType", ddlCommitmentType.SelectedValue);
            objCommand.Parameters.Add(commitmentTypeParameter);

            SqlParameter StateParameter = new SqlParameter("@GetStateType", ddlState.SelectedValue);
            objCommand.Parameters.Add(StateParameter);

            SqlParameter CityParameter = new SqlParameter("@GetCity", txtCity.Text);
            objCommand.Parameters.Add(CityParameter);

            SqlParameter OccupationParameter = new SqlParameter("@GetOccupation", txtOccupation.Text);
            objCommand.Parameters.Add(OccupationParameter);

            SqlParameter InterestsParameter = new SqlParameter("@GetInterests", txtInterest.Text);
            objCommand.Parameters.Add(InterestsParameter);

            rptUsers.DataSource = objDB.GetDataSet(objCommand);

            rptUsers.DataBind();
        }

        protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.mobilecontrols.command.commandname?view=netframework-4.8.1
            //Commandname raised the event
            if (e.CommandName == "ViewProfile")
            {
                //String UserId = Session["UserID"].ToString();

                string SelectedUserId = e.CommandArgument.ToString();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DisplayLoginUser";

                SqlParameter userIdParameter = new SqlParameter("@EnterUserID", Convert.ToInt32(SelectedUserId));
                objCommand.Parameters.Add(userIdParameter);

                rptViewProfile.DataSource = objDB.GetDataSet(objCommand);
                rptViewProfile.DataBind();

                //lbl1.Text = SelectedUserId;
            }
        }


        protected void rptProfileView_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.mobilecontrols.command.commandname?view=netframework-4.8.1
            //Commandname raised the event
            if (e.CommandName == "Like")
           {
               String UserId = Session["UserID"].ToString();

                string SelectedUserId = e.CommandArgument.ToString();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "LikingUser";

                SqlParameter parameterLiker = new SqlParameter("@Liker", Convert.ToInt32(UserId));
                objCommand.Parameters.Add(parameterLiker);

                SqlParameter parameterLikee = new SqlParameter("@Likee", Convert.ToInt32(SelectedUserId));
                objCommand.Parameters.Add(parameterLikee);

                SqlParameter parameterTimeStamp = new SqlParameter("@TimeStamp", DateTime.Now.ToString());
                objCommand.Parameters.Add(parameterTimeStamp);

                objDB.DoUpdate(objCommand);

                //objCommand.Parameters.Clear();
                //objCommand.CommandType = CommandType.StoredProcedure;
                //objCommand.CommandText = "Matching";
                //SqlParameter inputParameterFirstId = new SqlParameter("@EnterLikeFirstId", Convert.ToInt32(UserId));
                //objCommand.Parameters.Add(inputParameterFirstId);

                //SqlParameter inputParameterLikeSecondId = new SqlParameter("@EnterLikeSecondId", Convert.ToInt32(SelectedUserId));
                //objCommand.Parameters.Add(inputParameterLikeSecondId);

                //SqlParameter parameterMatchTimeStamp = new SqlParameter("@EnterMatchTimeStamp", DateTime.Now.ToString());
                //objCommand.Parameters.Add(parameterMatchTimeStamp);

                //objDB.DoUpdate(objCommand);

            }
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

        protected int IncomingRequestCount()
        {
            SqlCommand objCommandAlert = new SqlCommand();
            objCommandAlert.CommandType = CommandType.StoredProcedure;
            objCommandAlert.CommandText = "GetIncomingDateRequestCount";
            String UserId = Session["UserID"].ToString();
            SqlParameter inputParameterUserID = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
            objCommandAlert.Parameters.Add(inputParameterUserID);

            DataSet result = objDB.GetDataSet(objCommandAlert);
            if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(result.Tables[0].Rows[0][0]);
            }
            return 0;
        }


        protected int IncomingMatchesCount()
        {
            SqlCommand objCommandAlert = new SqlCommand();
            objCommandAlert.CommandType = CommandType.StoredProcedure;
            objCommandAlert.CommandText = "GetIncomingMatchCount";
            String UserId = Session["UserID"].ToString();
            SqlParameter inputParameterUserID = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
            objCommandAlert.Parameters.Add(inputParameterUserID);

            DataSet result = objDB.GetDataSet(objCommandAlert);
            int totalMatchesCount = 0;

            if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    totalMatchesCount += Convert.ToInt32(row["MatchCount"]);
                }
            }

            return totalMatchesCount;
        }

        protected void btnDatePlan_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("DatePlans.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            String UserId = Session["UserID"].ToString();
            Session["UserID"] = UserId;
            Response.Redirect("Home.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}