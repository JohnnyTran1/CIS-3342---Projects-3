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

    public class ProfileData
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataRow GetProfilaData(int userId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ViewProfile";

            SqlParameter inputParameterUserID = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            inputParameterUserID.Direction = ParameterDirection.Input;
            inputParameterUserID.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameterUserID);

            DataSet profile = objDB.GetDataSet(objCommand);

            DataRow row = profile.Tables[0].Rows[0];
            return row;

        }
    }
}
