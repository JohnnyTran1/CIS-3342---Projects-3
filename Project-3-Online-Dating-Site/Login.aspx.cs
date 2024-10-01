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
    public partial class Login : System.Web.UI.Page
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
            LoginClass loginClass = new LoginClass();
            bool checkInfo = loginClass.DetectUsernameAndPassword(txtUsername.Text, txtPassword.Text);
            if (!checkInfo)
            {
                lblCheckError.Text = "Incorrect Username/Password!";
                lblCheckError.Visible = true;
                return;
            }
            else
            {
                lblCheckError.Visible = false;
                lblCheckError.Text = "";
            }
            if (Page.IsValid) {
                try
                {
                    int userId = loginClass.LoginUser(txtUsername.Text, txtPassword.Text);

                    Session["UserID"] = userId;
                    Response.Redirect("Home.aspx");

                    //DataSet ds = objDB.GetDataSet(objCommand);
                    //if (ds.Tables[0].Rows.Count == 1) {
                    //    Response.Redirect("Home.aspx");
                    //}
                }
                catch (Exception ex)
                {
                    lblCheckError.Text = "Login failed: " + ex.Message;
                }
            }
        }


        protected void rfvUserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtUsername.Text);
        }

        protected void rfvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = !string.IsNullOrWhiteSpace(txtPassword.Text);
        }
    }
}