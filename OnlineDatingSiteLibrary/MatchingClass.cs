using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Utilities;
namespace OnlineDatingSiteLibrary
{
    public  class MatchingClass
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataSet GetMatchingProfiles(int userId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectMatching";
            SqlParameter inputParameterMatchingId = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterMatchingId);
            return objDB.GetDataSet(objCommand);
        }

        public void DeleteMatch(int userId, int likeSecondId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteMatches";
            SqlParameter inputParameterFirstID = new SqlParameter("@EnterFirstID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterFirstID);

            SqlParameter inputParameterLikeSecondId = new SqlParameter("@EnterSecondID", Convert.ToInt32(likeSecondId));
            objCommand.Parameters.Add(inputParameterLikeSecondId);

            objDB.DoUpdate(objCommand);

        }

           
    }
}
