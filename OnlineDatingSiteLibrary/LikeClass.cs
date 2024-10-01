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

    public  class LikeClass
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataSet LikesTheUserAccount(int userId)
        {
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "LikesTheUserAccount";
            SqlParameter inputParameterLikingUserID = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterLikingUserID);

            return objDB.GetDataSet(objCommand);


        }

        public DataSet UserLikes(int userId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UserLikes";
            SqlParameter inputParameterUserIDLike = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterUserIDLike);

            return objDB.GetDataSet(objCommand);
        }


        public void LikingUser(int userId, int selectedUserId)
        {
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "LikingUser";

            SqlParameter parameterLiker = new SqlParameter("@Liker", Convert.ToInt32(userId));
            objCommand.Parameters.Add(parameterLiker);

            SqlParameter parameterLikee = new SqlParameter("@Likee", Convert.ToInt32(selectedUserId));
            objCommand.Parameters.Add(parameterLikee);

            SqlParameter parameterTimeStamp = new SqlParameter("@TimeStamp", DateTime.Now.ToString());
            objCommand.Parameters.Add(parameterTimeStamp);

            objDB.DoUpdate(objCommand);
        }



        public void Matching(int userId, int selectedUserId)
        {

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Matching";
            SqlParameter inputParameterFirstId = new SqlParameter("@EnterLikeFirstId", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterFirstId);

            SqlParameter inputParameterLikeSecondId = new SqlParameter("@EnterLikeSecondId", Convert.ToInt32(selectedUserId));
            objCommand.Parameters.Add(inputParameterLikeSecondId);

            SqlParameter parameterMatchTimeStamp = new SqlParameter("@EnterMatchTimeStamp", DateTime.Now.ToString());
            objCommand.Parameters.Add(parameterMatchTimeStamp);

            objDB.DoUpdate(objCommand);
        }

        public void DeleteUserLike(int userId, int likeeId)
        {
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteUserLike";
            SqlParameter inputParameterLikerId = new SqlParameter("@LikerId", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterLikerId);

            SqlParameter inputParameterLikeeId = new SqlParameter("@LikeeId", Convert.ToInt32(likeeId));
            objCommand.Parameters.Add(inputParameterLikeeId);

            objDB.DoUpdate(objCommand);
        }

    }
}
