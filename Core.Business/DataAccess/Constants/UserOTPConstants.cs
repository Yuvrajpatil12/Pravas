namespace Core.Business.DataAccess.Constants
{
    public class UserOTPDBFields
    {


        public static string IU_Flag = "IU_Flag";



        public static string FCMToken = "FCMToken";
        public static string TableNameVal = "UserOTP";
        public static string ID = "ID";
        public static string UserID = "UserID";
        public static string MobileNo = "MobileNo";
        public static string OTP = "OTP";
        public static string ExpiryDate = "ExpiryDate";
        public static string StatusID = "StatusID";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
        public static string RowNumber = "RowNumber";

        public static string KYCStatus = "KYCStatus";
        public static string RoleId = "RoleId";

        public static string UserApiKey = "UserApiKey";

    }
    public class UserOTPStoredProcedures
    {

        #region Object StoredProcedure






        public static string UserOTPSAVE = "UserOTP_SAVE";
        public static string UserOTPGetRecordById = "UserOTP_GetRecordById";

        public static string GetUserOTPRecords = "UserOTP_GetRecords";
        public static string GetUserOTPRecordByValue = "UserOTP_GetRecordByValue";
        public static string GetUserOTPRecordByValueArray = "UserOTP_GetRecordByValueArray";

        public static string GetVerifyOTPApi = "User_VerifyOTP";



        #endregion

        #region Collection StoredProcedure

        public static string UserOTPSearch = "UserOTP_Search";
        public static string UserOTPSearchByValue = "UserOTP_SearchByValue";
        public static string UserOTPSearchByValueArray = "UserOTP_SearchByValueArray";
        #endregion

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";



    }
}
