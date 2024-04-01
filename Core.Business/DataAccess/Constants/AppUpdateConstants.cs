using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DataAccess.Constants
{
    public class AppUpdateDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "AppUpdate";
public static string  ID = "ID";
public static string  Version = "Version";
public static string  Build = "Build";
public static string  AppType = "AppType";
public static string  IsUpdate = "IsUpdate";
public static string  ErrorCode = "ErrorCode";
public static string  StatusId = "StatusId";
public static string  CreatedDate = "CreatedDate";
public static string  UpdateDate = "UpdateDate";

      
    }
    public class AppUpdateStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string AppUpdateSAVE = "AppUpdate_SAVE";
        public static string AppUpdateGetRecordById = "AppUpdate_GetRecordById";

        public static string GetAppUpdateRecords = "AppUpdate_GetRecords";
        public static string GetAppUpdateRecordByValue =  "AppUpdate_GetRecordByValue";
        public static string GetAppUpdateRecordByValueArray = "AppUpdate_GetRecordByValueArray";

        public static string App_Update_Validate = "App_Update_Validate";
        #endregion

        #region Collection StoredProcedure

        public static string AppUpdateSearch = "AppUpdate_Search";
        public static string AppUpdateSearchByValue =  "AppUpdate_SearchByValue";
        public static string AppUpdateSearchByValueArray = "AppUpdate_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
