using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Utilities;
using System.Data.Odbc;
using OnlineDatingSiteLibrary;
namespace Project_3_Online_Dating_Site
{
    public partial class Date : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string strSQL;
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int userId = Convert.ToInt32( Session["UserID"].ToString());
                DateClass dateClass = new DateClass();
                

                rptRequestingDate.DataSource = dateClass.GetMatchingProfiles(userId);
                rptRequestingDate.DataBind();


                rptReceivingDateRequests.DataSource = dateClass.ReceivingDateRequest(userId);
                rptReceivingDateRequests.DataBind();

                rptViewDateRequestStatus.DataSource = dateClass.ViewDateRequestStatus(userId);
                rptViewDateRequestStatus.DataBind();

            }
        }

        protected void rptRequestingDate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            objCommand.Parameters.Clear();
            if (e.CommandName == "RequestingDate")
            {
                int ReceiverID = Convert.ToInt32(e.CommandArgument);
                int SenderID = Convert.ToInt32(Session["UserID"].ToString());

                DateClass reqestingdate = new DateClass();
                reqestingdate.RequestingADate(SenderID, ReceiverID);
            }
        }

        protected void rptReceivingDateRequests_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DateClass dateClass = new DateClass();
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            int senderId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "AcceptRequest")
            {
                dateClass.AcceptRequest(senderId, userId);
            }
            else if (e.CommandName == "DeclineRequest")
            {
                dateClass.DeclineDateRequest(senderId, userId);
            }

            rptReceivingDateRequests.DataSource = dateClass.ReceivingDateRequest(userId);
            rptReceivingDateRequests.DataBind();

            
            rptViewDateRequestStatus.DataSource = dateClass.ViewDateRequestStatus(userId);
            rptViewDateRequestStatus.DataBind();
        }

        protected void rptViewDateRequestStatis_ItemCommand(object source, RepeaterCommandEventArgs e)
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