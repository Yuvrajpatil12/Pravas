using Core.Business.DataAccess.Constants;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.DataAccessLayer.General;
using Core.Business.DataAccess.Mapper;
using Core.Entity;
using Core.Entity.Common;
using Core.Utility.Common;
using System.Data;
using System.Data.SqlClient;

namespace Core.Business.DataAccess.Wrapper
{
    public class UsersWrapper : UniversalObject
    {
        private readonly string _module = "Core.Business.DataAccess.Wrapper.Users";
        private SqlConnection Connection;
        private JsonMessage _jsonMessage = null;

        #region UniversalObject Interface Members

        public bool ObjectChanged { get; set; }

        public Users objWrapperClass = new Users();
        private UsersDataMapper objUsersDataMapper = new UsersDataMapper();

        #region GetRecords methods

        public bool GetRecordById(int id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = UsersStoredProcedures.UsersGetRecordById;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, id);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
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

        public bool GetRecordByValue(string fieldName, string value)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = UsersStoredProcedures.GetUsersRecordByValue;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(fieldName, value);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
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
                sqlCommand.CommandText = UsersStoredProcedures.GetUsersRecordByValueArray;
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
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
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
                    Command command = new Command(UsersStoredProcedures.UsersSaveByApi, CommandType.StoredProcedure);
                    command.AddParameter(UsersDBFields.IU_Flag, "I", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.UserName, objWrapperClass.UserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FirstName, objWrapperClass.FirstName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.LastName, objWrapperClass.LastName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.Password, objWrapperClass.Password, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.AlternateEmail, objWrapperClass.AlternateEmail, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.PhoneNumber, objWrapperClass.PhoneNumber, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FCMToken, objWrapperClass.FCMToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.RoleId, objWrapperClass.RoleId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.ParentId, objWrapperClass.ParentId, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.DeviceID, objWrapperClass.DeviceID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.UserLastLatitude, objWrapperClass.UserLastLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.UserLastLongitude, objWrapperClass.UserLastLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.UserAPIKey, objWrapperClass.UserAPIKey, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.IsVerified, objWrapperClass.IsVerified, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.VerficationCode, objWrapperClass.VerficationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.VerficationDate, objWrapperClass.VerficationDate, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.StatusId, objWrapperClass.StatusId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.CreatedDate, objWrapperClass.CreatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.UpdatedDate, objWrapperClass.UpdatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                    command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                    command.Name = UsersStoredProcedures.UsersSaveByApi + commandCounter.ToString();
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
                Command command = new Command(UsersStoredProcedures.UsersSaveByApi, CommandType.StoredProcedure);

                command.AddParameter(UsersDBFields.IU_Flag, "U", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.UserName, objWrapperClass.UserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FirstName, objWrapperClass.FirstName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.LastName, objWrapperClass.LastName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.Password, objWrapperClass.Password, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.AlternateEmail, objWrapperClass.AlternateEmail, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.PhoneNumber, objWrapperClass.PhoneNumber, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FCMToken, objWrapperClass.FCMToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.RoleId, objWrapperClass.RoleId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.ParentId, objWrapperClass.ParentId, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.DeviceID, objWrapperClass.DeviceID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.UserLastLatitude, objWrapperClass.UserLastLatitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.UserLastLongitude, objWrapperClass.UserLastLongitude, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.UserAPIKey, objWrapperClass.UserAPIKey, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.IsVerified, objWrapperClass.IsVerified, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.VerficationCode, objWrapperClass.VerficationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.VerficationDate, objWrapperClass.VerficationDate, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.StatusId, objWrapperClass.StatusId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.CreatedDate, objWrapperClass.CreatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.UpdatedDate, objWrapperClass.UpdatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                command.Name = UsersStoredProcedures.UsersSaveByApi + commandCounter.ToString();
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
                command.AddParameter("@TableName", "Users", DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", "ID", DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.Name = "DeleteUsers" + commandCounter.ToString();
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

        #region IsUserExist

        public Users IsUserIdExist(string PhoneNumber)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsUserExists, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, PhoneNumber);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserIdExist(PhoneNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion IsUserExist

        #region IsUserExist

        public Users IsUserExist(string PhoneNumber)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_UserExist, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, PhoneNumber);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserExistAdmin(PhoneNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion IsUserExist

        public Users UpdateUser(Int64 ID, string PhoneNumber)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_UpdateUsersStatus, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, PhoneNumber);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateUser(PhoneNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #region Authenticate API

        public Users Authenticate(string phoneNumber, string deviceid)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersLoginByApi, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, phoneNumber);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.DeviceID, deviceid);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);

                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(phoneNumber" + phoneNumber + " DeviceID=" + deviceid + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion Authenticate API

        #region AuthenticateAdmin

        public Users AuthenticateAdmin(string username, string password, string deviceid)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersLogin, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.AlternateEmail, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Password, password);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);

                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(username=" + username + "  Password=" + password + "DeviceId=" + deviceid + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion AuthenticateAdmin

        #region GetDetails

        public Users GetDetails(string phonenumber)
        {
            SqlDataReader sqlDataReader = null;

            try
            {
                if (!string.IsNullOrEmpty(phonenumber))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.GetUserDetailsApi, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, phonenumber);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(phonenumber=" + phonenumber + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public dynamic getUsersList(Int64 userId)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetRecordsForUserList, this.Connection);
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

        public Users GetAvailableSeats(Int64 LocationMasterIDFrom, Int64 LocationMasterIDTo)
        {
            SqlDataReader sqlDataReader = null;

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.TransactionsGetAvailableSeats, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.LocationMasterIDFrom, LocationMasterIDFrom);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.LocationMasterIDTo, LocationMasterIDTo);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAvailableSeats(LocationMasterIDFrom=" + LocationMasterIDFrom + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion GetDetails
    }

    public class UsersWrapperColletion : UniversalCollection
    {
        private readonly string _module = "Users";
        private SqlConnection Connection;
        private List<Users> _Items = new List<Users>();
        private JsonMessage _jsonMessage = null;

        public List<Users> Items
        { get { return this._Items; } set { this._Items = value; } }

        private DataSet _DtsDataset = null;
        private string _SortingString = "";

        #region UniversalCollection Interface Members Implementation

        #region GetRecords methods

        public bool GetRecords(bool createDataSet, string[,] sortFields)
        {
            if (createDataSet)
                return GetDataSetForQuery(UsersStoredProcedures.GetUsersRecords);
            else
                return GetCollectionForQuery(UsersStoredProcedures.GetUsersRecords);
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
            ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
            ObjSqlParameter.Value = _SortingString;
            sqlParameterCollection.Add(ObjSqlParameter);

            if (createDataSet)
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
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

            return GetCollectionForQueryWithParameters(UsersStoredProcedures.GetUsersRecordByValue, Fieldsname, Values);
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
                    UsersDataMapper objDataMapper = new UsersDataMapper();
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
                ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);
            }

            if (createDataSet)
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
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

                GetCollectionForQueryWithParameter(UsersStoredProcedures.UsersSearch, sqlParameterCollection);
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
                ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);

                if (createDataSet)
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValue, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValue, sqlParameterCollection);
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
                    ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                    ObjSqlParameter.Value = _SortingString;
                    sqlParameterCollection.Add(ObjSqlParameter);
                }

                if (createDataSet)
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValueArray, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValueArray, sqlParameterCollection);
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
                DataSet _DtsUsers = new DataSet("Users");
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
                DataSet _DtsUsers = new DataSet("Users");
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
                    UsersDataMapper objUsersDataMapper = new UsersDataMapper();
                    this.Items.Add(objUsersDataMapper.GetDetails(_Dtr));
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
                    UsersDataMapper objUsersDataMapper = new UsersDataMapper();
                    this.Items.Add(objUsersDataMapper.GetDetails(_Dtr));
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
                UsersWrapper objUsersWrapper = new UsersWrapper();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ObjectChanged == true)
                    {
                        Dictionary<string, Command> subCommands = new Dictionary<string, Command>();
                        objUsersWrapper.Save(ref subCommands, ref commandCounter);
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
                command.AddParameter("@TableName", UsersDBFields.TableNameVal, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", UsersDBFields.ID, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", ids, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.Name = "Delete" + UsersDBFields.TableNameVal + commandCounter.ToString();
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

        object UniversalCollection.GetRecordById(int id)
        {
            throw new NotImplementedException();
        }

        object UniversalCollection.GetRecordByValue(string fieldName, string value)
        {
            throw new NotImplementedException();
        }

        #endregion UniversalCollection Interface Members Implementation

        #region Get Methods

        public dynamic GetDriverLocation(string userAPIKey)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersGetDriverLocation, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDistributorList ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetAllDrivers()
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetAllDrivers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllDrivers ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetVehicleDetails(string userAPIKey)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetVehicleDetails, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllDrivers ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public JsonMessage UpdateDriverStatus(VehicleDetails vehicleDetails)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_UpdateDriverStatus, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, vehicleDetails.DriverUserID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.IsAvailable, vehicleDetails.IsAvailable);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return _jsonMessage;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateDriverStatus()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _jsonMessage;
        }

        public dynamic GetAllLocations()
        {
            SqlDataReader sqlDataReader = null;
            LocationMasterDataMapper objDataMapper = new LocationMasterDataMapper();
            List<LocationMaster> lstUsers = new List<LocationMaster>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetAllLocations, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllLocations ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetAllTransactions(string userAPIKey, Int64 Id, int roleId)
        {
            SqlDataReader sqlDataReader = null;
            TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
            List<Transactions> lstUsers = new List<Transactions>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetAllTransactions, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, Id);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleId, roleId);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactions ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetAllTransactionsRecords()
        {
            SqlDataReader sqlDataReader = null;
            TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
            List<Transactions> lstUsers = new List<Transactions>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetAllTransactionsRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactionsRecords ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetDriverTransactions(string userAPIKey, int roleId)
        {
            SqlDataReader sqlDataReader = null;
            TransactionsDataMapper objDataMapper = new TransactionsDataMapper();
            List<Transactions> lstUsers = new List<Transactions>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetDriverTransactions, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleId, roleId);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactions ()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        public dynamic GetDriverRecords()
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            List<Users> lstUsers = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersGetDriverRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();

                lstUsers = objDataMapper.GetDetailsList(sqlDataReader);

                return lstUsers;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDriverRecords()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return lstUsers;
        }

        #region GetUserData

        // changes for get the user data by id
        public Users GetUserData(string userAPIKey)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            Users objUsers = new Users();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersGetRecordById, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserAPIKey, userAPIKey);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objUsers = objDataMapper.GetDetails(sqlDataReader);

                    return objUsers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserData()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objUsers;
        }

        public Users GetUserDataByID(Int64 userid, string type)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            Users objUsers = new Users();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Get_UserRecordByID, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, userid);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Type, type);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objUsers = objDataMapper.GetDetails(sqlDataReader);

                    return objUsers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserDataByID()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objUsers;
        }

        public Users GetUserByIdDetails(Int64 userId)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            Users objUsers = new Users();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Get_UserRecordByID, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, userId);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Type, "User");

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objUsers = objDataMapper.GetDetails(sqlDataReader);

                    return objUsers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserByIdDetails()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objUsers;
        }

        #endregion GetUserData

        #endregion Get Methods
    }
}