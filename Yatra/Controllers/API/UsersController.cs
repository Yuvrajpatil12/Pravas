using Yatra.Models;
using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.RegularExpressions;
using static Yatra.Models.ErrorViewModel;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Core.Utility.Common;
using Yatra.Resources;
using Core.Entity.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Core.Entity.ViewModel;
using static Yatra.Models.AccountViewModels;
using System.Text.Json.Serialization;
using Shiksha.Controllers;
using static Core.Entity.Enums.RoleEnums;

namespace Yatra.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly string _module = "Yatra.Controllers.API.UsersController";
        private JsonMessage _jsonMessage = null;
        private JsonMessage _jsonMessageResponse = null;
        private IHostingEnvironment _hostingEnvironment;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private IMemoryCache _cache;
        // private readonly IWebHostEnvironment _env;

        private Users ObjUserEntity = new Users(); // global object
        private UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade(); // global bf object

        public UsersController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        [SwaggerOperation("Save the user details")]
        public JsonResult Register(Users objUsers)
        {
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { objUsers });
                Log.WriteInfoLogWithoutMail(_module, "Register(Users=" + objUsers + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();

                if (objUsers != null && !string.IsNullOrEmpty(objUsers.PhoneNumber) && objUsers.RoleId != 0)
                {
                    string mobileNumber = objUsers.PhoneNumber;
                    string pattern = @"^\d{10}$";

                    if (Regex.IsMatch(mobileNumber, pattern))
                    {
                        if (objUsers.ID == 0)
                        {
                            _jsonMessage = new UsersBusinessFacade().IsUserIdExist(objUsers.PhoneNumber); //check if userid already exist or not
                            if (_jsonMessage != null && !_jsonMessage.IsSuccess)
                            {
                                return Json(_jsonMessage);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(objUsers.Password))
                                {
                                    var _encPassword = new Encription().Encrypt(objUsers.Password);
                                    objUsers.Password = _encPassword;
                                }

                                //#region save image and optimise image for profilePicture

                                //try
                                //{
                                //    if (!string.IsNullOrEmpty(objUsers.ProfilePicture))
                                //    {
                                //        if (objUsers.ProfilePicture != null && objUsers.ProfilePictureName != null || objUsers.ProfilePictureExtention != null)
                                //        {
                                //            string path = AdhilabhansahConstants.ProfilePicture;

                                //            if (!Directory.Exists(path))
                                //            {
                                //                Directory.CreateDirectory(path);
                                //            }

                                //            string ImagePath = Path.Combine(_hostingEnvironment.WebRootPath) + AdhilabhansahConstants.ProfilePicture;

                                //            call save image function here which is in imageconrtoller1
                                //            FileController objImg = new FileController(_hostingEnvironment);
                                //            ImagePath = objImg.saveImage(objUsers.ProfilePicture, objUsers.ProfilePictureName, objUsers.ProfilePictureExtention, ImagePath);

                                //            objUsers.ProfilePicture = ImagePath;
                                //        }
                                //    }
                                //}
                                //catch (Exception ex)
                                //{
                                //}

                                //#endregion save image and optimise image for profilePicture

                                var userId = new UsersBusinessFacade().Save((objUsers));

                                if (userId > 0)
                                {
                                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objUsers);
                                }
                                else
                                {
                                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_error, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, null);
                                }
                            }
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_somethingWentWrong, KeyEnums.JsonMessageType.DANGER, "", "", string.Format("Method : Register()"));

                            return Json(_jsonMessage);
                        }
                    }
                    else
                    {
                        // mobileNumber is invalid
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_mobileNumberisinvalid, KeyEnums.JsonMessageType.DANGER, "", "", string.Format("Method : Register()"));

                        if (_jsonMessage != null && !_jsonMessage.IsSuccess)
                        {
                            return Json(_jsonMessage);
                        }
                    }
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_somethingWentWrong, KeyEnums.JsonMessageType.DANGER, "", "", string.Format("Method : Register()"));

                    return Json(_jsonMessage);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "Register(Users=" + objUsers + ")", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        #endregion Register

        #region Login

        [HttpPost]
        [Route("Login")]
        public JsonResult Login(APILogin loginModels)
        {
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { loginModels });
                Log.WriteInfoLogWithoutMail(_module, "Login(APILogin= " + loginModels + ")", revsponse, "Request Recived");
            }
            catch (Exception)
            { }

            try
            {
                LoginVM loginVM = new LoginVM();
                Users objUserEntity = new Users();
                UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();

                string mobileNumber = loginModels.PhoneNumber;
                string pattern = @"^\d{10}$";

                if (Regex.IsMatch(mobileNumber, pattern) && !string.IsNullOrEmpty(loginModels.PhoneNumber))
                {
                    // check the status id
                    _jsonMessageResponse = usersBusinessFacade.IsUserExist(loginModels.PhoneNumber);
                    objUserEntity = (Users)_jsonMessageResponse.Data;

                    _jsonMessage = new UsersBusinessFacade().IsUserIdExist(mobileNumber); //check if userid already exist or not

                    if (_jsonMessage != null && !_jsonMessage.IsSuccess)
                    {
                        if (objUserEntity.StatusId == 1)
                        {
                            if (objUserEntity.StatusId != 4)
                            {
                                var objUserBusinessFacade = new UsersBusinessFacade();
                                string LoginMode = "";
                                string PhoneNumber = loginModels.PhoneNumber;
                                // mail send

                                _jsonMessage = new Controllers.UsersController(_hostingEnvironment, _httpContextAccessor, _cache).IsLoginValid("", "", loginModels.PhoneNumber, loginModels.DeviceID);

                                if (_jsonMessage.IsSuccess)
                                {
                                    var objUserEntity1 = new Controllers.UsersController(_hostingEnvironment, _httpContextAccessor, _cache).SendMail(PhoneNumber);
                                    objUserEntity = (Users)_jsonMessage.Data;

                                    new Controllers.UsersController(_hostingEnvironment, _httpContextAccessor, _cache).InsertAccessMember(objUserEntity.ID, "", loginModels.AccessMember);
                                }
                            }
                            else
                            {
                                string strMessage = "This number is rejected from admin.";
                                _jsonMessage = new JsonMessage(false, Resource.lbl_error, strMessage, KeyEnums.JsonMessageType.ERROR, "", "");
                            }
                        }
                        else
                        {
                            string strMessage = "Your account has been disabled.";
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, strMessage, KeyEnums.JsonMessageType.ERROR, "", "");
                        }
                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, "Your mobile number is not associated with Pravas", "Your mobile number is not associated with Pravas", KeyEnums.JsonMessageType.DANGER);
                        return Json(_jsonMessage);
                    }
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_mobileNumberisinvalid, KeyEnums.JsonMessageType.ERROR);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Login(APILogin= " + loginModels + ")", ex.Source, ex.Message);
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", "Ausnahme", string.Format("Method : Login(), Source : {0}, Message {1}", ex.Source, ex.Message));
            }

            return Json(_jsonMessage);
        }

        #endregion Login

        #region SaveAccessMember

        [HttpPost]
        [Route("SaveAccessMember")]
        [SwaggerOperation("User SaveAccessMember API", "User Access Member Insert Data")]
        public JsonResult SaveAccessMember(AccessMember objEntity)
        {
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { objEntity });
                Log.WriteInfoLogWithoutMail(_module, "SaveAccessMember(objEntity=" + objEntity + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                var amID = 0; // new UsersController(_hostingEnvironment, _httpContextAccessor, _cache).InsertAccessMember(objEntity.UserID, "", objEntity);
                if (amID > 0)
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, "", "true", objEntity);
                else
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_dataNotSavedSuccessfully, KeyEnums.JsonMessageType.FAILURE, "", "");
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "SaveAccessMember(objEntity=" + objEntity + ")", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        #endregion SaveAccessMember

        #region VerifyOTPAPI

        [HttpPost]
        [Route("VerifyOTPAPI")]
        public JsonResult VerifyOTPAPI(VerifyModel verifyModels)
        {
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { verifyModels });
                Log.WriteInfoLogWithoutMail(_module, "VerifyAPI(VerifyModel= " + verifyModels + ")", revsponse, "Request Recived");
            }
            catch (Exception)
            { }

            try
            {
                UserOTP objEntity = new UserOTP();

                string PhoneNumber = verifyModels.PhoneNumber;
                string OTP = verifyModels.OTP;

                // regular expression pattern to match 10 digit mobile number
                string pattern = @"^\d{10}$";

                // use Regex.IsMatch to check if mobileNumber matches pattern
                if (Regex.IsMatch(PhoneNumber, pattern) && !string.IsNullOrEmpty(verifyModels.OTP))
                {
                    objEntity = new UserOTPBusinessFacade().VerifyOTP(PhoneNumber, OTP, verifyModels.FCMToken); //check if userid already exist or not

                    // Expiry otp
                    if (objEntity.StatusID == 3)
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_verifyOTPExpiredMessage, KeyEnums.JsonMessageType.ERROR, objEntity);
                    }
                    // 'Invalid OTP'
                    else if (objEntity.StatusID == 4)
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_verifyOTPEnterValidOTPMessage, KeyEnums.JsonMessageType.ERROR, objEntity);
                    }
                    // valid otp
                    else if (objEntity.StatusID == 1)
                    {
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_verifyOTPValidMessage, KeyEnums.JsonMessageType.SUCCESS, objEntity);
                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_somethingWentWrong, KeyEnums.JsonMessageType.ERROR, objEntity);
                    }

                    return Json(_jsonMessage);
                }
                else
                {
                    // mobileNumber is invalid
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_mobileNumberisinvalid, KeyEnums.JsonMessageType.DANGER, "", "", string.Format("Method : Register()"));

                    if (_jsonMessage != null && !_jsonMessage.IsSuccess)
                    {
                        return Json(_jsonMessage);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(_jsonMessage);
        }

        #endregion VerifyOTPAPI

        #region Get Apis

        [Authorize]
        [HttpPost]
        [Route("GetUserDataById")]
        [SwaggerOperation("Get the user details")]
        public JsonResult GetUserDataById()
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { });
                Log.WriteInfoLogWithoutMail(_module, "GetUserDataById()", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();

                Users objData = new Users();
                objData = new UsersBusinessFacade().GetUserData(userAPIKey);

                // return the message
                if (!string.IsNullOrEmpty(userAPIKey))
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Id must be greater than 0", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetUserDataById()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllDrivers")]
        [SwaggerOperation("Get All Drivers")]
        public JsonResult GetAllDrivers()
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "GetAllDrivers(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                List<Users> objData = new List<Users>();
                objData = new UsersBusinessFacade().GetAllDrivers();
                if (objData.Count > 0 && objData != null)
                {
                    if (objData[0].UpAvailableSeats < 0)
                    {
                        objData[0].UpAvailableSeats = 0;
                    }
                    if (objData[0].DownAvailableSeats < 0)
                    {
                        objData[0].DownAvailableSeats = 0;
                    }
                }
                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetAllDrivers()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllLocations")]
        [SwaggerOperation("Get all location from master")]
        public JsonResult GetAllLocations()
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "GetAllLocations(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                List<LocationMaster> objData = new List<LocationMaster>();
                objData = new UsersBusinessFacade().GetAllLocations();

                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetAllLocations()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetDriverLocationByID")]
        [SwaggerOperation("Get drivers location from users tbl by passenger id(call after every 30 sec)")]
        public JsonResult GetDriverLocationByID(Int64 id)
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "GetDriverLocationByID(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                Users objdata = new Users();
                //UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();
                objdata = new UsersBusinessFacade().GetUserDataByID(id, "Driver");

                // return the message
                if (objdata != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objdata);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "The approval is pending. We will notify you as soon as a decision has been made", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetDriverLocationByID(userAPIKey=" + userAPIKey + ")", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllTransactions")]
        [SwaggerOperation("Get all transaction(Driver or Passenger)by roleid and also get transaction by particular id ")]
        public JsonResult GetAllTransactions(Int64 Id, int roleId)
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { roleId });
                Log.WriteInfoLogWithoutMail(_module, "GetAllTransactions(userAPIKey=" + roleId + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                List<Transactions> objData = new List<Transactions>();
                objData = new UsersBusinessFacade().GetAllTransactions(userAPIKey, Id, roleId);

                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetAllTransactions()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetDriverTransactions")]
        [SwaggerOperation("Get drivers transaction of journey status = (1,2,3)")]
        public JsonResult GetDriverTransactions(int roleId)
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { roleId });
                Log.WriteInfoLogWithoutMail(_module, "GetAllTransactions(roleId=" + roleId + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                List<Transactions> objData = new List<Transactions>();
                objData = new UsersBusinessFacade().GetDriverTransactions(userAPIKey, roleId);

                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetAllTransactions()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAvailableSeats")]
        [SwaggerOperation("Get GetSeats By LocationID")]
        public JsonResult GetAvailableSeats(Int64 LocationMasterIDFrom, Int64 LocationMasterIDTo)
        {
            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "GetAllLocations(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                Users objData = new Users();
                objData = new UsersBusinessFacade().GetAvailableSeats(LocationMasterIDFrom, LocationMasterIDTo);

                if (objData != null)
                {
                    if (objData.DownAvailableSeats < 0)
                    {
                        objData.DownAvailableSeats = 0;
                    }
                }

                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", objData);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetAllLocations()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpGet]
        [Route("GetVehicleDetails")]
        [SwaggerOperation("Get Vehicle Details")]
        public JsonResult GetVehicleDetails()
        {
            string userAPIKey = "";
            userAPIKey = GetJWTUserAuthenticationHeaderValue();
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "GetVehicleDetails(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                List<Users> objData = new List<Users>();
                objData = new UsersBusinessFacade().GetVehicleDetails(userAPIKey);
                VehicleDetails vehicleDetails = new VehicleDetails();
                if (objData != null && objData.Count > 0)
                {
                    vehicleDetails.DriverUserID = objData[0].ID;
                    vehicleDetails.IsAvailable = objData[0].IsAvailable;
                    vehicleDetails.AvailableSeats = objData[0].AvailableSeats;
                    vehicleDetails.VehicleNo = objData[0].VehicleNo;
                    vehicleDetails.VehicleType = objData[0].VehicleType;
                    vehicleDetails.StatusId = objData[0].StatusId;
                    vehicleDetails.CreatedDate = objData[0].UpdatedDate;
                }
                // return the message
                if (objData != null)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", vehicleDetails);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "GetVehicleDetails()", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateDriverStatus")]
        [SwaggerOperation("Update Driver Status")]
        public JsonResult UpdateDriverStatus(VehicleDetails vehicleDetails)
        {
            string userAPIKey = "";
            userAPIKey = GetJWTUserAuthenticationHeaderValue();
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { vehicleDetails });
                Log.WriteInfoLogWithoutMail(_module, "UpdateDriverStatus(VehicleDetails=" + vehicleDetails + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }
            try
            {
                if (vehicleDetails.IsAvailable == 1)
                {
                    List<Users> lstusers = new List<Users>();
                    // lstusers = new UsersBusinessFacade().GetAllDrivers();
                    lstusers = new UsersBusinessFacade().getUsersList(0);
                    List<string> fcms = new List<string>();
                    foreach (Users users in lstusers)
                    {
                        if (!string.IsNullOrWhiteSpace(users.FCMToken))
                            fcms.Add(users.FCMToken);
                    }

                    if (fcms.Count > 0)
                    {
                        // schoolMaster = new SchoolMasterBusinessFacade().GetListRecords(Convert.ToInt64(SchoolID));
                        string fcm = String.Join(",", fcms);

                        FirebaseController obj_firebaseController = new FirebaseController();
                        int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "DRIVERACTIVE", 0, "", "").Result;
                        Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForDeposit(FCMs = " + fcm + ",SchoolName=" + "" + ",Title= " + "" + ")", "", "Request Received");
                    }
                }
                if (vehicleDetails.IsAvailable == 0)
                {
                    List<Users> lstusers = new List<Users>();
                    // lstusers = new UsersBusinessFacade().GetAllDrivers();
                    lstusers = new UsersBusinessFacade().getUsersList(0);
                    List<string> fcms = new List<string>();
                    foreach (Users users in lstusers)
                    {
                        if (!string.IsNullOrWhiteSpace(users.FCMToken))
                            fcms.Add(users.FCMToken);
                    }

                    if (fcms.Count > 0)
                    {
                        // schoolMaster = new SchoolMasterBusinessFacade().GetListRecords(Convert.ToInt64(SchoolID));
                        string fcm = String.Join(",", fcms);

                        FirebaseController obj_firebaseController = new FirebaseController();
                        int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "DRIVERINACTIVE", 0, "", "").Result;
                        Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForDeposit(FCMs = " + fcm + ",SchoolName=" + "" + ",Title= " + "" + ")", "", "Request Received");
                    }
                }
                if (vehicleDetails.IsAvailable == 0)
                {
                    List<Transactions> lstTransactions = new List<Transactions>();
                    // lstusers = new UsersBusinessFacade().GetAllDrivers();
                    lstTransactions = new UsersBusinessFacade().GetAllTransactionsRecords();
                    foreach (Transactions transactions in lstTransactions)
                    {
                        Transactions objTransactions = new Transactions();
                        Users objData = new Users();
                        //objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                        objData = new UsersBusinessFacade().GetUserDataByID(transactions.UserID, "User");
                        int failedCount = 0;
                        if (objData != null)
                        {
                            List<string> fcms = new List<string>();
                            if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                                fcms.Add(objData.FCMToken);
                            if (fcms.Count > 0)
                            {
                                string fcm = String.Join(",", fcms);
                                FirebaseController obj_firebaseController = new FirebaseController();
                                if (transactions.JourneyStatus == 3)
                                {
                                    failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "RIDECOMPLETEDBYDRIVER").Result;
                                }
                                else if (transactions.JourneyStatus == 1 || transactions.JourneyStatus == 2)
                                {
                                    failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "DRIVERCANCELBOOKING").Result;
                                }

                                Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                            }
                        }
                    }
                }
                _jsonMessage = new UsersBusinessFacade().UpdateDriverStatus(vehicleDetails);
                if (vehicleDetails.IsAvailable == 0)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, "Driver not available", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", vehicleDetails);
                }
                else if (vehicleDetails.IsAvailable == 1)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, "Driver is available", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", vehicleDetails);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Internal Server Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "UpdateDriverStatus(VehicleDetails " + vehicleDetails + ")", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        #endregion Get Apis

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

                    obj_App_Update = obj_App_UpdateBusinessFacade.ValidateAPP(appUpdate);
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

        [Authorize]
        [HttpPost]
        [Route("UpdateDriverLocation")]
        [SwaggerOperation("Update Users Location")]
        public JsonResult UpdateDriverLocation(Users users)
        {
            Int64 IsSuccess = 0;

            string userAPIKey = "";
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { users });
                Log.WriteInfoLogWithoutMail(_module, "UpdateDriverLocation(userAPIKey=" + users + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                Users objData = new Users();
                objData = new UsersBusinessFacade().GetUserData(userAPIKey);
                users.ID = objData.ID;
                UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();
                IsSuccess = usersBusinessFacade.Save(users);

                //List<Users> lstUsers = new List<Users>();
                //lstUsers = new UsersBusinessFacade().GetAllDrivers();

                // return the message
                if (IsSuccess > 0)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", users);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "UpdateDriverLocation(users=" + users + ")", ex.Source, ex.Message);
            }

            return Json(_jsonMessage);
        }

        [Authorize]
        [HttpPost]
        [Route("SendNotificationToAllDriver")]
        [SwaggerOperation("Start transaction from pasenger")]
        public JsonMessage SendNotificationToAllDriver(Transactions transactions)
        {
            string userAPIKey = "";
            int failedCount = 0;
            Int64 IsSuccess = 0;
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { userAPIKey });
                Log.WriteInfoLogWithoutMail(_module, "SendNotificationToAllDriver(userAPIKey=" + userAPIKey + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }

            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                transactions.UUID = userAPIKey;
                TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                IsSuccess = transactionsBusinessFacade.Save(transactions);
                transactions.ID = IsSuccess;

                #region Send Notification

                List<LocationMaster> objData = new List<LocationMaster>();
                objData = new UsersBusinessFacade().GetAllLocations();
                string pickup = "";
                string drop = "";
                foreach (var obj in objData)
                {
                    if (transactions.LocationMasterIDTo == obj.ID)
                    {
                        pickup = obj.LocationName;
                    }
                    else if ((transactions.LocationMasterIDFrom == obj.ID))
                    {
                        drop = obj.LocationName;
                    }
                }

                if (IsSuccess > 0)
                {
                    List<string> fcms = new List<string>();
                    List<Users> lstusers = new List<Users>();
                    lstusers = new UsersBusinessFacade().GetAllDrivers();

                    foreach (Users users in lstusers)
                    {
                        if (!string.IsNullOrWhiteSpace(users.FCMToken))
                            fcms.Add(users.FCMToken);
                    }

                    if (fcms.Count > 0)
                    {
                        // schoolMaster = new SchoolMasterBusinessFacade().GetListRecords(Convert.ToInt64(SchoolID));
                        string fcm = String.Join(",", fcms);

                        FirebaseController obj_firebaseController = new FirebaseController();
                        failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "DRIVER", IsSuccess, pickup, drop).Result;
                        Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForDeposit(FCMs = " + fcm + ",SchoolName=" + "" + ",Title= " + "" + ")", "", "Request Received");
                    }
                }

                #endregion Send Notification

                if (IsSuccess > 0)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, "Send Notification", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "SendNotificationToAllDriver(userAPIKey=" + userAPIKey + ")", ex.Source, ex.Message);
            }

            return _jsonMessage;
        }

        [Authorize]
        [HttpPost]
        [Route("Booking")]
        [SwaggerOperation("Booking from driver")]
        public JsonMessage Booking(Transactions transactions)
        {
            string userAPIKey = "";
            Int64 IsSuccess = 0;
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { transactions });
                Log.WriteInfoLogWithoutMail(_module, "Booking(transactions=" + transactions + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }
            try
            {
                if (transactions.DriverUserID != 0 && transactions.JourneyStatus == 2)
                {
                    List<Users> lstUsers = new List<Users>();
                    lstUsers = new UsersBusinessFacade().GetAllDrivers();
                    lstUsers = lstUsers.Where(item => Convert.ToInt64(item.ID) == transactions.DriverUserID).ToList(); // Filter the particular driver record
                    if (lstUsers != null && lstUsers.Count > 0)
                    {
                        //if (lstUsers[0].AvailableSeats > 0)
                        //{

                        #region VerificationCode

                        int otpLength = 4; // Length of the OTP
                        int min = (int)Math.Pow(10, otpLength - 1); // Minimum value for the OTP based on its length
                        int max = (int)Math.Pow(10, otpLength) - 1; // Maximum value for the OTP based on its length

                        Random rnd = new Random();
                        int VerificationCode = rnd.Next(min, max);

                        #endregion VerificationCode

                        userAPIKey = GetJWTUserAuthenticationHeaderValue();
                        transactions.UUID = userAPIKey;
                        TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                        transactions.VerificationCode = VerificationCode.ToString();
                        IsSuccess = transactionsBusinessFacade.Save(transactions);

                        #region Send notification to particular user

                        Transactions objTransactions = new Transactions();
                        Users objData = new Users();
                        objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                        objData = new UsersBusinessFacade().GetUserDataByID(objTransactions.UserID, "User");

                        if (objData != null)
                        {
                            List<string> fcms = new List<string>();
                            if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                                fcms.Add(objData.FCMToken);
                            if (fcms.Count > 0)
                            {
                                string fcm = String.Join(",", fcms);
                                FirebaseController obj_firebaseController = new FirebaseController();

                                int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, VerificationCode.ToString(), "PASSENGER").Result;

                                Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                            }
                        }

                        #endregion Send notification to particular user

                        if (IsSuccess > 0)
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                        else
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, "internal server error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                        //}
                        //else
                        //{
                        //    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, "seats not available", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", "");
                        //}
                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_Cap_success, "internal server error", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", "");
                    }
                }
                else if (transactions.DriverUserID != 0 && transactions.JourneyStatus == 5)
                {
                    userAPIKey = GetJWTUserAuthenticationHeaderValue();
                    transactions.UUID = userAPIKey;
                    TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                    IsSuccess = transactionsBusinessFacade.Save(transactions);

                    #region Send notification to user when driver has cancel the booking

                    Transactions objTransactions = new Transactions();
                    Users objData = new Users();
                    objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                    objData = new UsersBusinessFacade().GetUserDataByID(objTransactions.UserID, "User");

                    if (objData != null)
                    {
                        List<string> fcms = new List<string>();
                        if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                            fcms.Add(objData.FCMToken);
                        if (fcms.Count > 0)
                        {
                            string fcm = String.Join(",", fcms);
                            FirebaseController obj_firebaseController = new FirebaseController();

                            int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "DRIVERCANCELBOOKING").Result;

                            Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                        }
                    }

                    #endregion Send notification to user when driver has cancel the booking

                    if (IsSuccess > 0)

                        _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "internal server error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
                else if (transactions.UserID != 0 && transactions.JourneyStatus == 5)
                {
                    userAPIKey = GetJWTUserAuthenticationHeaderValue();
                    transactions.UUID = userAPIKey;
                    TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                    IsSuccess = transactionsBusinessFacade.Save(transactions);

                    //Users objData = new Users();
                    //objData = new UsersBusinessFacade().GetUserDataByID(3, "User");
                    //if (objData != null)
                    //{
                    //    List<string> fcms = new List<string>();
                    //    if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                    //        fcms.Add(objData.FCMToken);
                    //    if (fcms.Count > 0)
                    //    {
                    //        string fcm = String.Join(",", fcms);
                    //        FirebaseController obj_firebaseController = new FirebaseController();

                    //        int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "PASSENGERCANCELBOOKING").Result;

                    //        Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                    //    }
                    //}

                    #region Send notification to driver when user has cancel the booking

                    userAPIKey = GetJWTUserAuthenticationHeaderValue();
                    List<Transactions> objData = new List<Transactions>();
                    objData = new UsersBusinessFacade().GetAllTransactions(userAPIKey, transactions.ID, 4);
                    List<string> fcms = new List<string>();
                    if (objData != null && objData.Count > 0)
                    {
                        if (objData[0].DriverUserID >= 0 && objData[0].DriverUserID != null)
                        {
                            Users users = new Users();   // accept the booking from driver and user cancel the booking send notification. to particular driver
                            users = new UsersBusinessFacade().GetUserDataByID(objData[0].DriverUserID, "User");
                            if (users != null)
                            {
                                if (!string.IsNullOrWhiteSpace(users.FCMToken))
                                    fcms.Add(users.FCMToken);
                                if (fcms.Count > 0)
                                {
                                    string fcm = String.Join(",", fcms);
                                    FirebaseController obj_firebaseController = new FirebaseController();

                                    int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "PASSENGERCANCELBOOKING").Result;

                                    Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                                }
                            }
                        }
                        else
                        {
                            List<Users> lstusers = new List<Users>();
                            lstusers = new UsersBusinessFacade().GetAllDrivers(); // before driver accept the booking  cancel ride from user then send notification to all driver

                            foreach (Users users in lstusers)
                            {
                                if (!string.IsNullOrWhiteSpace(users.FCMToken))
                                    fcms.Add(users.FCMToken);
                            }
                            if (fcms.Count > 0)
                            {
                                string fcm = String.Join(",", fcms);
                                FirebaseController obj_firebaseController = new FirebaseController();
                                int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "PASSENGERCANCELBOOKING").Result;

                                Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForDeposit(FCMs = " + fcm + ",SchoolName=" + "" + ",Title= " + "" + ")", "", "Request Received");
                            }
                        }
                    }

                    #endregion Send notification to driver when user has cancel the booking

                    if (IsSuccess > 0)
                        _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "internal server error", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_Cap_success, "something went wrong", KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", "");
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "Booking(transactions=" + transactions + ")", ex.Source, ex.Message);
            }

            return _jsonMessage;
        }

        [Authorize]
        [HttpPost]
        [Route("ConfirmBooking")]
        [SwaggerOperation("ConfirmBooking from driver")]
        public JsonMessage ConfirmBooking(Transactions transactions)
        {
            string userAPIKey = "";
            Int64 IsSuccess = 0;
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { transactions });
                Log.WriteInfoLogWithoutMail(_module, "ConfirmBooking(transactions=" + transactions + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }
            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                transactions.UUID = userAPIKey;
                TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                Transactions objTransactions = new Transactions();

                objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);

                if (objTransactions.VerificationCode == transactions.VerificationCode)
                {
                    IsSuccess = transactionsBusinessFacade.Save(transactions);

                    #region Send Notification

                    //Transactions transactions = new Transactions();
                    Users objData = new Users();
                    // objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                    objData = new UsersBusinessFacade().GetUserDataByID(objTransactions.UserID, "User");

                    if (objData != null)
                    {
                        List<string> fcms = new List<string>();
                        if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                            fcms.Add(objData.FCMToken);
                        if (fcms.Count > 0)
                        {
                            string fcm = String.Join(",", fcms);
                            FirebaseController obj_firebaseController = new FirebaseController();

                            int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "RIDESTARTED").Result;

                            Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                        }
                    }

                    #endregion Send Notification
                }
                if (IsSuccess > 0)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Verification Code Not Match", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "ConfirmBooking(transactions=" + transactions + ")", ex.Source, ex.Message);
            }

            return _jsonMessage;
        }

        [Authorize]
        [HttpPost]
        [Route("RideCompleted")]
        [SwaggerOperation("RideCompleted from driver")]
        public JsonMessage RideCompleted(Transactions transactions)
        {
            string userAPIKey = "";
            Int64 IsSuccess = 0;
            try
            {
                var revsponse = JsonConvert.SerializeObject(new { transactions });
                Log.WriteInfoLogWithoutMail(_module, "RideCompleted(transactions=" + transactions + ")", "INFO LOG ", revsponse);
            }
            catch (Exception)
            { }
            try
            {
                userAPIKey = GetJWTUserAuthenticationHeaderValue();
                transactions.UUID = userAPIKey;
                TransactionsBusinessFacade transactionsBusinessFacade = new TransactionsBusinessFacade();
                // Transactions objTransactions = new Transactions();
                IsSuccess = transactionsBusinessFacade.Save(transactions);

                #region Send Notification

                if (transactions.DriverUserID != 0)
                {
                    Transactions objTransactions = new Transactions();
                    Users objData = new Users();
                    objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                    objData = new UsersBusinessFacade().GetUserDataByID(objTransactions.UserID, "User");

                    if (objData != null)
                    {
                        List<string> fcms = new List<string>();
                        if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                            fcms.Add(objData.FCMToken);
                        if (fcms.Count > 0)
                        {
                            string fcm = String.Join(",", fcms);
                            FirebaseController obj_firebaseController = new FirebaseController();

                            int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "RIDECOMPLETEDBYDRIVER").Result;

                            Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                        }
                    }
                }
                if (transactions.UserID != 0)
                {
                    Transactions objTransactions = new Transactions();
                    Users objData = new Users();
                    objTransactions = transactionsBusinessFacade.GetTransanctionRecordByID(transactions.ID);
                    objData = new UsersBusinessFacade().GetUserDataByID(objTransactions.DriverUserID, "User");

                    if (objData != null)
                    {
                        List<string> fcms = new List<string>();
                        if (!string.IsNullOrWhiteSpace(objData.FCMToken))
                            fcms.Add(objData.FCMToken);
                        if (fcms.Count > 0)
                        {
                            string fcm = String.Join(",", fcms);
                            FirebaseController obj_firebaseController = new FirebaseController();

                            int failedCount = obj_firebaseController.SendFirebaseNotification(fcms, "", "RIDECOMPLETEDBYUSER").Result;

                            Log.WriteInfoLog(_module, "[FailedCount = " + failedCount.ToString() + "] SendFirebaseNotification_ForUser(FCMs = " + fcm + ",Name=" + "" + ",Title= " + "" + ")", "", "Request Received");
                        }
                    }
                }

                #endregion Send Notification

                if (IsSuccess > 0)
                {
                    _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, URLDetails.GetSiteRootUrl().TrimEnd('/'), "", transactions);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, "internalservererror", KeyEnums.JsonMessageType.WARNING, "", Resource.lbl_exception);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "RideCompleted(userAPIKey=" + userAPIKey + ")", ex.Source, ex.Message);
            }

            return _jsonMessage;
        }

        private string GetJWTUserAuthenticationHeaderValue()
        {
            string nameValue = null;

            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeaderValue))
            {
                // Authorization header value is available

                var authorizationHeaderValue = authHeaderValue.ToString();
                if (authorizationHeaderValue.StartsWith("Bearer "))
                {
                    authorizationHeaderValue = authorizationHeaderValue.Substring("Bearer ".Length);
                }
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken parsedToken = tokenHandler.ReadJwtToken(authorizationHeaderValue);

                // Print out all claims
                Console.WriteLine("Claims in the JWT token:");
                foreach (var claim in parsedToken.Claims)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                }

                // Example: Retrieving a specific claim by type
                Claim nameClaim = parsedToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");

                if (nameClaim != null)
                {
                    nameValue = nameClaim.Value;
                    Console.WriteLine($"Name: {nameValue}");
                }
            }

            return nameValue;
        }
    }
}