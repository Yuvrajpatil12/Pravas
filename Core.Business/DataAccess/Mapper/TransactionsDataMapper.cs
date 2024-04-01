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
    public class TransactionsDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.TransactionsDataMapper";
        private Transactions objTransactions = null;

        public Transactions GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objTransactions = new Transactions();

                if (sqlDataReader.HasColumn(TransactionsDBFields.ID))
                    objTransactions.ID = (sqlDataReader[TransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[TransactionsDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.UUID))
                    objTransactions.UUID = (sqlDataReader[TransactionsDBFields.UUID] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.UUID]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.UserID))
                    objTransactions.UserID = (sqlDataReader[TransactionsDBFields.UserID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[TransactionsDBFields.UserID]) : 0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DriverUserID))
                    objTransactions.DriverUserID = (sqlDataReader[TransactionsDBFields.DriverUserID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[TransactionsDBFields.DriverUserID]) : 0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.LocationMasterIDTo))
                    objTransactions.LocationMasterIDTo = (sqlDataReader[TransactionsDBFields.LocationMasterIDTo] != DBNull.Value ? Convert.ToInt32(sqlDataReader[TransactionsDBFields.LocationMasterIDTo]) : 0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.LocationMasterIDFrom))
                    objTransactions.LocationMasterIDFrom = (sqlDataReader[TransactionsDBFields.LocationMasterIDFrom] != DBNull.Value ? Convert.ToInt32(sqlDataReader[TransactionsDBFields.LocationMasterIDFrom]) : 0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.PickLocationLatitude))
                    objTransactions.PickLocationLatitude = (sqlDataReader[TransactionsDBFields.PickLocationLatitude] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.PickLocationLatitude]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DropLocationLatitude))
                    objTransactions.DropLocationLatitude = (sqlDataReader[TransactionsDBFields.DropLocationLatitude] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.DropLocationLatitude]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DropLocationLongitude))
                    objTransactions.DropLocationLongitude = (sqlDataReader[TransactionsDBFields.DropLocationLongitude] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.DropLocationLongitude]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DriverLocationLatitudeOnBooking))
                    objTransactions.DriverLocationLatitudeOnBooking = (sqlDataReader[TransactionsDBFields.DriverLocationLatitudeOnBooking] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.DriverLocationLatitudeOnBooking]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DriverLocationLongitudeOnBooking))
                    objTransactions.DriverLocationLongitudeOnBooking = (sqlDataReader[TransactionsDBFields.DriverLocationLongitudeOnBooking] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.DriverLocationLongitudeOnBooking]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.JourneyStartDateTime))
                    objTransactions.JourneyStartDateTime = (sqlDataReader[TransactionsDBFields.JourneyStartDateTime] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.JourneyStartDateTime]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.JourneyEndDateTime))
                    objTransactions.JourneyEndDateTime = (sqlDataReader[TransactionsDBFields.JourneyEndDateTime] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.JourneyEndDateTime]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.VerificationCode))
                    objTransactions.VerificationCode = (sqlDataReader[TransactionsDBFields.VerificationCode] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.VerificationCode]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.JourneyStatus))
                    objTransactions.JourneyStatus = (sqlDataReader[TransactionsDBFields.JourneyStatus] != DBNull.Value ? Convert.ToByte(sqlDataReader[TransactionsDBFields.JourneyStatus]) : (byte)0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.JourneyStatusDateTime))
                    objTransactions.JourneyStatusDateTime = (sqlDataReader[TransactionsDBFields.JourneyStatusDateTime] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.JourneyStatusDateTime]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.UserRequestDatetime))
                    objTransactions.UserRequestDatetime = (sqlDataReader[TransactionsDBFields.UserRequestDatetime] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.UserRequestDatetime]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.StatusId))
                    objTransactions.StatusId = (sqlDataReader[TransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[TransactionsDBFields.StatusId]) : (byte)0);
                if (sqlDataReader.HasColumn(TransactionsDBFields.CreatedDate))
                    objTransactions.CreatedDate = (sqlDataReader[TransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[TransactionsDBFields.CreatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(TransactionsDBFields.UpdatedDate))
                    objTransactions.UpdatedDate = (sqlDataReader[TransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[TransactionsDBFields.UpdatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(UsersDBFields.RowNumber))
                    objTransactions.RowNumber = (sqlDataReader[UsersDBFields.RowNumber] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.RowNumber]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.FirstName))
                    objTransactions.FirstName = (sqlDataReader[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FirstName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.LastName))
                    objTransactions.LastName = (sqlDataReader[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LastName]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.VehicleNo))
                    objTransactions.VehicleNo = (sqlDataReader[TransactionsDBFields.VehicleNo] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.VehicleNo]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.DropLocation))
                    objTransactions.DropLocation = (sqlDataReader[TransactionsDBFields.DropLocation] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.DropLocation]) : string.Empty);
                if (sqlDataReader.HasColumn(TransactionsDBFields.PickupLocation))
                    objTransactions.PickupLocation = (sqlDataReader[TransactionsDBFields.PickupLocation] != DBNull.Value ? Convert.ToString(sqlDataReader[TransactionsDBFields.PickupLocation]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.PhoneNumber))
                    objTransactions.PhoneNumber = (sqlDataReader[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.PhoneNumber]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.UserName))
                    objTransactions.UserName = (sqlDataReader[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.DriverName))
                    objTransactions.DriverName = (sqlDataReader[UsersDBFields.DriverName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.DriverName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.ActionBy))
                    objTransactions.ActionBy = (sqlDataReader[UsersDBFields.ActionBy] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.ActionBy]) : string.Empty);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objTransactions;
        }

        public List<Transactions> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<Transactions> list = new List<Transactions>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objTransactions = GetDetails(sqlDataReader);
                    list.Add(objTransactions);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public Transactions GetDetailsRecord(SqlDataReader sqlDataReader)
        {
            try
            {
                if (sqlDataReader.Read())
                {
                    objTransactions = GetDetails(sqlDataReader);
                }
                return objTransactions;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsRecord(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return new Transactions();
        }

        public List<Transactions> GetDetails(DataSet dataSet)
        {
            List<Transactions> Transactionss = new List<Transactions>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objTransactions = new Transactions();

                        if (drow.Table.Columns.Contains(TransactionsDBFields.ID))
                            objTransactions.ID = (drow[TransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UUID))
                            objTransactions.UUID = (drow[TransactionsDBFields.UUID] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UUID]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserID))
                            objTransactions.UserID = (drow[TransactionsDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverUserID))
                            objTransactions.DriverUserID = (drow[TransactionsDBFields.DriverUserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.DriverUserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDTo))
                            objTransactions.LocationMasterIDTo = (drow[TransactionsDBFields.LocationMasterIDTo] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDTo]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDFrom))
                            objTransactions.LocationMasterIDFrom = (drow[TransactionsDBFields.LocationMasterIDFrom] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDFrom]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.PickLocationLatitude))
                            objTransactions.PickLocationLatitude = (drow[TransactionsDBFields.PickLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.PickLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLatitude))
                            objTransactions.DropLocationLatitude = (drow[TransactionsDBFields.DropLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLongitude))
                            objTransactions.DropLocationLongitude = (drow[TransactionsDBFields.DropLocationLongitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLatitudeOnBooking))
                            objTransactions.DriverLocationLatitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLatitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLatitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLongitudeOnBooking))
                            objTransactions.DriverLocationLongitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLongitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLongitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStartDateTime))
                            objTransactions.JourneyStartDateTime = (drow[TransactionsDBFields.JourneyStartDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStartDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyEndDateTime))
                            objTransactions.JourneyEndDateTime = (drow[TransactionsDBFields.JourneyEndDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyEndDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.VerificationCode))
                            objTransactions.VerificationCode = (drow[TransactionsDBFields.VerificationCode] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.VerificationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatus))
                            objTransactions.JourneyStatus = (drow[TransactionsDBFields.JourneyStatus] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.JourneyStatus]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatusDateTime))
                            objTransactions.JourneyStatusDateTime = (drow[TransactionsDBFields.JourneyStatusDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStatusDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserRequestDatetime))
                            objTransactions.UserRequestDatetime = (drow[TransactionsDBFields.UserRequestDatetime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UserRequestDatetime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.StatusId))
                            objTransactions.StatusId = (drow[TransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.CreatedDate))
                            objTransactions.CreatedDate = (drow[TransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UpdatedDate))
                            objTransactions.UpdatedDate = (drow[TransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.UpdatedDate]) : DateTime.Now);

                        Transactionss.Add(objTransactions);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return Transactionss;
        }

        public Transactions GetDetailsobj(DataSet dataSet)
        {
            Transactions objTransactions = new Transactions();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objTransactions = new Transactions();

                        if (drow.Table.Columns.Contains(TransactionsDBFields.ID))
                            objTransactions.ID = (drow[TransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UUID))
                            objTransactions.UUID = (drow[TransactionsDBFields.UUID] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UUID]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserID))
                            objTransactions.UserID = (drow[TransactionsDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverUserID))
                            objTransactions.DriverUserID = (drow[TransactionsDBFields.DriverUserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.DriverUserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDTo))
                            objTransactions.LocationMasterIDTo = (drow[TransactionsDBFields.LocationMasterIDTo] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDTo]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDFrom))
                            objTransactions.LocationMasterIDFrom = (drow[TransactionsDBFields.LocationMasterIDFrom] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDFrom]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.PickLocationLatitude))
                            objTransactions.PickLocationLatitude = (drow[TransactionsDBFields.PickLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.PickLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.PickLocationLongitude))
                            objTransactions.PickLocationLongitude = (drow[TransactionsDBFields.PickLocationLongitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.PickLocationLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLatitude))
                            objTransactions.DropLocationLatitude = (drow[TransactionsDBFields.DropLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLongitude))
                            objTransactions.DropLocationLongitude = (drow[TransactionsDBFields.DropLocationLongitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLatitudeOnBooking))
                            objTransactions.DriverLocationLatitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLatitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLatitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLongitudeOnBooking))
                            objTransactions.DriverLocationLongitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLongitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLongitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStartDateTime))
                            objTransactions.JourneyStartDateTime = (drow[TransactionsDBFields.JourneyStartDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStartDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyEndDateTime))
                            objTransactions.JourneyEndDateTime = (drow[TransactionsDBFields.JourneyEndDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyEndDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.VerificationCode))
                            objTransactions.VerificationCode = (drow[TransactionsDBFields.VerificationCode] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.VerificationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatus))
                            objTransactions.JourneyStatus = (drow[TransactionsDBFields.JourneyStatus] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.JourneyStatus]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatusDateTime))
                            objTransactions.JourneyStatusDateTime = (drow[TransactionsDBFields.JourneyStatusDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStatusDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserRequestDatetime))
                            objTransactions.UserRequestDatetime = (drow[TransactionsDBFields.UserRequestDatetime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UserRequestDatetime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.StatusId))
                            objTransactions.StatusId = (drow[TransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.CreatedDate))
                            objTransactions.CreatedDate = (drow[TransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UpdatedDate))
                            objTransactions.UpdatedDate = (drow[TransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.UpdatedDate]) : DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objTransactions;
        }

        public Transactions GetDetails(DataTable dataTable)
        {
            Transactions objTransactions = new Transactions();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objTransactions = new Transactions();

                        if (drow.Table.Columns.Contains(TransactionsDBFields.ID))
                            objTransactions.ID = (drow[TransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UUID))
                            objTransactions.UUID = (drow[TransactionsDBFields.UUID] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UUID]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserID))
                            objTransactions.UserID = (drow[TransactionsDBFields.UserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.UserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverUserID))
                            objTransactions.DriverUserID = (drow[TransactionsDBFields.DriverUserID] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.DriverUserID]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDTo))
                            objTransactions.LocationMasterIDTo = (drow[TransactionsDBFields.LocationMasterIDTo] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDTo]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.LocationMasterIDFrom))
                            objTransactions.LocationMasterIDFrom = (drow[TransactionsDBFields.LocationMasterIDFrom] != DBNull.Value ? Convert.ToInt32(drow[TransactionsDBFields.LocationMasterIDFrom]) : 0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.PickLocationLatitude))
                            objTransactions.PickLocationLatitude = (drow[TransactionsDBFields.PickLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.PickLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.PickLocationLongitude))
                            objTransactions.PickLocationLongitude = (drow[TransactionsDBFields.PickLocationLongitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.PickLocationLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLatitude))
                            objTransactions.DropLocationLatitude = (drow[TransactionsDBFields.DropLocationLatitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLatitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DropLocationLongitude))
                            objTransactions.DropLocationLongitude = (drow[TransactionsDBFields.DropLocationLongitude] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DropLocationLongitude]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLatitudeOnBooking))
                            objTransactions.DriverLocationLatitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLatitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLatitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.DriverLocationLongitudeOnBooking))
                            objTransactions.DriverLocationLongitudeOnBooking = (drow[TransactionsDBFields.DriverLocationLongitudeOnBooking] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.DriverLocationLongitudeOnBooking]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStartDateTime))
                            objTransactions.JourneyStartDateTime = (drow[TransactionsDBFields.JourneyStartDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStartDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyEndDateTime))
                            objTransactions.JourneyEndDateTime = (drow[TransactionsDBFields.JourneyEndDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyEndDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.VerificationCode))
                            objTransactions.VerificationCode = (drow[TransactionsDBFields.VerificationCode] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.VerificationCode]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatus))
                            objTransactions.JourneyStatus = (drow[TransactionsDBFields.JourneyStatus] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.JourneyStatus]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.JourneyStatusDateTime))
                            objTransactions.JourneyStatusDateTime = (drow[TransactionsDBFields.JourneyStatusDateTime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.JourneyStatusDateTime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UserRequestDatetime))
                            objTransactions.UserRequestDatetime = (drow[TransactionsDBFields.UserRequestDatetime] != DBNull.Value ? Convert.ToString(drow[TransactionsDBFields.UserRequestDatetime]) : string.Empty);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.StatusId))
                            objTransactions.StatusId = (drow[TransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TransactionsDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.CreatedDate))
                            objTransactions.CreatedDate = (drow[TransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(TransactionsDBFields.UpdatedDate))
                            objTransactions.UpdatedDate = (drow[TransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TransactionsDBFields.UpdatedDate]) : DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objTransactions;
        }
    }
}