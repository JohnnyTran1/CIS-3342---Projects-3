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
    public class DateClass
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

        public DataSet ReceivingDateRequest(int userId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ReceivingDateRequest";
            SqlParameter inputParameterRecivingDateRequest = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterRecivingDateRequest);

            return objDB.GetDataSet(objCommand);
        }


        public DataSet ViewDateRequestStatus(int userId)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ViewDateRequestStatus";
            SqlParameter inputParameterViewDateRequestStatus = new SqlParameter("@EnterUserID", Convert.ToInt32(userId));
            objCommand.Parameters.Add(inputParameterViewDateRequestStatus);

            return objDB.GetDataSet(objCommand);
        }

        public void RequestingADate(int SenderID, int ReceiverID)
        {
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "RequestingADate";
            SqlParameter inputParameterSenderId = new SqlParameter("@EnterSenderID", Convert.ToInt32(SenderID));
            objCommand.Parameters.Add(inputParameterSenderId);

            SqlParameter inputParameterReceiverId = new SqlParameter("@EnterReceiverID", Convert.ToInt32(ReceiverID));
            objCommand.Parameters.Add(inputParameterReceiverId);

            SqlParameter parameterRequestTimeStamp = new SqlParameter("@EnterRequestTimeStamp", DateTime.Now.ToString());
            objCommand.Parameters.Add(parameterRequestTimeStamp);

            objDB.DoUpdate(objCommand);
        }

        public void AcceptRequest(int senderID, int ReceiverID)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AcceptDateRequest";

            SqlParameter inputParameterSenderId = new SqlParameter("@EnterSenderId", Convert.ToInt32(senderID));
            objCommand.Parameters.Add(inputParameterSenderId);

            SqlParameter inputParameterReceiverId = new SqlParameter("@EnterReceiverId", Convert.ToInt32(ReceiverID));
            objCommand.Parameters.Add(inputParameterReceiverId);

            SqlParameter parameterResponseTimeStamp = new SqlParameter("@EnterResponseTimeStamp", DateTime.Now.ToString());
            objCommand.Parameters.Add(parameterResponseTimeStamp);

            objDB.DoUpdate(objCommand);
        }

        public void DeclineDateRequest(int senderID, int ReceiverID)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeclineDateRequest";
            SqlParameter inputParameterSenderId = new SqlParameter("@EnterSenderId", Convert.ToInt32(senderID));
            objCommand.Parameters.Add(inputParameterSenderId);

            SqlParameter inputParameterReceiverId = new SqlParameter("@EnterReceiverId", Convert.ToInt32(ReceiverID));
            objCommand.Parameters.Add(inputParameterReceiverId);

            SqlParameter parameterResponseTimeStamp = new SqlParameter("@EnterResponseTimeStamp", DateTime.Now.ToString());
            objCommand.Parameters.Add(parameterResponseTimeStamp);

            objDB.DoUpdate(objCommand);
        }

    }
}
