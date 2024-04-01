using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.Mapper;
using Core.Business.DataAccess.Wrapper;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;
using Core.Utility.Common;
using System.Data.SqlClient;
using Yatra.Resources;

namespace Core.Business.BusinessFacade
{
    public class UsersBusinessFacade//:UniversalObject
    {
        private dynamic objdynamicWrapper;
        private UsersWrapperColletion objUsersWrapperColletion = new UsersWrapperColletion();
        private UsersWrapper objUsersWrapper = new UsersWrapper();
        private static readonly string _module = "Core.Business.BusinessFacade.UsersBusinessFacade";
        private Users objEntity = new Users();
        private SqlConnection Connection;
        private JsonMessage _jsonMessage = null;

        private UsersDataMapper objUsersDataMapper = new UsersDataMapper();

        public UsersBusinessFacade()
        {
        }

        public UsersBusinessFacade(dynamic WrapperType)
        {
            objdynamicWrapper = WrapperType;
        }

        public dynamic GetRecordsList()
        {
            string[,] Sort = new string[1, 2];
            if (objdynamicWrapper.GetRecords(false, Sort))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }

        public dynamic GetRecordsListByValue(string Field, String Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecords(false, Sort, true, Field, Values))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }

        public dynamic GetRecordByValue(string Field, string Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecordByValue(Field, Values))
            {
                return objdynamicWrapper.objUsers;
            }
            return null;
        }

        public dynamic GetRecords(int Id)
        {
            if (objdynamicWrapper.GetRecordById(Id))
            {
                return objdynamicWrapper.objWrapperClass;
            }
            return null;
        }

        public Int64 Save(dynamic objEntity)
        {
            try
            {
                objUsersWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objUsersWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    Int64 ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = Int64.Parse(ID.ToString());
                    }
                    return objEntity.ID;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally { }
        }

        public dynamic getUsersList(Int64 userId)
        {
            dynamic _getList = null;

            try
            {
                _getList = objUsersWrapper.getUsersList(userId);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUsersList()", ex.Source, ex.Message, ex);
            }

            return _getList;
        }

        public List<Users> GetDriverLocation(string userAPIKey)
        {
            dynamic _list = null;

            List<Users> users = new List<Users>();

            try
            {
                users = objUsersWrapperColletion.GetDriverLocation(userAPIKey);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDriverLocation ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Users> GetAllDrivers()
        {
            dynamic _list = null;

            List<Users> users = new List<Users>();

            try
            {
                users = objUsersWrapperColletion.GetAllDrivers();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllDrivers ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Users> GetVehicleDetails(string userAPIKey)
        {
            dynamic _list = null;

            List<Users> users = new List<Users>();

            try
            {
                users = objUsersWrapperColletion.GetVehicleDetails(userAPIKey);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetVehicleDetails ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public JsonMessage UpdateDriverStatus(VehicleDetails vehicleDetails)
        {
            dynamic _list = null;

            List<Users> users = new List<Users>();

            try
            {
                _jsonMessage = objUsersWrapperColletion.UpdateDriverStatus(vehicleDetails);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetVehicleDetails ()", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

        public List<LocationMaster> GetAllLocations()
        {
            dynamic _list = null;

            List<LocationMaster> users = new List<LocationMaster>();

            try
            {
                users = objUsersWrapperColletion.GetAllLocations();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllLocations ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Transactions> GetAllTransactions(string userAPIKey, Int64 Id, int roleId)
        {
            dynamic _list = null;

            List<Transactions> users = new List<Transactions>();

            try
            {
                users = objUsersWrapperColletion.GetAllTransactions(userAPIKey, Id, roleId);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactions ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Transactions> GetDriverTransactions(string userAPIKey, int roleId)
        {
            dynamic _list = null;

            List<Transactions> users = new List<Transactions>();

            try
            {
                users = objUsersWrapperColletion.GetDriverTransactions(userAPIKey, roleId);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactions ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Users> GetDriverRecords()
        {
            dynamic _list = null;

            List<Users> users = new List<Users>();

            try
            {
                users = objUsersWrapperColletion.GetDriverRecords();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDriverRecords ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        #region IsUserExist

        public JsonMessage IsUserIdExist(string PhoneNumber)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsUserIdExist(PhoneNumber);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_MobileNumberInUse, KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, objEntity);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserIdExist(MobileNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        #endregion IsUserExist

        #region IsUserExist

        public JsonMessage IsUserExist(string PhoneNumber)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsUserExist(PhoneNumber);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Phone number In Use", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_emailAddressFailed, KeyEnums.JsonMessageType.FAILURE);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserExist(PhoneNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        #endregion IsUserExist

        #region Authenticate

        public Users Authenticate(string phoneNumber, string deviceid)
        {
            try
            {
                return objUsersWrapper.Authenticate(phoneNumber, deviceid);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate phonenumber =" + phoneNumber + ",deviceid=" + deviceid + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        #endregion Authenticate

        #region AuthenticateAdmin

        public Users AuthenticateAdmin(string username, string password, string deviceid)
        {
            try
            {
                return objUsersWrapper.AuthenticateAdmin(username, password, deviceid);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(username=" + username + ", password=" + password + ",deviceid:" + deviceid + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        #endregion AuthenticateAdmin

        #region GetUserDetailsByUsername

        public Users GetUserDetailsByUsername(string phonenumber)
        {
            objEntity = new Users();
            try
            {
                if (!string.IsNullOrEmpty(phonenumber))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.GetDetails(phonenumber);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserDetailsByUsername(phonenumber=" + phonenumber + ")", ex.Source, ex.Message, ex);
            }

            return objEntity;
        }

        #endregion GetUserDetailsByUsername

        #region GetUserData

        // change for return data by id 5
        public Users GetUserData(string userAPIKey)
        {
            Users objUsers = new Users();

            try
            {
                objUsers = objUsersWrapperColletion.GetUserData(userAPIKey);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserData()", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

        public Users GetUserDataByID(Int64 userid, string type)
        {
            Users objUsers = new Users();

            try
            {
                objUsers = objUsersWrapperColletion.GetUserDataByID(userid, type);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserDataByID()", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

        public Users GetUserByIdDetails(Int64 userId)
        {
            Users objUsers = new Users();

            try
            {
                objUsers = objUsersWrapperColletion.GetUserByIdDetails(userId);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserByIdDetails()", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

        public dynamic GetAvailableSeats(Int64 LocationMasterIDFrom, Int64 LocationMasterIDTo)
        {
            dynamic _list = null;

            try
            {
                _list = objUsersWrapper.GetAvailableSeats(LocationMasterIDFrom, LocationMasterIDTo);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAvailableSeats()", ex.Source, ex.Message, ex);
            }

            return _list;
        }

        public List<Transactions> GetAllTransactionsRecords()
        {
            dynamic _list = null;

            List<Transactions> users = new List<Transactions>();

            try
            {
                users = objUsersWrapperColletion.GetAllTransactionsRecords();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAllTransactionsRecords ()", ex.Source, ex.Message, ex);
            }

            return users;
        }

        #endregion GetUserData
        public JsonMessage UpdateUser (Int64 ID, string PhoneNumber)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.UpdateUser(ID,PhoneNumber);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(true, Resource.lbl_error, "User deleted successfully", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_emailAddressFailed, KeyEnums.JsonMessageType.FAILURE);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserExist(PhoneNumber=" + PhoneNumber + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }
    }
}