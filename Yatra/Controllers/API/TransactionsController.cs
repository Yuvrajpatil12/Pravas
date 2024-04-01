using Core.Business.BusinessFacade;
using Core.Entity.Common;
using Core.Entity.Enums;
using Core.Entity;
using Yatra.Resources;
using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Yatra.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private JsonMessage _jsonMessage = null;
        private readonly string _module = "Yatra.Controllers.App.AppController";

        [HttpPost]
        [Route("AppUpdate")]
        public dynamic AppUpdate(AppUpdate appUpdate)
        {
            var response = JsonConvert.SerializeObject(new { appUpdate });

            try
            {
                var requestObj = JsonConvert.SerializeObject(new { appUpdate });
                Log.WriteInfoLogWithoutMail(_module, "Login(APILogin = " + appUpdate + ")", requestObj, "Request Received");
            }
            catch (Exception ex)
            {
            }

            try
            {
                if (string.IsNullOrWhiteSpace(appUpdate.Version) || string.IsNullOrWhiteSpace(appUpdate.Build) || string.IsNullOrWhiteSpace(appUpdate.AppType.ToString()))
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "empty Device ID", KeyEnums.JsonMessageType.ERROR);
                    return _jsonMessage;
                }
                else
                {
                    AppUpdateBusinessFacade obj_App_UpdateBusinessFacade = new AppUpdateBusinessFacade();

                    AppUpdate obj_App_Update = new AppUpdate();

                    // obj_App_Update = obj_App_UpdateBusinessFacade.ValidateAPP(appUpdate);
                    //obj_App_Update = appUpdate;

                    if (obj_App_Update != null)
                    {
                        if (obj_App_Update.StatusId == 1)
                        {
                            //response = JsonConvert.SerializeObject(new
                            //{
                            //    Response = obj_App_Update,
                            //});

                            _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, obj_App_Update);

                            return _jsonMessage;
                            //response = JsonConvert.SerializeObject(new
                            //{
                            //    Response = _jsonMessage
                            //});
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_versionError, KeyEnums.JsonMessageType.ERROR);

                            return _jsonMessage;

                            //response = JsonConvert.SerializeObject(new
                            //{
                            //    Response = _jsonMessage,
                            //});
                        }
                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_versionError, KeyEnums.JsonMessageType.ERROR);
                    }
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", "", string.Format("Method : AppUpdate(), Source : {0}, Message {1}", ex.Source, ex.Message));
            }

            return _jsonMessage;
        }
    }
}