namespace Core.Business.DataAccess.Constants
{
    public class UsersDBFields
    {
        public static string IU_Flag = "IU_Flag";

        public static string CompanyName = "CompanyName";
        public static string TableNameVal = "Users";
        public static string ID = "ID";
        public static string UserName = "UserName";
        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string Password = "Password";
        public static string AlternateEmail = "AlternateEmail";
        public static string PhoneNumber = "PhoneNumber";
        public static string FCMToken = "FCMToken";
        public static string RoleId = "RoleId";
        public static string ParentId = "ParentId";
        public static string DeviceID = "DeviceID";
        public static string UserLastLatitude = "UserLastLatitude";
        public static string UserLastLongitude = "UserLastLongitude";
        public static string UserAPIKey = "UserAPIKey";
        public static string IsVerified = "IsVerified";
        public static string VerficationCode = "VerficationCode";
        public static string VerficationDate = "VerficationDate";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
        public static string Type = "Type";
        public static string IsAvailable = "IsAvailable";
        public static string RowNumber = "RowNumber";
        public static string AvailableSeats = "AvailableSeats";
        public static string DownAvailableSeats = "DownAvailableSeats";
        public static string UpAvailableSeats = "UpAvailableSeats";
        public static string DestinationLastLongitude = "DestinationLastLongitude";
        public static string DestinationLastLatitude = "DestinationLastLatitude";
        public static string LocationMasterIDFrom = "LocationMasterIDFrom";
        public static string LocationMasterIDTo = "LocationMasterIDTo";
        public static string DriverName = "DriverName";
        public static string ActionBy = "ActionBy";
        public static string VehicleType = "VehicleType";
    }

    public class UsersStoredProcedures
    {
        #region Object StoredProcedure

        public static string UsersSaveByApi = "Users_SAVE_API";

        public static string UsersLogin = "Users_Login";

        public static string Users_UserExist = "Users_UserExistPhoneNumber";

        public static string Users_UpdateUsersStatus = "Users_UpdateUsersStatus";

        public static string GetUserDetailsApi = "GetUserDetails_API";

        public static string UsersSAVE = "Users_SAVE";

        public static string UsersLoginByApi = "GenerateOTP";

        public static string UsersGetRecordById = "Users_GetRecordById_API";

        public static string GetUsersRecords = "Users_GetRecords";
        public static string GetUsersRecordByValue = "Users_GetRecordByValue";
        public static string GetUsersRecordByValueArray = "Users_GetRecordByValueArray";

        public static string Users_IsUserExists = "Users_IsUserExists";

        public static string UsersGetDriverLocation = "Users_GetDriverLocation";
        public static string Users_GetAllDrivers = "Users_GetAllDrivers";
        public static string Users_GetVehicleDetails = "Users_GetVehicleDetails";
        public static string Users_GetAllLocations = "Users_GetAllLocations";
        public static string Users_GetAllTransactions = "Users_GetAllTransactions";
        public static string Get_UserRecordByID = "Get_UserrecordByID";
        public static string Users_GetDriverTransactions = "Users_GetDriverTransactions";

        public static string UsersGetDriverRecords = "Users_GetDriverRecords";

        public static string Users_GetRecordsForUserList = "Users_GetRecordsForUserList";
        public static string TransactionsGetAvailableSeats = "TransactionsGetAvailableSeats";
        public static string Users_UpdateDriverStatus = "Users_UpdateDriverStatus";
        public static string Users_GetAllTransactionsRecords = "Users_GetAllTransactionsRecords";

        #endregion Object StoredProcedure

        #region Collection StoredProcedure

        public static string UsersSearch = "Users_Search";
        public static string UsersSearchByValue = "Users_SearchByValue";
        public static string UsersSearchByValueArray = "Users_SearchByValueArray";

        #endregion Collection StoredProcedure

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";
    }
}