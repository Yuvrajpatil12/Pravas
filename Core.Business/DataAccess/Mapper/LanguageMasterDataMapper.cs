using Core.Utility.Common;
using Core.Business.DataAccess.Constants;
using Core.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Core.Business.DataAccess.Mapper
{
    public class LanguageMasterDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.LanguageMasterDataMapper";
        private LanguageMaster objLanguageMaster = null;

        public LanguageMaster GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objLanguageMaster = new LanguageMaster();

                if (sqlDataReader.HasColumn(LanguageMasterDBFields.Id))
                    objLanguageMaster.Id = (sqlDataReader[LanguageMasterDBFields.Id] != DBNull.Value ? Convert.ToInt32(sqlDataReader[LanguageMasterDBFields.Id]) : 0);
                if (sqlDataReader.HasColumn(LanguageMasterDBFields.Language))
                    objLanguageMaster.Language = (sqlDataReader[LanguageMasterDBFields.Language] != DBNull.Value ? Convert.ToString(sqlDataReader[LanguageMasterDBFields.Language]) : string.Empty);
                if (sqlDataReader.HasColumn(LanguageMasterDBFields.StatusId))
                    objLanguageMaster.StatusId = (sqlDataReader[LanguageMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[LanguageMasterDBFields.StatusId]) : (byte)0);
                if (sqlDataReader.HasColumn(LanguageMasterDBFields.CreatedDate))
                    objLanguageMaster.CreatedDate = (sqlDataReader[LanguageMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[LanguageMasterDBFields.CreatedDate]) : DateTime.Now);

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objLanguageMaster;
        }

        public List<LanguageMaster> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<LanguageMaster> list = new List<LanguageMaster>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objLanguageMaster = GetDetails(sqlDataReader);
                    list.Add(objLanguageMaster);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<LanguageMaster> GetDetails(DataSet dataSet)
        {
            List<LanguageMaster> LanguageMasters = new List<LanguageMaster>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objLanguageMaster = new LanguageMaster();

                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Id))
                            objLanguageMaster.Id = (drow[LanguageMasterDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[LanguageMasterDBFields.Id]) : 0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Language))
                            objLanguageMaster.Language = (drow[LanguageMasterDBFields.Language] != DBNull.Value ? Convert.ToString(drow[LanguageMasterDBFields.Language]) : string.Empty);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.StatusId))
                            objLanguageMaster.StatusId = (drow[LanguageMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LanguageMasterDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.CreatedDate))
                            objLanguageMaster.CreatedDate = (drow[LanguageMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LanguageMasterDBFields.CreatedDate]) : DateTime.Now);


                        LanguageMasters.Add(objLanguageMaster);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return LanguageMasters;
        }

        public LanguageMaster GetDetailsobj(DataSet dataSet)
        {
            LanguageMaster objLanguageMaster = new LanguageMaster();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objLanguageMaster = new LanguageMaster();

                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Id))
                            objLanguageMaster.Id = (drow[LanguageMasterDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[LanguageMasterDBFields.Id]) : 0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Language))
                            objLanguageMaster.Language = (drow[LanguageMasterDBFields.Language] != DBNull.Value ? Convert.ToString(drow[LanguageMasterDBFields.Language]) : string.Empty);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.StatusId))
                            objLanguageMaster.StatusId = (drow[LanguageMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LanguageMasterDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.CreatedDate))
                            objLanguageMaster.CreatedDate = (drow[LanguageMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LanguageMasterDBFields.CreatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objLanguageMaster;
        }

        public LanguageMaster GetDetails(DataTable dataTable)
        {
            LanguageMaster objLanguageMaster = new LanguageMaster();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objLanguageMaster = new LanguageMaster();

                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Id))
                            objLanguageMaster.Id = (drow[LanguageMasterDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[LanguageMasterDBFields.Id]) : 0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.Language))
                            objLanguageMaster.Language = (drow[LanguageMasterDBFields.Language] != DBNull.Value ? Convert.ToString(drow[LanguageMasterDBFields.Language]) : string.Empty);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.StatusId))
                            objLanguageMaster.StatusId = (drow[LanguageMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LanguageMasterDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(LanguageMasterDBFields.CreatedDate))
                            objLanguageMaster.CreatedDate = (drow[LanguageMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LanguageMasterDBFields.CreatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objLanguageMaster;
        }

    }
}
