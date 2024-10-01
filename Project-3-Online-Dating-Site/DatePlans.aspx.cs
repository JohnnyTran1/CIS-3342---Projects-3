using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using Utilities;
using System.Data.Odbc;
using System.Windows.Input;

namespace Project_3_Online_Dating_Site
{
    public partial class PlanDate : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        string strSQL;
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "ViewAllAcceptDateRequest";
                String UserId = Session["UserID"].ToString();
                SqlParameter inputParameterMatchingId = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
                objCommand.Parameters.Add(inputParameterMatchingId);

                rptViewDateRequestStatus.DataSource = objDB.GetDataSet(objCommand);
                rptViewDateRequestStatus.DataBind();

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "ViewExistingDatePlans";
                SqlParameter inputParameterRecivingDateRequest = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
                objCommand.Parameters.Add(inputParameterRecivingDateRequest);

                rptViewPlans.DataSource = objDB.GetDataSet(objCommand);
                rptViewPlans.DataBind();
            }
        }

        protected void rptViewDateRequestStatis_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "StartPlan")
            {
                string selectedUserId = e.CommandArgument.ToString();

                ViewState["SelectedUserId"] = selectedUserId;

            }
        }

        protected void rptSendDatePlan_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            objCommand.Parameters.Clear();
            String UserId = Session["UserID"].ToString();

            string selectedUserId = ViewState["SelectedUserId"] as string;

            //TextBox txtDate = (TextBox)e.Item.FindControl("txtDate");
            //TextBox txtTime = (TextBox)e.Item.FindControl("txtTime");
            //TextBox txtLocation = (TextBox)e.Item.FindControl("txtLocation");
            //TextBox txtDescription = (TextBox)e.Item.FindControl("txtDescription");

            //int rowIndex = e.Item.ItemIndex;
            //string SelectedUserId = e.CommandArgument.ToString();

            //string date = txtDate.Text;
            //string time = txtTime.Text;
            //string location = txtLocation.Text;
            //string description = txtDescription.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "StartADatePlan";

            SqlParameter parameterSendDrId = new SqlParameter("@EnterSenderID", Convert.ToInt32(UserId));
            objCommand.Parameters.Add(parameterSendDrId);

            SqlParameter parameterRecieverId = new SqlParameter("@EnterReceiverID", Convert.ToInt32(selectedUserId));
            objCommand.Parameters.Add(parameterRecieverId);

            SqlParameter inputparameterDate = new SqlParameter("@EnterDate", txtDateEnter.Text);
            objCommand.Parameters.Add(inputparameterDate);

            SqlParameter inputparameterTime = new SqlParameter("@EnterTime", txtTimeEnter.Text);
            objCommand.Parameters.Add(inputparameterTime);

            SqlParameter inputparameterLocation = new SqlParameter("@EnterLocation", txtLocationEnter.Text);
            objCommand.Parameters.Add(inputparameterLocation);

            SqlParameter inputparameterDescription = new SqlParameter("@EnterDescription", txtDescriptionEnter.Text);
            objCommand.Parameters.Add(inputparameterDescription);


            objDB.DoUpdate(objCommand);


            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ViewExistingDatePlans";
            SqlParameter inputParameterRecivingDateRequest = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
            objCommand.Parameters.Add(inputParameterRecivingDateRequest);

            rptViewPlans.DataSource = objDB.GetDataSet(objCommand);
            rptViewPlans.DataBind();

        }

        protected void rptViewPlans_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.mobilecontrols.command.commandname?view=netframework-4.8.1
            //Commandname raised the event
            if (e.CommandName == "Modtify")
            {
                string selectedUserId = e.CommandArgument.ToString();

                objCommand.Parameters.Clear();
                String UserId = Session["UserID"].ToString();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "PopulateExistingInputDatePlan";


                SqlParameter parameterSendDrId = new SqlParameter("@EnterSenderID", Convert.ToInt32(UserId));
                objCommand.Parameters.Add(parameterSendDrId);

                SqlParameter parameterRecieverId = new SqlParameter("@EnterReceiverID", Convert.ToInt32(selectedUserId));
                objCommand.Parameters.Add(parameterRecieverId);

                DataSet datamodify = objDB.GetDataSet(objCommand);

                DataRow row = datamodify.Tables[0].Rows[0];

                txtModifyDate.Text = row["Date"].ToString();
                txtModifyDescription.Text = row["DescriptionPlan"].ToString();
                txtModifyLocation.Text = row["Location"].ToString();
                txtModifyTime.Text = row["Time"].ToString();

                ViewState["ModifyUserId"] = selectedUserId;

            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            objCommand.Parameters.Clear();
            String UserId = Session["UserID"].ToString();

            string selectedUserId = ViewState["ModifyUserId"] as string;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateDatePlan";

            SqlParameter parameterSendDrId = new SqlParameter("@EnterSenderID", Convert.ToInt32(UserId));
            objCommand.Parameters.Add(parameterSendDrId);

            SqlParameter parameterRecieverId = new SqlParameter("@EnterReceiverID", Convert.ToInt32(selectedUserId));
            objCommand.Parameters.Add(parameterRecieverId);

            SqlParameter inputparameterDate = new SqlParameter("@EnterDate", txtModifyDate.Text);
            objCommand.Parameters.Add(inputparameterDate);

            SqlParameter inputparameterTime = new SqlParameter("@EnterTime", txtModifyTime.Text);
            objCommand.Parameters.Add(inputparameterTime);

            SqlParameter inputparameterLocation = new SqlParameter("@EnterLocation", txtModifyLocation.Text);
            objCommand.Parameters.Add(inputparameterLocation);

            SqlParameter inputparameterDescription = new SqlParameter("@EnterDescription", txtModifyDescription.Text);
            objCommand.Parameters.Add(inputparameterDescription);


            objDB.DoUpdate(objCommand);

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ViewExistingDatePlans";
            SqlParameter inputParameterRecivingDateRequest = new SqlParameter("@EnterUserID", Convert.ToInt32(UserId));
            objCommand.Parameters.Add(inputParameterRecivingDateRequest);

            rptViewPlans.DataSource = objDB.GetDataSet(objCommand);
            rptViewPlans.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
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

        protected void valLocation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtLocationEnter.Text);
        }

        protected void valDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtDateEnter.Text);
        }

        protected void valTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtTimeEnter.Text);
        }

        protected void valDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtDescriptionEnter.Text);
        }

        protected void valModifyLocation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtModifyLocation.Text);

        }

        protected void valModifyDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtModifyDate.Text);
        }

        protected void valModifyTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtModifyTime.Text);

        }

        protected void valModifyDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtModifyDescription.Text);
        }
    }
}