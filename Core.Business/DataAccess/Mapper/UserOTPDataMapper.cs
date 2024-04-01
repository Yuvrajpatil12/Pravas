using Yatra.Utility.Common;
using Core.Business.DataAccess.Constants;
using Core.Entity;
using System.Data;
using System.Data.SqlClient;
using Core.Utility.Common;

namespace Core.Business.DataAccess.Mapper
{
    public class UserOTPDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.UserOTPDataMapper";
        private UserOTP objUserOTP = null;

        public UserOTP GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objUserOTP = new UserOTP();

                if (sqlDataReader.HasColumn(UserOTPDBFields.ID))
                    objUserOTP.ID = (sqlDataReader[UserOTPDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UserOTPDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(UserOTPDBFields.UserID))
                    objUserOTP.UserID = (sqlDataReader[UserOTPDBFields.UserID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UserOTPDBFields.UserID]) : 0);
                if (sqlDataReader.HasColumn(UserOTPDBFields.MobileNo))
                    objUserOTP.MobileNo = (sqlDataReader[UserOTPDBFields.MobileNo] != DBNull.Value ? Convert.ToString(sqlDataReader[UserOTPDBFields.MobileNo]) : string.Empty);
                if (sqlDataReader.HasColumn(UserOTPDBFields.OTP))
                    objUserOTP.OTP = (sqlDataReader[UserOTPDBFields.OTP] != DBNull.Value ? Convert.ToString(sqlDataReader[UserOTPDBFields.OTP]) : string.Empty);
                if (sqlDataReader.HasColumn(UserOTPDBFields.ExpiryDate))
                    objUserOTP.ExpiryDate = (sqlDataReader[UserOTPDBFields.ExpiryDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UserOTPDBFields.ExpiryDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(UserOTPDBFields.StatusID))
                    objUserOTP.StatusID = (sqlDataReader[UserOTPDBFields.StatusID] != DBNull.Value ? Convert.ToByte(sqlDataReader[UserOTPDBFields.StatusID]) : (byte)0);


                if (sqlDataReader.HasColumn(UserOTPDBFields.KYCStatus))
                    objUserOTP.KYCStatus = (sqlDataReader[UserOTPDBFields.KYCStatus] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UserOTPDBFields.KYCStatus]) : 0);
                if (sqlDataReader.HasColumn(UserOTPDBFields.RoleId))
                    objUserOTP.RoleID = (sqlDataReader[UserOTPDBFields.RoleId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UserOTPDBFields.RoleId]) : 0);

                if (sqlDataReader.HasColumn(UserOTPDBFields.UserApiKey))
                    objUserOTP.UserApiKey = (sqlDataReader[UserOTPDBFields.UserApiKey] != DBNull.Value ? Convert.ToString(sqlDataReader[UserOTPDBFields.UserApiKey]) : string.Empty);

                //if (sqlDataReader.HasColumn(UserOTPDBFields.FCMToken))
                //    objUserOTP.FCMToken = (sqlDataReader[UserOTPDBFields.FCMToken] != DBNull.Value ? Convert.ToString(sqlDataReader[UserOTPDBFields.FCMToken]) : string.Empty);



                //if (sqlDataReader.HasColumn(UserOTPDBFields.CreatedDate))
                //    objUserOTP.CreatedDate = (sqlDataReader[UserOTPDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UserOTPDBFields.CreatedDate]) : DateTime.Now);
                //if (sqlDataReader.HasColumn(UserOTPDBFields.UpdatedDate))
                //    objUserOTP.UpdatedDate = (sqlDataReader[UserOTPDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UserOTPDBFields.UpdatedDate]) : DateTime.Now);

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objUserOTP;
        }

        public List<UserOTP> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<UserOTP> list = new List<UserOTP>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objUserOTP = GetDetails(sqlDataReader);
                    list.Add(objUserOTP);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<UserOTP> GetDetails(DataSet dataSet)
        {
            List<UserOTP> UserOTPs = new List<UserOTP>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUserOTP = new UserOTP();

                        if (drow.Table.Columns.Contains(UserOTPDBFields.ID))
                            objUserOTP.ID = (drow[UserOTPDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UserID))
                            objUserOTP.UserID = (drow[UserOTPDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.MobileNo))
                            objUserOTP.MobileNo = (drow[UserOTPDBFields.MobileNo] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.MobileNo]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.OTP))
                            objUserOTP.OTP = (drow[UserOTPDBFields.OTP] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.OTP]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.ExpiryDate))
                            objUserOTP.ExpiryDate = (drow[UserOTPDBFields.ExpiryDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.ExpiryDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.StatusID))
                            objUserOTP.StatusID = (drow[UserOTPDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[UserOTPDBFields.StatusID]) : (byte)0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.CreatedDate))
                            objUserOTP.CreatedDate = (drow[UserOTPDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UpdatedDate))
                            objUserOTP.UpdatedDate = (drow[UserOTPDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.UpdatedDate]) : DateTime.Now);


                        UserOTPs.Add(objUserOTP);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return UserOTPs;
        }

        public UserOTP GetDetailsobj(DataSet dataSet)
        {
            UserOTP objUserOTP = new UserOTP();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUserOTP = new UserOTP();

                        if (drow.Table.Columns.Contains(UserOTPDBFields.ID))
                            objUserOTP.ID = (drow[UserOTPDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UserID))
                            objUserOTP.UserID = (drow[UserOTPDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.MobileNo))
                            objUserOTP.MobileNo = (drow[UserOTPDBFields.MobileNo] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.MobileNo]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.OTP))
                            objUserOTP.OTP = (drow[UserOTPDBFields.OTP] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.OTP]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.ExpiryDate))
                            objUserOTP.ExpiryDate = (drow[UserOTPDBFields.ExpiryDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.ExpiryDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.StatusID))
                            objUserOTP.StatusID = (drow[UserOTPDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[UserOTPDBFields.StatusID]) : (byte)0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.CreatedDate))
                            objUserOTP.CreatedDate = (drow[UserOTPDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UpdatedDate))
                            objUserOTP.UpdatedDate = (drow[UserOTPDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objUserOTP;
        }

        public UserOTP GetDetails(DataTable dataTable)
        {
            UserOTP objUserOTP = new UserOTP();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objUserOTP = new UserOTP();

                        if (drow.Table.Columns.Contains(UserOTPDBFields.ID))
                            objUserOTP.ID = (drow[UserOTPDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UserID))
                            objUserOTP.UserID = (drow[UserOTPDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[UserOTPDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.MobileNo))
                            objUserOTP.MobileNo = (drow[UserOTPDBFields.MobileNo] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.MobileNo]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.OTP))
                            objUserOTP.OTP = (drow[UserOTPDBFields.OTP] != DBNull.Value ? Convert.ToString(drow[UserOTPDBFields.OTP]) : string.Empty);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.ExpiryDate))
                            objUserOTP.ExpiryDate = (drow[UserOTPDBFields.ExpiryDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.ExpiryDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.StatusID))
                            objUserOTP.StatusID = (drow[UserOTPDBFields.StatusID] != DBNull.Value ? Convert.ToByte(drow[UserOTPDBFields.StatusID]) : (byte)0);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.CreatedDate))
                            objUserOTP.CreatedDate = (drow[UserOTPDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UserOTPDBFields.UpdatedDate))
                            objUserOTP.UpdatedDate = (drow[UserOTPDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UserOTPDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objUserOTP;
        }

    }
}
