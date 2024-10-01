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
    public class ModifyProfileClass
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataRow GetProfileData(int userId)
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

        public void UpdateProfile(int userId, string username, string password, 
            string fullName, string emailAddress, string street, string city, string state, 
            int zipCode, string phoneNumber, string occupation, int age, int weight, string photoURL, 
            string interests, string likes, string dislikes, string favoriteRestaurant, string favoriteMovie, 
            string favoriteBook, string favoritePoem, string favoriteQuote, string favoriteSaying, string goals, 
            string commitmentType, string description, bool status)
        {
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateProfile";

            SqlParameter inputParameterUserID = new SqlParameter("@EnterUserID", userId);
            objCommand.Parameters.Add(inputParameterUserID);

            SqlParameter inputparameterUsername = new SqlParameter("@UpdateUsername", username);
            objCommand.Parameters.Add(inputparameterUsername);

            SqlParameter inputparameterPassword = new SqlParameter("@UpdatePassword", password);
            objCommand.Parameters.Add(inputparameterPassword);

            SqlParameter inputparameterFullName = new SqlParameter("@UpdateFullName", fullName);
            objCommand.Parameters.Add(inputparameterFullName);

            SqlParameter inputparameterEmailAddress = new SqlParameter("@UpdateEmailAddress", emailAddress);
            objCommand.Parameters.Add(inputparameterEmailAddress);

            SqlParameter inputparameterStreet = new SqlParameter("@UpdateStreet", street);
            objCommand.Parameters.Add(inputparameterStreet);

            SqlParameter inputparameterCity = new SqlParameter("@UpdateCity", city);
            objCommand.Parameters.Add(inputparameterCity);

            SqlParameter inputparameterState = new SqlParameter("@UpdateState", state);
            objCommand.Parameters.Add(inputparameterState);

            SqlParameter inputparameterZipCode = new SqlParameter("@UpdateZipCode", zipCode);
            objCommand.Parameters.Add(inputparameterZipCode);

            SqlParameter inputparameterPhoneNumber = new SqlParameter("@UpdatePhoneNumber", phoneNumber);
            objCommand.Parameters.Add(inputparameterPhoneNumber);

            SqlParameter inputparameterOccupation = new SqlParameter("@UpdateOccupation", occupation);
            objCommand.Parameters.Add(inputparameterOccupation);

            SqlParameter inputparameterAge = new SqlParameter("@UpdateAge", age);
            objCommand.Parameters.Add(inputparameterAge);

            SqlParameter inputparameterWeight = new SqlParameter("@UpdateWeight", weight);
            objCommand.Parameters.Add(inputparameterWeight);

            SqlParameter inputparameterPhotoURL = new SqlParameter("@UpdatePhotoURL", photoURL);
            objCommand.Parameters.Add(inputparameterPhotoURL);

            SqlParameter inputparameterInterests = new SqlParameter("@UpdateInterests", interests);
            objCommand.Parameters.Add(inputparameterInterests);

            SqlParameter inputparameterLikes = new SqlParameter("@UpdateLikes", likes);
            objCommand.Parameters.Add(inputparameterLikes);

            SqlParameter inputparameterDislikes = new SqlParameter("@UpdateDislikes", dislikes);
            objCommand.Parameters.Add(inputparameterDislikes);

            SqlParameter inputparameterFavoriteRestaurant = new SqlParameter("@UpdateFavoriteRestaurant", favoriteRestaurant);
            objCommand.Parameters.Add(inputparameterFavoriteRestaurant);

            SqlParameter inputparameterFavoriteMovie = new SqlParameter("@UpdateFavoriteMovie", favoriteMovie);
            objCommand.Parameters.Add(inputparameterFavoriteMovie);

            SqlParameter inputparameterFavoriteBook = new SqlParameter("@UpdateFavoriteBook", favoriteBook);
            objCommand.Parameters.Add(inputparameterFavoriteBook);

            SqlParameter inputparameterFavoritePoem = new SqlParameter("@UpdateFavoritePoem", favoritePoem);
            objCommand.Parameters.Add(inputparameterFavoritePoem);

            SqlParameter inputparameterFavoriteQuote = new SqlParameter("@UpdateFavoriteQuote", favoriteQuote);
            objCommand.Parameters.Add(inputparameterFavoriteQuote);

            SqlParameter inputparameterFavoriteSaying = new SqlParameter("@UpdateFavoriteSaying", favoriteSaying);
            objCommand.Parameters.Add(inputparameterFavoriteSaying);

            SqlParameter inputparameterGoals = new SqlParameter("@UpdateGoals", goals);
            objCommand.Parameters.Add(inputparameterGoals);

            SqlParameter inputparameterCommitmentType = new SqlParameter("@UpdateCommitmentType", commitmentType);
            objCommand.Parameters.Add(inputparameterCommitmentType);

            SqlParameter inputparameterDescription = new SqlParameter("@UpdateDescription", description);
            objCommand.Parameters.Add(inputparameterDescription);

            SqlParameter inputparameterHideProfile = new SqlParameter("@EnterStatus", status);
            objCommand.Parameters.Add(inputparameterHideProfile);

            objDB.DoUpdate(objCommand);

        }
    }
}
