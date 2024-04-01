using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.DataAccess.Constants;
using System.Data.SqlClient;
using System.Data;
using Core.Entity;
using Core.Entity.Common;
using Core.Utility.Common;

namespace Core.Business.DataAccess.Mapper
{
    public class AccessMemberDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.AccessMemberDataMapper";
        private AccessMember objAccessMember = null;

        public AccessMember GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objAccessMember = new AccessMember();
               
			   if (sqlDataReader.HasColumn(AccessMemberDBFields.ID))
   objAccessMember.ID = (sqlDataReader[AccessMemberDBFields.ID] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AccessMemberDBFields.ID]) : (decimal)0); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.UserID))
   objAccessMember.UserID = (sqlDataReader[AccessMemberDBFields.UserID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[AccessMemberDBFields.UserID]) : 0); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.RoleID))
   objAccessMember.RoleID = (sqlDataReader[AccessMemberDBFields.RoleID] != DBNull.Value ? Convert.ToByte(sqlDataReader[AccessMemberDBFields.RoleID]) : (byte)0); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Port))
   objAccessMember.Port = (sqlDataReader[AccessMemberDBFields.Port] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Port]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Url))
   objAccessMember.Url = (sqlDataReader[AccessMemberDBFields.Url] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Url]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.ReferrerURL))
   objAccessMember.ReferrerURL = (sqlDataReader[AccessMemberDBFields.ReferrerURL] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.ReferrerURL]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.BrowserType))
   objAccessMember.BrowserType = (sqlDataReader[AccessMemberDBFields.BrowserType] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.BrowserType]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.BrowserVersion))
   objAccessMember.BrowserVersion = (sqlDataReader[AccessMemberDBFields.BrowserVersion] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.BrowserVersion]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.OperatingSystem))
   objAccessMember.OperatingSystem = (sqlDataReader[AccessMemberDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.OperatingSystem]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.DeviceType))
   objAccessMember.DeviceType = (sqlDataReader[AccessMemberDBFields.DeviceType] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.DeviceType]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.DeviceName))
   objAccessMember.DeviceName = (sqlDataReader[AccessMemberDBFields.DeviceName] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.DeviceName]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.DeviceModel))
   objAccessMember.DeviceModel = (sqlDataReader[AccessMemberDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.DeviceModel]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Build))
   objAccessMember.Build = (sqlDataReader[AccessMemberDBFields.Build] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Build]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Version))
   objAccessMember.Version = (sqlDataReader[AccessMemberDBFields.Version] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Version]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Host))
   objAccessMember.Host = (sqlDataReader[AccessMemberDBFields.Host] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Host]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.RemoteHost))
   objAccessMember.RemoteHost = (sqlDataReader[AccessMemberDBFields.RemoteHost] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.RemoteHost]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.RemoteAddrIP))
   objAccessMember.RemoteAddrIP = (sqlDataReader[AccessMemberDBFields.RemoteAddrIP] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.RemoteAddrIP]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.UserAgent))
   objAccessMember.UserAgent = (sqlDataReader[AccessMemberDBFields.UserAgent] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.UserAgent]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.Platform))
   objAccessMember.Platform = (sqlDataReader[AccessMemberDBFields.Platform] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.Platform]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.ClickedBy))
   objAccessMember.ClickedBy = (sqlDataReader[AccessMemberDBFields.ClickedBy] != DBNull.Value ? Convert.ToString(sqlDataReader[AccessMemberDBFields.ClickedBy]) : string.Empty); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.StatusID))
   objAccessMember.StatusID = (sqlDataReader[AccessMemberDBFields.StatusID] != DBNull.Value ? Convert.ToByte(sqlDataReader[AccessMemberDBFields.StatusID]) : (byte)0); 
if (sqlDataReader.HasColumn(AccessMemberDBFields.CreatedDate))
   objAccessMember.CreatedDate = (sqlDataReader[AccessMemberDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[AccessMemberDBFields.CreatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objAccessMember;
        }
		
		public List<AccessMember> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<AccessMember> list = new List<AccessMember>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objAccessMember = GetDetails(sqlDataReader);
                    list.Add(objAccessMember);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<AccessMember> GetDetails(DataSet dataSet)
        {
            List<AccessMember> AccessMembers = new List<AccessMember>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAccessMember = new AccessMember();
                       
						if (drow.Table.Columns.Contains(AccessMemberDBFields.ID)) 
  objAccessMember.ID = (drow[AccessMemberDBFields.ID] != DBNull.Value ? Convert.ToDecimal(drow[AccessMemberDBFields.ID]) : (decimal)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserID)) 
  objAccessMember.UserID = (drow[AccessMemberDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[AccessMemberDBFields.UserID]) : 0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RoleID)) 
  objAccessMember.RoleID = (drow[AccessMemberDBFields.RoleID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.RoleID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Port)) 
  objAccessMember.Port = (drow[AccessMemberDBFields.Port] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Port]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Url)) 
  objAccessMember.Url = (drow[AccessMemberDBFields.Url] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Url]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ReferrerURL)) 
  objAccessMember.ReferrerURL = (drow[AccessMemberDBFields.ReferrerURL] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ReferrerURL]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserType)) 
  objAccessMember.BrowserType = (drow[AccessMemberDBFields.BrowserType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserVersion)) 
  objAccessMember.BrowserVersion = (drow[AccessMemberDBFields.BrowserVersion] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserVersion]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.OperatingSystem)) 
  objAccessMember.OperatingSystem = (drow[AccessMemberDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceType)) 
  objAccessMember.DeviceType = (drow[AccessMemberDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceName)) 
  objAccessMember.DeviceName = (drow[AccessMemberDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceModel)) 
  objAccessMember.DeviceModel = (drow[AccessMemberDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Build)) 
  objAccessMember.Build = (drow[AccessMemberDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Version)) 
  objAccessMember.Version = (drow[AccessMemberDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Host)) 
  objAccessMember.Host = (drow[AccessMemberDBFields.Host] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Host]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteHost)) 
  objAccessMember.RemoteHost = (drow[AccessMemberDBFields.RemoteHost] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteHost]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteAddrIP)) 
  objAccessMember.RemoteAddrIP = (drow[AccessMemberDBFields.RemoteAddrIP] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteAddrIP]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserAgent)) 
  objAccessMember.UserAgent = (drow[AccessMemberDBFields.UserAgent] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.UserAgent]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Platform)) 
  objAccessMember.Platform = (drow[AccessMemberDBFields.Platform] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Platform]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ClickedBy)) 
  objAccessMember.ClickedBy = (drow[AccessMemberDBFields.ClickedBy] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ClickedBy]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.StatusID)) 
  objAccessMember.StatusID = (drow[AccessMemberDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.StatusID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.CreatedDate)) 
  objAccessMember.CreatedDate = (drow[AccessMemberDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AccessMemberDBFields.CreatedDate]) : DateTime.Now); 


                        AccessMembers.Add(objAccessMember);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return AccessMembers;
        }
		
		public AccessMember GetDetailsobj(DataSet dataSet)
        {
            AccessMember objAccessMember = new AccessMember();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAccessMember = new AccessMember();
                      
						if (drow.Table.Columns.Contains(AccessMemberDBFields.ID)) 
  objAccessMember.ID = (drow[AccessMemberDBFields.ID] != DBNull.Value ? Convert.ToDecimal(drow[AccessMemberDBFields.ID]) : (decimal)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserID)) 
  objAccessMember.UserID = (drow[AccessMemberDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[AccessMemberDBFields.UserID]) : 0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RoleID)) 
  objAccessMember.RoleID = (drow[AccessMemberDBFields.RoleID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.RoleID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Port)) 
  objAccessMember.Port = (drow[AccessMemberDBFields.Port] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Port]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Url)) 
  objAccessMember.Url = (drow[AccessMemberDBFields.Url] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Url]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ReferrerURL)) 
  objAccessMember.ReferrerURL = (drow[AccessMemberDBFields.ReferrerURL] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ReferrerURL]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserType)) 
  objAccessMember.BrowserType = (drow[AccessMemberDBFields.BrowserType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserVersion)) 
  objAccessMember.BrowserVersion = (drow[AccessMemberDBFields.BrowserVersion] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserVersion]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.OperatingSystem)) 
  objAccessMember.OperatingSystem = (drow[AccessMemberDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceType)) 
  objAccessMember.DeviceType = (drow[AccessMemberDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceName)) 
  objAccessMember.DeviceName = (drow[AccessMemberDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceModel)) 
  objAccessMember.DeviceModel = (drow[AccessMemberDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Build)) 
  objAccessMember.Build = (drow[AccessMemberDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Version)) 
  objAccessMember.Version = (drow[AccessMemberDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Host)) 
  objAccessMember.Host = (drow[AccessMemberDBFields.Host] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Host]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteHost)) 
  objAccessMember.RemoteHost = (drow[AccessMemberDBFields.RemoteHost] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteHost]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteAddrIP)) 
  objAccessMember.RemoteAddrIP = (drow[AccessMemberDBFields.RemoteAddrIP] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteAddrIP]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserAgent)) 
  objAccessMember.UserAgent = (drow[AccessMemberDBFields.UserAgent] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.UserAgent]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Platform)) 
  objAccessMember.Platform = (drow[AccessMemberDBFields.Platform] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Platform]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ClickedBy)) 
  objAccessMember.ClickedBy = (drow[AccessMemberDBFields.ClickedBy] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ClickedBy]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.StatusID)) 
  objAccessMember.StatusID = (drow[AccessMemberDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.StatusID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.CreatedDate)) 
  objAccessMember.CreatedDate = (drow[AccessMemberDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AccessMemberDBFields.CreatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objAccessMember;
        }
		
		public AccessMember GetDetails(DataTable dataTable)
        {
            AccessMember objAccessMember = new AccessMember();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objAccessMember = new AccessMember();
                      
						if (drow.Table.Columns.Contains(AccessMemberDBFields.ID)) 
  objAccessMember.ID = (drow[AccessMemberDBFields.ID] != DBNull.Value ? Convert.ToDecimal(drow[AccessMemberDBFields.ID]) : (decimal)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserID)) 
  objAccessMember.UserID = (drow[AccessMemberDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[AccessMemberDBFields.UserID]) : 0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RoleID)) 
  objAccessMember.RoleID = (drow[AccessMemberDBFields.RoleID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.RoleID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Port)) 
  objAccessMember.Port = (drow[AccessMemberDBFields.Port] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Port]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Url)) 
  objAccessMember.Url = (drow[AccessMemberDBFields.Url] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Url]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ReferrerURL)) 
  objAccessMember.ReferrerURL = (drow[AccessMemberDBFields.ReferrerURL] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ReferrerURL]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserType)) 
  objAccessMember.BrowserType = (drow[AccessMemberDBFields.BrowserType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.BrowserVersion)) 
  objAccessMember.BrowserVersion = (drow[AccessMemberDBFields.BrowserVersion] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.BrowserVersion]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.OperatingSystem)) 
  objAccessMember.OperatingSystem = (drow[AccessMemberDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceType)) 
  objAccessMember.DeviceType = (drow[AccessMemberDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceName)) 
  objAccessMember.DeviceName = (drow[AccessMemberDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.DeviceModel)) 
  objAccessMember.DeviceModel = (drow[AccessMemberDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Build)) 
  objAccessMember.Build = (drow[AccessMemberDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Version)) 
  objAccessMember.Version = (drow[AccessMemberDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Host)) 
  objAccessMember.Host = (drow[AccessMemberDBFields.Host] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Host]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteHost)) 
  objAccessMember.RemoteHost = (drow[AccessMemberDBFields.RemoteHost] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteHost]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.RemoteAddrIP)) 
  objAccessMember.RemoteAddrIP = (drow[AccessMemberDBFields.RemoteAddrIP] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.RemoteAddrIP]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.UserAgent)) 
  objAccessMember.UserAgent = (drow[AccessMemberDBFields.UserAgent] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.UserAgent]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.Platform)) 
  objAccessMember.Platform = (drow[AccessMemberDBFields.Platform] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.Platform]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.ClickedBy)) 
  objAccessMember.ClickedBy = (drow[AccessMemberDBFields.ClickedBy] != DBNull.Value ? Convert.ToString(drow[AccessMemberDBFields.ClickedBy]) : string.Empty); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.StatusID)) 
  objAccessMember.StatusID = (drow[AccessMemberDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[AccessMemberDBFields.StatusID]) : (byte)0); 
if (drow.Table.Columns.Contains(AccessMemberDBFields.CreatedDate)) 
  objAccessMember.CreatedDate = (drow[AccessMemberDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AccessMemberDBFields.CreatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objAccessMember;
        }

    }
}
