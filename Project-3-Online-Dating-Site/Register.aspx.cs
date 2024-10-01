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
    public partial class Register : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtEmail.Text == "" ||
            //    txtFullName.Text == "" ||
            //    txtPassword.Text == "" ||
            //    txtUserName.Text == "" ||
            //    txtVerifyPassword.Text == "")
            //{
            //    lblCheckError.Text = "All fields must be filled out.";
            //    return;
            //}
            UserRegistration userReg = new UserRegistration();

            bool checkUsernameUnique = userReg.CheckUsernameUnique(txtUserName.Text);

            if (!checkUsernameUnique)
            {
                lblCheckError.Text = "The username " + txtUserName.Text + " is taken. Please choose a different username.";
                lblCheckError.Visible = true;
                return;
            }
            else
            {
                lblCheckError.Visible = false;
                lblCheckError.Text = "";
            }

            if (Page.IsValid)
            {
                try
                {
                    int userId = userReg.RegisterUser(txtUserName.Text, txtPassword.Text, txtFullName.Text, txtEmail.Text);

                    Session["UserID"] = userId;

                    //lblFullName.Text = userId.ToString();

                    Response.Redirect("ManageProfile.aspx");
                }
                catch (Exception ex)
                {
                    lblCheckError.Text = "Registration failed: " + ex.Message;
                }
                
            }

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
        protected void rfvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"(?=.*[a-zA-Z0-9]).*@$");
        }
        protected void rfvVerifyPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtPassword.Text == txtVerifyPassword.Text)
            {
                args.IsValid = true;

            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}
