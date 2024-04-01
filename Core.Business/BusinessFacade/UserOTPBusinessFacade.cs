using Core.Entity.Common;
using Core.Entity.Enums;
using Yatra.Resources;
using Core.Utility.Common;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.Wrapper;
using Core.Entity;

namespace Core.Business.BusinessFacade
{
    public class UserOTPBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper;
        UserOTPWrapperColletion objUserOTPWrapperColletion = new UserOTPWrapperColletion();
        UserOTPWrapper objUserOTPWrapper = new UserOTPWrapper();
        private static readonly string _module = "Core.Business.BusinessFacade.UserOTPBusinessFacade";
        JsonMessage _jsonMessage = null;
        UserOTP objEntity = new UserOTP();
        public UserOTPBusinessFacade()
        {

        }
        public UserOTPBusinessFacade(dynamic WrapperType)
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
        public bool Save(dynamic objEntity)
        {
            try
            {

                objdynamicWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objdynamicWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    long ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = ID;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { }

        }



        #region VerifyOTP
        public UserOTP VerifyOTP(string PhoneNumber, string OTP, string FCMToken = "")
        {

            UserOTP userOTP = new UserOTP();
            try
            {
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    objUserOTPWrapper = new UserOTPWrapper();
                    objEntity = objUserOTPWrapper.VerifyOTP(PhoneNumber, OTP, FCMToken);

                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "VerifyOTP(PhoneNumber=" + PhoneNumber + ", OTP" + OTP + ")", ex.Source, ex.Message, ex);
            }
            return objEntity;
        }
        #endregion



    }
}
