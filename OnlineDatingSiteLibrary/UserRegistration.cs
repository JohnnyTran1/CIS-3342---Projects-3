using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using Utilities;


namespace OnlineDatingSiteLibrary
{

    public class UserRegistration
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;
        public bool CheckUsernameUnique(string username)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckUsernameIsUnique";

            SqlParameter inputparameterUserName = new SqlParameter("@EnterUsername", username);
            objCommand.Parameters.Add(inputparameterUserName);

            SqlParameter outputParameterIsUsernameUnique = new SqlParameter("@CheckUnique", SqlDbType.Bit);
            outputParameterIsUsernameUnique.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameterIsUsernameUnique);


            objDB.GetDataSet(objCommand);

            bool checkUnique = Convert.ToBoolean(objCommand.Parameters["@CheckUnique"].Value);

            return checkUnique;
        }

        public int RegisterUser(string username, string password, string fullName, string email)
        {
            //https://cis-iis2.temple.edu/users/pascucci/cis3342/StoredProcedureExample1_codebehind.htm
            
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Registration";

            SqlParameter inputparameterUserName = new SqlParameter("@EnterUsername", username);
            objCommand.Parameters.Add(inputparameterUserName);

            SqlParameter inputparameterPassword = new SqlParameter("@EnterPassword", password);
            objCommand.Parameters.Add(inputparameterPassword);

            SqlParameter inputparameterFullName = new SqlParameter("@EnterFullName", fullName);
            objCommand.Parameters.Add(inputparameterFullName);

            SqlParameter inputparameterEmail = new SqlParameter("@EnterEmailAddress", email);

            objCommand.Parameters.Add(inputparameterEmail);

            SqlParameter outputParameterUserId = new SqlParameter("@UserId", SqlDbType.Int);
            outputParameterUserId.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameterUserId);

            objDB.DoUpdate(objCommand);

            int userId = (int)objCommand.Parameters["@UserId"].Value;
            return userId;
        }
    }
}
