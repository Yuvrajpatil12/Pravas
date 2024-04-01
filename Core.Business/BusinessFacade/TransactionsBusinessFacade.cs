using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Business.DataAccess.Wrapper;
using Core.Business.DataAccess.Mapper;
using Core.Business.DataAccess.DataAccessLayer.General;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Entity;
using Core.Business.DataAccess.Constants;
using Core.Utility;
using Core.Entity.Common;
using Core.Utility.Common;

namespace Core.Business.BusinessFacade
{
    public class TransactionsBusinessFacade//:UniversalObject
    {
        private dynamic objdynamicWrapper;
        private TransactionsWrapperColletion objTransactionsWrapperColletion = new TransactionsWrapperColletion();
        private TransactionsWrapper objTransactionsWrapper = new TransactionsWrapper();
        private static readonly string _module = "Core.Business.BusinessFacade.TransactionsBusinessFacade";

        public TransactionsBusinessFacade()
        {
        }

        public TransactionsBusinessFacade(dynamic WrapperType)
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
                objTransactionsWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objTransactionsWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    Int64 ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = ID;
                    }
                    return ID;
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
                _getList = objTransactionsWrapperColletion.getUsersList(userId);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUsersList()", ex.Source, ex.Message, ex);
            }

            return _getList;
        }

        public dynamic GetTransanctionRecordByID(Int64 id)
        {
            dynamic _list = null;

            try
            {
                _list = objTransactionsWrapper.GetTransanctionRecordByID(id);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetTransanctionRecordByID()", ex.Source, ex.Message, ex);
            }

            return _list;
        }
    }
}