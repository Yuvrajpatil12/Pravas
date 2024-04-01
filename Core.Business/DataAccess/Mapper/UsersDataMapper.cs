using Core.Business.DataAccess.Constants;
using Core.Entity;
using Core.Utility.Common;
using System.Data;
using System.Data.SqlClient;

namespace Core.Business.DataAccess.Mapper
{
    public class UsersDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.UsersDataMapper";
        private Users objUsers = null;

        public Users GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objUsers = new Users();

                if (sqlDataReader.HasColumn(UsersDBFields.ID))
                    objUsers.ID = (sqlDataReader[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.UserName))
                    objUsers.UserName = (sqlDataReader[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.FirstName))
                    objUsers.FirstName = (sqlDataReader[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FirstName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.LastName))
                    objUsers.LastName = (sqlDataReader[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LastName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.Password))
                    objUsers.Password = (sqlDataReader[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Password]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.AlternateEmail))
                    objUsers.AlternateEmail = (sqlDataReader[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.AlternateEmail]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.PhoneNumber))
                    objUsers.PhoneNumber = (sqlDataReader[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.PhoneNumber]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.FCMToken))
                    objUsers.FCMToken = (sqlDataReader[UsersDBFields.FCMToken] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FCMToken]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.RoleId))
                    objUsers.RoleId = (sqlDataReader[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.RoleId]) : (byte)0);
                if (sqlDataReader.HasColumn(UsersDBFields.ParentId))
                    objUsers.ParentId = (sqlDataReader[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.ParentId]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.DeviceID))
                    objUsers.DeviceID = (sqlDataReader[UsersDBFields.DeviceID] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.DeviceID]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.UserLastLatitude))
                    objUsers.UserLastLatitude = (sqlDataReader[UsersDBFields.UserLastLatitude] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserLastLatitude]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.UserLastLongitude))
                    objUsers.UserLastLongitude = (sqlDataReader[UsersDBFields.UserLastLongitude] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserLastLongitude]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.UserAPIKey))
                    objUsers.UserAPIKey = (sqlDataReader[UsersDBFields.UserAPIKey] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserAPIKey]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.IsVerified))
                    objUsers.IsVerified = (sqlDataReader[UsersDBFields.IsVerified] != DBNull.Value ? Convert.ToBoolean(sqlDataReader[UsersDBFields.IsVerified]) : false);
                if (sqlDataReader.HasColumn(UsersDBFields.VerficationCode))
                    objUsers.VerficationCode = (sqlDataReader[UsersDBFields.VerficationCode] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.VerficationCode]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.VerficationDate))
                    objUsers.VerficationDate = (sqlDataReader[UsersDBFields.VerficationDate] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.VerficationDate]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.StatusId))
                    objUsers.StatusId = (sqlDataReader[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.StatusId]) : (byte)0);
                if (sqlDataReader.HasColumn(UsersDBFields.CreatedDate))
                    objUsers.CreatedDate = (sqlDataReader[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.CreatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(UsersDBFields.UpdatedDate))
                    objUsers.UpdatedDate = (sqlDataReader[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.UpdatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(UserOTPDBFields.OTP))
                    objUsers.CompanyName = (sqlDataReader[UserOTPDBFields.OTP] != DBNull.Value ? Convert.ToString(sqlDataReader[UserOTPDBFields.OTP]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.CompanyName))
                    objUsers.CompanyName = (sqlDataReader[UsersDBFields.CompanyName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.CompanyName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.RowNumber))
                    objUsers.RowNumber = (sqlDataReader[UsersDBFields.RowNumber] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.RowNumber]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.UpAvailableSeats))
                    objUsers.UpAvailableSeats = (sqlDataReader[UsersDBFields.UpAvailableSeats] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.UpAvailableSeats]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.DownAvailableSeats))
                    objUsers.DownAvailableSeats = (sqlDataReader[UsersDBFields.DownAvailableSeats] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.DownAvailableSeats]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.AvailableSeats))
                    objUsers.AvailableSeats = (sqlDataReader[UsersDBFields.AvailableSeats] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.AvailableSeats]) : 0);

                if (sqlDataReader.HasColumn(TransactionsDBFields.VehicleNo))
                    objUsers.VehicleNo = (sqlDataReader[TransactionsDBFields.VehicleNo] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.VehicleNo]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.DestinationLastLatitude))
                    objUsers.DestinationLastLatitude = (sqlDataReader[UsersDBFields.DestinationLastLatitude] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.DestinationLastLatitude]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.DestinationLastLongitude))
                    objUsers.DestinationLastLongitude = (sqlDataReader[UsersDBFields.DestinationLastLongitude] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.DestinationLastLongitude]) : string.Empty);
                // DestinationLastLatitude
                if (sqlDataReader.HasColumn(UsersDBFields.IsAvailable))
                    objUsers.IsAvailable = (sqlDataReader[UsersDBFields.IsAvailable] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.IsAvailable]) : (byte)0);
                if (sqlDataReader.HasColumn(UsersDBFields.VehicleType))
                    objUsers.VehicleType = (sqlDataReader[UsersDBFields.VehicleType] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.VehicleType]) : string.Empty);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objUsers;
        }

        public List<Users> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<Users> list = new List<Users>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objUsers = GetDetails(sqlDataReader);
                    list.Add(objUsers);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<Users> GetDetails(DataSet dataSet)
        {
            List<Users> Userss = new List<Users>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.PhoneNumber))
                            objUsers.PhoneNumber = (drow[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.PhoneNumber]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FCMToken))
                            objUsers.FCMToken = (drow[UsersDBFields.FCMToken] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FCMToken]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId))
                            objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId))
                            objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.DeviceID))
                            objUsers.DeviceID = (drow[UsersDBFields.DeviceID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.DeviceID]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLatitude))
                            objUsers.UserLastLatitude = (drow[UsersDBFields.UserLastLatitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLongitude))
                            objUsers.UserLastLongitude = (drow[UsersDBFields.UserLastLongitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserAPIKey))
                            objUsers.UserAPIKey = (drow[UsersDBFields.UserAPIKey] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserAPIKey]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsVerified))
                            objUsers.IsVerified = (drow[UsersDBFields.IsVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationCode))
                            objUsers.VerficationCode = (drow[UsersDBFields.VerficationCode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationDate))
                            objUsers.VerficationDate = (drow[UsersDBFields.VerficationDate] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationDate]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);

                        Userss.Add(objUsers);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return Userss;
        }

        public Users GetDetailsobj(DataSet dataSet)
        {
            Users objUsers = new Users();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.PhoneNumber))
                            objUsers.PhoneNumber = (drow[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.PhoneNumber]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FCMToken))
                            objUsers.FCMToken = (drow[UsersDBFields.FCMToken] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FCMToken]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId))
                            objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId))
                            objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.DeviceID))
                            objUsers.DeviceID = (drow[UsersDBFields.DeviceID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.DeviceID]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLatitude))
                            objUsers.UserLastLatitude = (drow[UsersDBFields.UserLastLatitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLongitude))
                            objUsers.UserLastLongitude = (drow[UsersDBFields.UserLastLongitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserAPIKey))
                            objUsers.UserAPIKey = (drow[UsersDBFields.UserAPIKey] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserAPIKey]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsVerified))
                            objUsers.IsVerified = (drow[UsersDBFields.IsVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationCode))
                            objUsers.VerficationCode = (drow[UsersDBFields.VerficationCode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationDate))
                            objUsers.VerficationDate = (drow[UsersDBFields.VerficationDate] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationDate]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

        public Users GetDetails(DataTable dataTable)
        {
            Users objUsers = new Users();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.PhoneNumber))
                            objUsers.PhoneNumber = (drow[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.PhoneNumber]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FCMToken))
                            objUsers.FCMToken = (drow[UsersDBFields.FCMToken] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FCMToken]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId))
                            objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId))
                            objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.DeviceID))
                            objUsers.DeviceID = (drow[UsersDBFields.DeviceID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.DeviceID]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLatitude))
                            objUsers.UserLastLatitude = (drow[UsersDBFields.UserLastLatitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserLastLongitude))
                            objUsers.UserLastLongitude = (drow[UsersDBFields.UserLastLongitude] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserLastLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserAPIKey))
                            objUsers.UserAPIKey = (drow[UsersDBFields.UserAPIKey] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserAPIKey]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsVerified))
                            objUsers.IsVerified = (drow[UsersDBFields.IsVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationCode))
                            objUsers.VerficationCode = (drow[UsersDBFields.VerficationCode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.VerficationDate))
                            objUsers.VerficationDate = (drow[UsersDBFields.VerficationDate] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.VerficationDate]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }
    }
}