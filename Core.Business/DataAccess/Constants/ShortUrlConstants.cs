namespace Core.Business.DataAccess.Constants
{
    public class ShortUrlDBFields
    {


        public static string IU_Flag = "IU_Flag";




        public static string TableNameVal = "ShortUrl";
        public static string ID = "ID";
        public static string KeyValue = "KeyValue";
        public static string URLString = "URLString";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";


    }
    public class ShortUrlStoredProcedures
    {

        #region Object StoredProcedure






        public static string ShortUrlSAVE = "ShortUrl_SAVE";
        public static string ShortUrlGetRecordById = "ShortUrl_GetRecordById";

        public static string GetShortUrlRecords = "ShortUrl_GetRecords";
        public static string GetShortUrlRecordByValue = "ShortUrl_GetRecordByValue";
        public static string GetShortUrlRecordByValueArray = "ShortUrl_GetRecordByValueArray";

        #endregion

        #region Collection StoredProcedure

        public static string ShortUrlSearch = "ShortUrl_Search";
        public static string ShortUrlSearchByValue = "ShortUrl_SearchByValue";
        public static string ShortUrlSearchByValueArray = "ShortUrl_SearchByValueArray";

        public static string Get_SHORTURL_Key = "Get_SHORTURL_Key";
        #endregion

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";



    }
}
