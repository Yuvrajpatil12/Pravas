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
    public class AppUpdateDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.AppUpdateDataMapper";
        private AppUpdate objAppUpdate = null;

        public AppUpdate GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objAppUpdate = new AppUpdate();
               
			   if (sqlDataReader.HasColumn(AppUpdateDBFields.ID))
   objAppUpdate.ID = (sqlDataReader[AppUpdateDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[AppUpdateDBFields.ID]) : 0); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.Version))
   objAppUpdate.Version = (sqlDataReader[AppUpdateDBFields.Version] != DBNull.Value ? Convert.ToString(sqlDataReader[AppUpdateDBFields.Version]) : string.Empty); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.Build))
   objAppUpdate.Build = (sqlDataReader[AppUpdateDBFields.Build] != DBNull.Value ? Convert.ToString(sqlDataReader[AppUpdateDBFields.Build]) : string.Empty); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.AppType))
   objAppUpdate.AppType = (sqlDataReader[AppUpdateDBFields.AppType] != DBNull.Value ? Convert.ToByte(sqlDataReader[AppUpdateDBFields.AppType]) : (byte)0); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.IsUpdate))
   objAppUpdate.IsUpdate = (sqlDataReader[AppUpdateDBFields.IsUpdate] != DBNull.Value ? Convert.ToByte(sqlDataReader[AppUpdateDBFields.IsUpdate]) : (byte)0); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.ErrorCode))
   objAppUpdate.ErrorCode = (sqlDataReader[AppUpdateDBFields.ErrorCode] != DBNull.Value ? Convert.ToInt32(sqlDataReader[AppUpdateDBFields.ErrorCode]) : 0); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.StatusId))
   objAppUpdate.StatusId = (sqlDataReader[AppUpdateDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[AppUpdateDBFields.StatusId]) : (byte)0); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.CreatedDate))
   objAppUpdate.CreatedDate = (sqlDataReader[AppUpdateDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[AppUpdateDBFields.CreatedDate]) : DateTime.Now); 
if (sqlDataReader.HasColumn(AppUpdateDBFields.UpdateDate))
   objAppUpdate.UpdateDate = (sqlDataReader[AppUpdateDBFields.UpdateDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[AppUpdateDBFields.UpdateDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objAppUpdate;
        }
		
		public List<AppUpdate> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<AppUpdate> list = new List<AppUpdate>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objAppUpdate = GetDetails(sqlDataReader);
                    list.Add(objAppUpdate);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<AppUpdate> GetDetails(DataSet dataSet)
        {
            List<AppUpdate> AppUpdates = new List<AppUpdate>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAppUpdate = new AppUpdate();
                       
						if (drow.Table.Columns.Contains(AppUpdateDBFields.ID)) 
  objAppUpdate.ID = (drow[AppUpdateDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Version)) 
  objAppUpdate.Version = (drow[AppUpdateDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Build)) 
  objAppUpdate.Build = (drow[AppUpdateDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.AppType)) 
  objAppUpdate.AppType = (drow[AppUpdateDBFields.AppType] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.AppType]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.IsUpdate)) 
  objAppUpdate.IsUpdate = (drow[AppUpdateDBFields.IsUpdate] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.IsUpdate]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.ErrorCode)) 
  objAppUpdate.ErrorCode = (drow[AppUpdateDBFields.ErrorCode] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ErrorCode]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.StatusId)) 
  objAppUpdate.StatusId = (drow[AppUpdateDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.CreatedDate)) 
  objAppUpdate.CreatedDate = (drow[AppUpdateDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.UpdateDate)) 
  objAppUpdate.UpdateDate = (drow[AppUpdateDBFields.UpdateDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.UpdateDate]) : DateTime.Now); 


                        AppUpdates.Add(objAppUpdate);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return AppUpdates;
        }
		
		public AppUpdate GetDetailsobj(DataSet dataSet)
        {
            AppUpdate objAppUpdate = new AppUpdate();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAppUpdate = new AppUpdate();
                      
						if (drow.Table.Columns.Contains(AppUpdateDBFields.ID)) 
  objAppUpdate.ID = (drow[AppUpdateDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Version)) 
  objAppUpdate.Version = (drow[AppUpdateDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Build)) 
  objAppUpdate.Build = (drow[AppUpdateDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.AppType)) 
  objAppUpdate.AppType = (drow[AppUpdateDBFields.AppType] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.AppType]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.IsUpdate)) 
  objAppUpdate.IsUpdate = (drow[AppUpdateDBFields.IsUpdate] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.IsUpdate]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.ErrorCode)) 
  objAppUpdate.ErrorCode = (drow[AppUpdateDBFields.ErrorCode] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ErrorCode]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.StatusId)) 
  objAppUpdate.StatusId = (drow[AppUpdateDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.CreatedDate)) 
  objAppUpdate.CreatedDate = (drow[AppUpdateDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.UpdateDate)) 
  objAppUpdate.UpdateDate = (drow[AppUpdateDBFields.UpdateDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.UpdateDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objAppUpdate;
        }
		
		public AppUpdate GetDetails(DataTable dataTable)
        {
            AppUpdate objAppUpdate = new AppUpdate();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objAppUpdate = new AppUpdate();
                      
						if (drow.Table.Columns.Contains(AppUpdateDBFields.ID)) 
  objAppUpdate.ID = (drow[AppUpdateDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Version)) 
  objAppUpdate.Version = (drow[AppUpdateDBFields.Version] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Version]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.Build)) 
  objAppUpdate.Build = (drow[AppUpdateDBFields.Build] != DBNull.Value ? Convert.ToString(drow[AppUpdateDBFields.Build]) : string.Empty); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.AppType)) 
  objAppUpdate.AppType = (drow[AppUpdateDBFields.AppType] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.AppType]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.IsUpdate)) 
  objAppUpdate.IsUpdate = (drow[AppUpdateDBFields.IsUpdate] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.IsUpdate]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.ErrorCode)) 
  objAppUpdate.ErrorCode = (drow[AppUpdateDBFields.ErrorCode] != DBNull.Value ? Convert.ToInt32(drow[AppUpdateDBFields.ErrorCode]) : 0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.StatusId)) 
  objAppUpdate.StatusId = (drow[AppUpdateDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AppUpdateDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.CreatedDate)) 
  objAppUpdate.CreatedDate = (drow[AppUpdateDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AppUpdateDBFields.UpdateDate)) 
  objAppUpdate.UpdateDate = (drow[AppUpdateDBFields.UpdateDate] != DBNull.Value ? Convert.ToDateTime(drow[AppUpdateDBFields.UpdateDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objAppUpdate;
        }

    }
}
