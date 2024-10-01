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
    public class LoginClass
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public bool DetectUsernameAndPassword(string username, string password)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckUsernameAndPasswordIsCorrect";

            SqlParameter inputparameterUserName = new SqlParameter("@EnterUsername", username);
            objCommand.Parameters.Add(inputparameterUserName);

            SqlParameter inputparameterPassword = new SqlParameter("@EnterPassword", password);
            objCommand.Parameters.Add(inputparameterPassword);

            SqlParameter outputParameterCheckInfo = new SqlParameter("@CorrectInfo", SqlDbType.Bit);
            outputParameterCheckInfo.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameterCheckInfo);


            objDB.GetDataSet(objCommand);
            return Convert.ToBoolean(outputParameterCheckInfo.Value);
        }

        public int LoginUser(string username, string password)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Login";

            SqlParameter inputparameterUserName = new SqlParameter("@EnterUsername", username);
            objCommand.Parameters.Add(inputparameterUserName);

            SqlParameter inputparameterPassword = new SqlParameter("@EnterPassword", password);
            objCommand.Parameters.Add(inputparameterPassword);

            SqlParameter outputParameterUserId = new SqlParameter("@UserId", SqlDbType.Int);
            outputParameterUserId.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameterUserId);

            objDB.GetDataSet(objCommand);

            return (int)objCommand.Parameters["@UserId"].Value;
        }
    }
}
