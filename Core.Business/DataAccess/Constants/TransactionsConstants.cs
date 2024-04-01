namespace Core.Business.DataAccess.Constants
{
    public class TransactionsDBFields
    {
        public static string IU_Flag = "IU_Flag";

        public static string TableNameVal = "Transactions";
        public static string ID = "ID";
        public static string UUID = "UUID";
        public static string UserID = "UserID";
        public static string DriverUserID = "DriverUserID";
        public static string LocationMasterIDTo = "LocationMasterIDTo";
        public static string LocationMasterIDFrom = "LocationMasterIDFrom";
        public static string PickLocationLatitude = "PickLocationLatitude";
        public static string PickLocationLongitude = "PickLocationLongitude";
        public static string DropLocationLatitude = "DropLocationLatitude";
        public static string DropLocationLongitude = "DropLocationLongitude";
        public static string DriverLocationLatitudeOnBooking = "DriverLocationLatitudeOnBooking";
        public static string DriverLocationLongitudeOnBooking = "DriverLocationLongitudeOnBooking";
        public static string JourneyStartDateTime = "JourneyStartDateTime";
        public static string JourneyEndDateTime = "JourneyEndDateTime";
        public static string VerificationCode = "VerificationCode";
        public static string JourneyStatus = "JourneyStatus";
        public static string JourneyStatusDateTime = "JourneyStatusDateTime";
        public static string UserRequestDatetime = "UserRequestDatetime";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
        public static string VehicleNo = "VehicleNo";
        public static string Distination = "Distination";
        public static string DropLocation = "DropLocation";
        public static string PickupLocation = "PickupLocation";
    }

    public class TransactionsStoredProcedures
    {
        #region Object StoredProcedure

        public static string TransactionsSAVE = "Transactions_SAVE";
        public static string TransactionsGetRecordById = "Transactions_GetRecordById";

        public static string GetTransactionsRecords = "Transactions_GetRecords";
        public static string GetTransactionsRecordByValue = "Transactions_GetRecordByValue";
        public static string GetTransactionsRecordByValueArray = "Transactions_GetRecordByValueArray";
        public static string TransactionsGetAvailableSeats = "TransactionsGetAvailableSeats";

        #endregion Object StoredProcedure

        #region Collection StoredProcedure

        public static string TransactionsSearch = "Transactions_Search";
        public static string TransactionsSearchByValue = "Transactions_SearchByValue";
        public static string TransactionsSearchByValueArray = "Transactions_SearchByValueArray";

        #endregion Collection StoredProcedure

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";
    }
}