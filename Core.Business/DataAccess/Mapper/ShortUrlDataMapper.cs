using Yatra.Utility.Common;
using Core.Business.DataAccess.Constants;
using Core.Entity;
using Core.Utility.Common;
using System.Data;
using System.Data.SqlClient;

namespace Core.Business.DataAccess.Mapper
{
    public class ShortUrlDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.ShortUrlDataMapper";
        private ShortUrl objShortUrl = null;

        public ShortUrl GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objShortUrl = new ShortUrl();

                if (sqlDataReader.HasColumn(ShortUrlDBFields.ID))
                    objShortUrl.ID = (sqlDataReader[ShortUrlDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[ShortUrlDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(ShortUrlDBFields.KeyValue))
                    objShortUrl.KeyValue = (sqlDataReader[ShortUrlDBFields.KeyValue] != DBNull.Value ? Convert.ToString(sqlDataReader[ShortUrlDBFields.KeyValue]) : string.Empty);
                if (sqlDataReader.HasColumn(ShortUrlDBFields.URLString))
                    objShortUrl.URLString = (sqlDataReader[ShortUrlDBFields.URLString] != DBNull.Value ? Convert.ToString(sqlDataReader[ShortUrlDBFields.URLString]) : string.Empty);
                if (sqlDataReader.HasColumn(ShortUrlDBFields.StatusId))
                    objShortUrl.StatusId = (sqlDataReader[ShortUrlDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[ShortUrlDBFields.StatusId]) : (byte)0);
                if (sqlDataReader.HasColumn(ShortUrlDBFields.CreatedDate))
                    objShortUrl.CreatedDate = (sqlDataReader[ShortUrlDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[ShortUrlDBFields.CreatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(ShortUrlDBFields.UpdatedDate))
                    objShortUrl.UpdatedDate = (sqlDataReader[ShortUrlDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[ShortUrlDBFields.UpdatedDate]) : DateTime.Now);

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objShortUrl;
        }

        public List<ShortUrl> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<ShortUrl> list = new List<ShortUrl>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objShortUrl = GetDetails(sqlDataReader);
                    list.Add(objShortUrl);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<ShortUrl> GetDetails(DataSet dataSet)
        {
            List<ShortUrl> ShortUrls = new List<ShortUrl>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objShortUrl = new ShortUrl();

                        if (drow.Table.Columns.Contains(ShortUrlDBFields.ID))
                            objShortUrl.ID = (drow[ShortUrlDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[ShortUrlDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.KeyValue))
                            objShortUrl.KeyValue = (drow[ShortUrlDBFields.KeyValue] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.KeyValue]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.URLString))
                            objShortUrl.URLString = (drow[ShortUrlDBFields.URLString] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.URLString]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.StatusId))
                            objShortUrl.StatusId = (drow[ShortUrlDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[ShortUrlDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.CreatedDate))
                            objShortUrl.CreatedDate = (drow[ShortUrlDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.UpdatedDate))
                            objShortUrl.UpdatedDate = (drow[ShortUrlDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.UpdatedDate]) : DateTime.Now);


                        ShortUrls.Add(objShortUrl);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return ShortUrls;
        }

        public ShortUrl GetDetailsobj(DataSet dataSet)
        {
            ShortUrl objShortUrl = new ShortUrl();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objShortUrl = new ShortUrl();

                        if (drow.Table.Columns.Contains(ShortUrlDBFields.ID))
                            objShortUrl.ID = (drow[ShortUrlDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[ShortUrlDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.KeyValue))
                            objShortUrl.KeyValue = (drow[ShortUrlDBFields.KeyValue] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.KeyValue]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.URLString))
                            objShortUrl.URLString = (drow[ShortUrlDBFields.URLString] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.URLString]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.StatusId))
                            objShortUrl.StatusId = (drow[ShortUrlDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[ShortUrlDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.CreatedDate))
                            objShortUrl.CreatedDate = (drow[ShortUrlDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.UpdatedDate))
                            objShortUrl.UpdatedDate = (drow[ShortUrlDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objShortUrl;
        }

        public ShortUrl GetDetails(DataTable dataTable)
        {
            ShortUrl objShortUrl = new ShortUrl();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objShortUrl = new ShortUrl();

                        if (drow.Table.Columns.Contains(ShortUrlDBFields.ID))
                            objShortUrl.ID = (drow[ShortUrlDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[ShortUrlDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.KeyValue))
                            objShortUrl.KeyValue = (drow[ShortUrlDBFields.KeyValue] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.KeyValue]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.URLString))
                            objShortUrl.URLString = (drow[ShortUrlDBFields.URLString] != DBNull.Value ? Convert.ToString(drow[ShortUrlDBFields.URLString]) : string.Empty);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.StatusId))
                            objShortUrl.StatusId = (drow[ShortUrlDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[ShortUrlDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.CreatedDate))
                            objShortUrl.CreatedDate = (drow[ShortUrlDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(ShortUrlDBFields.UpdatedDate))
                            objShortUrl.UpdatedDate = (drow[ShortUrlDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[ShortUrlDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objShortUrl;
        }

    }
}
