using Yatra.Utility.Common;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.Wrapper;
using Core.Entity;
using Core.Utility.Common;

namespace Core.Business.BusinessFacade
{
    public class ShortUrlBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper;
        ShortUrlWrapperColletion objShortUrlWrapperColletion = new ShortUrlWrapperColletion();
        ShortUrlWrapper objShortUrlWrapper = new ShortUrlWrapper();
        private static readonly string _module = "Core.Business.BusinessFacade.ShortUrlBusinessFacade";
        public ShortUrlBusinessFacade()
        {

        }
        public ShortUrlBusinessFacade(dynamic WrapperType)
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

                objShortUrlWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objShortUrlWrapper.Save(ref CommandsObj, ref commandCounter);
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

        public string MakeShortURL(string strURL)
        {
            string shortAddress = strURL;
            try
            {
                ShortUrl objShort_Url = new ShortUrl();
                objShort_Url.URLString = GetShortURLFromPath(strURL);
                if (objShort_Url.URLString != strURL)
                    shortAddress = objShort_Url.URLString;
                else
                {
                    Save(objShort_Url);
                    shortAddress = YatraConstants.shortURL + objShort_Url.KeyValue;
                    //// changes by pratik
                    //shortAddress = AdhilabhansahConstants.shortURL ;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "MakeShortURL(strURL : " + strURL + ")", ex.Source, ex.Message, ex);
            }
            return shortAddress;
        }


        public string GetShortURLFromPath(string strURL)
        {
            string shortAddress = strURL;
            try
            {
                ShortUrl objShort_Url = new ShortUrl();
                objShort_Url = GetShortURLKey(strURL);
                if (!string.IsNullOrWhiteSpace(objShort_Url.KeyValue))
                    shortAddress = YatraConstants.shortURL + objShort_Url.KeyValue;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetShortURLFromPath(strURL : " + strURL + ")", ex.Source, ex.Message, ex);
            }
            return shortAddress;
        }

        public ShortUrl GetShortURLKey(string URLString)
        {
            if (objShortUrlWrapper.GetShortURLKey(URLString))
            {
                return objShortUrlWrapper.objWrapperClass;
            }
            return new ShortUrl();
        }




    }
}
