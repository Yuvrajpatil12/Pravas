using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.DataAccess.Constants;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.DataAccessLayer.General;
using Core.Business.DataAccess.Mapper;
using Core.Entity;
using Core.Entity.Common;
using Core.Utility.Common;

namespace Core.Business.DataAccess.Wrapper
{
    public class TransactionsWrapper : UniversalObject
    {
        private readonly string _module = "Core.Business.DataAccess.Wrapper.Transactions";
        private SqlConnection Connection;

        #region UniversalObject Interface Members

        public bool ObjectChanged { get; set; }

        public Transactions objWrapperClass = new Transactions();
        private TransactionsDataMapper objTransactionsDataMapper = new TransactionsDataMapper();

        #region GetRecords methods

        public bool GetRecordById(int id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = TransactionsStoredProcedures.TransactionsGetRecordById;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(TransactionsDBFields.ID, id);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordById(" + id + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public dynamic GetTransanctionRecordByID(Int64 id)
        {
            SqlDataReader sqlDataReader = null;
            TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
            Transactions transaction = new Transactions();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(TransactionsStoredProcedures.TransactionsGetRecordById, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(TransactionsDBFields.ID, id);

                sqlDataReader = sqlCommand.ExecuteReader();
                transaction = objDataMapper.GetDetailsRecord(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetTransanctionRecordByID()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return transaction;
        }

        public bool GetRecordByValue(string fieldName, string value)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = TransactionsStoredProcedures.GetTransactionsRecordByValue;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(fieldName, value);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + fieldName + "," + value + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool GetRecordByValue(string[] fieldNames, string[] values)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = TransactionsStoredProcedures.GetTransactionsRecordByValueArray;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    sqlCommand.Parameters.AddWithValue(fieldNames[i], values[i]);
                }

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + string.Join(",", fieldNames) + "," + string.Join(",", values) + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion GetRecords methods

        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                if (objWrapperClass.ID > 0)
                {
                    Update(ref commandList, ref commandCounter);
                }
                else
                {
                    Command command = new Command(TransactionsStoredProcedures.TransactionsSAVE, CommandType.StoredProcedure);
                    command.AddParameter(TransactionsDBFields.IU_Flag, "I", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.UUID, objWrapperClass.UUID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.UserID, objWrapperClass.UserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.DriverUserID, objWrapperClass.DriverUserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.LocationMasterIDTo, objWrapperClass.LocationMasterIDTo, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.LocationMasterIDFrom, objWrapperClass.LocationMasterIDFrom, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.PickLocationLatitude, objWrapperClass.PickLocationLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.PickLocationLongitude, objWrapperClass.PickLocationLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.DropLocationLatitude, objWrapperClass.DropLocationLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.DropLocationLongitude, objWrapperClass.DropLocationLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.DriverLocationLatitudeOnBooking, objWrapperClass.DriverLocationLatitudeOnBooking, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.DriverLocationLongitudeOnBooking, objWrapperClass.DriverLocationLongitudeOnBooking, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.JourneyStartDateTime, objWrapperClass.JourneyStartDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.JourneyEndDateTime, objWrapperClass.JourneyEndDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.VerificationCode, objWrapperClass.VerificationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.JourneyStatus, objWrapperClass.JourneyStatus, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.JourneyStatusDateTime, objWrapperClass.JourneyStatusDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(TransactionsDBFields.UserRequestDatetime, objWrapperClass.UserRequestDatetime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);

                    command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                    command.Name = TransactionsStoredProcedures.TransactionsSAVE + commandCounter.ToString();
                    commandCounter++;
                    commandList.Add(command.Name, command);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Update(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command(TransactionsStoredProcedures.TransactionsSAVE, CommandType.StoredProcedure);

                command.AddParameter(TransactionsDBFields.IU_Flag, "U", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.UUID, objWrapperClass.UUID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.UserID, objWrapperClass.UserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.DriverUserID, objWrapperClass.DriverUserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.LocationMasterIDTo, objWrapperClass.LocationMasterIDTo, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.LocationMasterIDFrom, objWrapperClass.LocationMasterIDFrom, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.PickLocationLatitude, objWrapperClass.PickLocationLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.PickLocationLongitude, objWrapperClass.PickLocationLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.DropLocationLatitude, objWrapperClass.DropLocationLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.DropLocationLongitude, objWrapperClass.DropLocationLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.DriverLocationLatitudeOnBooking, objWrapperClass.DriverLocationLatitudeOnBooking, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.DriverLocationLongitudeOnBooking, objWrapperClass.DriverLocationLongitudeOnBooking, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.JourneyStartDateTime, objWrapperClass.JourneyStartDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.JourneyEndDateTime, objWrapperClass.JourneyEndDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.VerificationCode, objWrapperClass.VerificationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.JourneyStatus, objWrapperClass.JourneyStatus, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.JourneyStatusDateTime, objWrapperClass.JourneyStatusDateTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(TransactionsDBFields.UserRequestDatetime, objWrapperClass.UserRequestDatetime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);

                command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);
                command.Name = TransactionsStoredProcedures.TransactionsSAVE + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Update", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Delete(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command("SP_MASTERS_Delete", CommandType.StoredProcedure);
                command.AddParameter("@TableName", "Transactions", DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", "ID", DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.Name = "DeleteTransactions" + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool SaveCopy()
        {
            throw new NotImplementedException();
        }

        public bool Move()
        {
            throw new NotImplementedException();
        }

        public bool Print()
        {
            throw new NotImplementedException();
        }

        #endregion UniversalObject Interface Members
    }

    public class TransactionsWrapperColletion : UniversalCollection
    {
        private readonly string _module = "Transactions";
        private SqlConnection Connection;
        private List<Transactions> _Items = new List<Transactions>();

        public List<Transactions> Items
        { get { return this._Items; } set { this._Items = value; } }

        private DataSet _DtsDataset = null;
        private string _SortingString = "";

        #region UniversalCollection Interface Members Implementation

        #region GetRecords methods

        public bool GetRecords(bool createDataSet, string[,] sortFields)
        {
            if (createDataSet)
                return GetDataSetForQuery(TransactionsStoredProcedures.GetTransactionsRecords);
            else
                return GetCollectionForQuery(TransactionsStoredProcedures.GetTransactionsRecords);
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            SqlParameterCollection sqlParameterCollection = null;
            SqlParameter ObjSqlParameter = new SqlParameter();
            ObjSqlParameter.ParameterName = TransactionsStoredProcedures.SortingString;
            ObjSqlParameter.Value = _SortingString;
            sqlParameterCollection.Add(ObjSqlParameter);

            if (createDataSet)
                return GetDataSetForQueryParameter(TransactionsStoredProcedures.GetTransactionsRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(TransactionsStoredProcedures.GetTransactionsRecords, sqlParameterCollection);
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string fieldName, string fieldValue)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            string[] Fieldsname = new string[1];
            string[] Values = new string[1];
            Fieldsname[0] = fieldName;
            Values[0] = fieldValue;

            return GetCollectionForQueryWithParameters(TransactionsStoredProcedures.GetTransactionsRecordByValue, Fieldsname, Values);
        }

        private bool GetCollectionForQueryWithParameters(string sqlQuery, string[] fieldNames, string[] values)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                if (fieldNames != null)
                {
                    if (fieldNames.Length > 0)
                    {
                        for (int i = 0; i < fieldNames.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldNames[i];
                            sqlParameter.Value = values[i];
                            sqlCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
                    this.Items.Add(objDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQueryWithParameters(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string[] fieldName, string[] fieldValue)
        {
            SqlParameterCollection sqlParameterCollection = null;
            if (fieldName != null)
            {
                if (fieldName.Length > 0)
                {
                    for (int i = 0; i < fieldName.Length; i++)
                    {
                        SqlParameter sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = fieldName[i];
                        sqlParameter.Value = fieldValue[i];
                        sqlParameterCollection.Add(sqlParameter);
                    }
                }
            }
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = TransactionsStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);
            }

            if (createDataSet)
                return GetDataSetForQueryParameter(TransactionsStoredProcedures.GetTransactionsRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(TransactionsStoredProcedures.GetTransactionsRecords, sqlParameterCollection);
        }

        #endregion GetRecords methods

        #region Seach Method

        public bool Search(string searchString, string[,] sortString)
        {
            throw new NotImplementedException();
        }

        public bool Search(string fieldName, string fieldValue, string[,] sortString)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;
                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = fieldName;
                ObjSqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(ObjSqlParameter);

                GetCollectionForQueryWithParameter(TransactionsStoredProcedures.TransactionsSearch, sqlParameterCollection);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool Search(string searchString, bool createDataSet, string[,] sortFields)
        {
            throw new NotImplementedException();
        }

        public bool Search(string fieldName, string fieldValue, bool createDataSet, string[,] sortFields)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = fieldName;
                sqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(sqlParameter);

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = TransactionsStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);

                if (createDataSet)
                    return GetDataSetForQueryParameter(TransactionsStoredProcedures.TransactionsSearchByValue, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(TransactionsStoredProcedures.TransactionsSearchByValue, sqlParameterCollection);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool Search(string[] fieldName, string[] fieldValue, bool createDataSet, string[,] sortFields)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;
                if (fieldName != null)
                {
                    if (fieldName.Length > 0)
                    {
                        for (int i = 0; i < fieldName.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldName[i];
                            sqlParameter.Value = fieldValue[i];
                            sqlParameterCollection.Add(sqlParameter);
                        }
                    }
                }
                if (sortFields != null)
                {
                    if (sortFields.Length > 0)
                    {
                        _SortingString += "order by ";
                        for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                        {
                            _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                        }
                        _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                    }

                    SqlParameter ObjSqlParameter = new SqlParameter();
                    ObjSqlParameter.ParameterName = TransactionsStoredProcedures.SortingString;
                    ObjSqlParameter.Value = _SortingString;
                    sqlParameterCollection.Add(ObjSqlParameter);
                }

                if (createDataSet)
                    return GetDataSetForQueryParameter(TransactionsStoredProcedures.TransactionsSearchByValueArray, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(TransactionsStoredProcedures.TransactionsSearchByValueArray, sqlParameterCollection);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion Seach Method

        #region ExecuteQuery Methods

        private bool GetDataSetForQuery(string sqlQuery)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("Transactions");
                SqlDataAdapter _Adpusers = new SqlDataAdapter(sqlQuery, this.Connection);
                _Adpusers.Fill(_DtsUsers);
                this._DtsDataset = _DtsUsers;
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }

        private bool GetDataSetForQueryParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("Transactions");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, this.Connection);
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                SqlDataAdapter _Adpusers = new SqlDataAdapter();
                _Adpusers.SelectCommand = sqlCommand;
                _Adpusers.Fill(this._DtsDataset);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }

        private bool GetCollectionForQuery(string sqlQuery)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    TransactionsDataMapper objTransactionsDataMapper = new TransactionsDataMapper();
                    this.Items.Add(objTransactionsDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        private bool GetCollectionForQueryWithParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                sqlCommand.Connection = this.Connection;
                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    TransactionsDataMapper objTransactionsDataMapper = new TransactionsDataMapper();
                    this.Items.Add(objTransactionsDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion ExecuteQuery Methods

        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                TransactionsWrapper objTransactionsWrapper = new TransactionsWrapper();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ObjectChanged == true)
                    {
                        Dictionary<string, Command> subCommands = new Dictionary<string, Command>();
                        objTransactionsWrapper.Save(ref subCommands, ref commandCounter);
                        foreach (KeyValuePair<string, Command> commandPair in subCommands)
                        {
                            commandList.Add(commandPair.Key, commandPair.Value);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Delete(string ids, ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command("SP_MASTERS_DELETE", CommandType.StoredProcedure);
                command.AddParameter("@TableName", TransactionsDBFields.TableNameVal, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", TransactionsDBFields.ID, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", ids, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.Name = "Delete" + TransactionsDBFields.TableNameVal + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public dynamic getUsersList(Int64 userId)
        {
            SqlDataReader sqlDataReader = null;
            TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
            List<Transactions> lstUsers = new List<Transactions>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(TransactionsStoredProcedures.GetTransactionsRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUsersList ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        object UniversalCollection.GetRecordById(int id)
        {
            throw new NotImplementedException();
        }

        object UniversalCollection.GetRecordByValue(string fieldName, string value)
        {
            throw new NotImplementedException();
        }


        #endregion UniversalCollection Interface Members Implementation
    }
}