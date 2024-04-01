using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DataAccess.Constants
{
    public class AccessMemberDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "AccessMember";
public static string  ID = "ID";
public static string  UserID = "UserID";
public static string  RoleID = "RoleID";
public static string  Port = "Port";
public static string  Url = "Url";
public static string  ReferrerURL = "ReferrerURL";
public static string  BrowserType = "BrowserType";
public static string  BrowserVersion = "BrowserVersion";
public static string  OperatingSystem = "OperatingSystem";
public static string  DeviceType = "DeviceType";
public static string  DeviceName = "DeviceName";
public static string  DeviceModel = "DeviceModel";
public static string  Build = "Build";
public static string  Version = "Version";
public static string  Host = "Host";
public static string  RemoteHost = "RemoteHost";
public static string  RemoteAddrIP = "RemoteAddrIP";
public static string  UserAgent = "UserAgent";
public static string  Platform = "Platform";
public static string  ClickedBy = "ClickedBy";
public static string  StatusID = "StatusID";
public static string  CreatedDate = "CreatedDate";

      
    }
    public class AccessMemberStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string AccessMemberSAVE = "AccessMember_SAVE";
        public static string AccessMemberGetRecordById = "AccessMember_GetRecordById";

        public static string GetAccessMemberRecords = "AccessMember_GetRecords";
        public static string GetAccessMemberRecordByValue =  "AccessMember_GetRecordByValue";
        public static string GetAccessMemberRecordByValueArray = "AccessMember_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string AccessMemberSearch = "AccessMember_Search";
        public static string AccessMemberSearchByValue =  "AccessMember_SearchByValue";
        public static string AccessMemberSearchByValueArray = "AccessMember_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
