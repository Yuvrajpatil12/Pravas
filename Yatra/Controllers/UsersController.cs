using Core.Entity.Enums;
using Core.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Core.Entity;

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Core.Entity.Common;
using Core.Business.BusinessFacade;
using RestSharp;
using Core.Utility.Common;
using System.Text.RegularExpressions;
using Yatra.Models;
using System.Resources;
using Yatra.Utility.Common;
using Yatra.Resources;

namespace Yatra.Controllers
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class UsersController : Controller
    {
        private readonly string _module = "Yatra.Controllers.UserController";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IMemoryCache _cache;
        private IHostingEnvironment _hostingEnvironment;
        private Int64 _userId = 0;
        private JsonMessage _jsonMessage = null;
        private Helper _helper;
        private LoginVM _loginVM = null;

        private Users objUserEntity = new Users();
        private UsersBusinessFacade objUserBusinessFacade = new UsersBusinessFacade();

        public UsersController(IHostingEnvironment environment = null, IHttpContextAccessor httpContextAccessor = null,
            IMemoryCache cache = null)
        {
            _hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;
            _userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;

            _cache = cache;
            _helper = new Helper(_httpContextAccessor);
            _loginVM = _helper.GetSession();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            _helper = new Helper(_httpContextAccessor);
            _loginVM = _helper.GetSession();
            //if (_loginVM != null && _loginVM.Id > 0)

            //    if (_loginVM.RoleId == 1 || _loginVM.RoleId == 2)
            //    {
            //        return RedirectToAction(YatraConstants.SuperAdminDefaultController, YatraConstants.SuperAdminDefaultView);

            //    }

            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password, string queryString, bool isRemember, bool autologin)
        {
            _helper.KillSession();
            try
            {
                SetCookie("RememberMe", isRemember.ToString().ToLower(), Convert.ToInt32(YatraConstants.LoginCookie));

                LoginVM loginVM = new LoginVM();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_emailPasswordRequired, KeyEnums.JsonMessageType.ERROR);
                }
                else
                {
                    password = new Encription().Encrypt(password);
                    _jsonMessage = IsLoginValid(username, password, "", "");

                    if (loginVM != null)
                    {
                        if (_jsonMessage.IsSuccess)
                        {
                            if (isRemember)
                            {
                                SetCookie("UserName", username, Convert.ToInt32(YatraConstants.LoginCookie));
                                SetCookie("ReturnURL", _jsonMessage.ReturnUrl, Convert.ToInt32(YatraConstants.LoginCookie));
                            }
                            objUserEntity = (Users)_jsonMessage.Data;
                            if (isRemember)
                            {
                                SetCookie("UserRoleID", objUserEntity.RoleId.ToString(), Convert.ToInt32(YatraConstants.LoginCookie));
                            }

                            if (objUserEntity != null)
                            {
                                _helper.SetSession(objUserEntity);
                            }

                            // _helper.SetUserLanguage(objUserEntity.LanguageId);
                            //InsertAccessMember(objUserEntity.ID, "Login", getAccessMember());

                            string Impersonation_Users = null;
                            Impersonation_Users = _httpContextAccessor.HttpContext.Session.GetString("Impersonation_Users");

                            Impersonation_Users += username + ",";
                            _httpContextAccessor.HttpContext.Session.SetString("Impersonation_Users", Impersonation_Users);

                            if (objUserEntity.RoleId == 1)//For checking set to 0 need to be change
                            {
                                _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);

                                _jsonMessage.ReturnUrl = YatraConstants.CoreDomain + YatraConstants.SuperAdminDefaultController + "/" + YatraConstants.SuperAdminDefaultView + "";
                            }
                            else if (objUserEntity.RoleId == 2)
                            {
                                _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                                _jsonMessage.ReturnUrl = YatraConstants.CoreDomain + YatraConstants.AdminDefaultController + "/" + YatraConstants.AdminDefaultView + "";
                            }
                            
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_invalidEmailAddressPassword, KeyEnums.JsonMessageType.ERROR);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Login(username:" + username + ",password:" + password + ")", ex.Source, ex.Message, ex);
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", "username", string.Format("Method : Login(), Source : {0}, Message {1}", ex.Source, ex.Message));
            }
            return Json(_jsonMessage);
        }

        #region IsLoginValid

        public JsonMessage IsLoginValid(string username, string password, string phoneNumber, string deviceID, string LoginMode = "")
        {
            Users objUserEntity = new Users();
            try
            {
                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(phoneNumber))
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_somethingWentWrong, Resource.lbl_somethingWentWrong, KeyEnums.JsonMessageType.DANGER);
                }
                else
                {
                    string[] Fieldsname = new string[2];
                    string[] Values = new string[2];
                    Fieldsname[0] = username;
                    Fieldsname[1] = password;
                    Values[0] = username;
                    Values[1] = password;

                    UsersBusinessFacade objUsersBusinessFacade = new UsersBusinessFacade();
                    if (!string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        if (string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_mobileNumberisinvalid, Resource.lbl_mobileNumberisinvalid, KeyEnums.JsonMessageType.DANGER);
                        }
                        else
                        {
                            objUserEntity = objUsersBusinessFacade.Authenticate(phoneNumber, deviceID);
                            //if (objUserEntity != null)
                            //{
                            //    Log.WriteLog(_module, "IsLoginValid(objUserEntity=" + objUserEntity.OTP + ", mobileNumber=" + objUserEntity.PhoneNumber + ",sender:" + objUserEntity.FullName + ")", "response.Content:" + objUserEntity.ID, "");
                            //}
                            // company name field read as otp column
                            string OTP = objUserEntity.CompanyName;
                            var options = new RestClientOptions("https://control.msg91.com/api/v5/flow/");

                            string countryCode = "91";
                            string mobileNumber = phoneNumber;
                            string completeMobileNumber = countryCode + mobileNumber;
                            string templateID = "647840c6d6fc05420b3d6c34";
                            string sender = "RxmgQR";

                            var client = new RestClient(options);
                            var request = new RestRequest("https://control.msg91.com/api/v5/flow/", Method.Post);
                            request.AddHeader("accept", "application/json");
                            request.AddHeader("authkey", "395872AlBBgNp1K9k6450ccdbP1");
                            request.AddHeader("content-type", "application/json");
                            request.AddHeader("Cookie", "PHPSESSID=vjrai1bo1ba8fahl9d4g2n4427");
                            var body = @"" + "\n" +
                            @"{" + "\n" +
                            @"  ""template_id"": ""647840c6d6fc05420b3d6c34""," + "\n" +
                            @"  ""sender"": """ + sender + @"""," + "\n" +
                            @"  ""short_url"": ""0""," + "\n" +
                            @"  ""mobiles"": """ + completeMobileNumber + @"""," + "\n" +
                            @"  ""var"": """ + OTP + @"""" + "\n" +
                            @"}" + "\n" +
                            @"";
                            request.AddStringBody(body, DataFormat.Json);
                            RestResponse response = client.Execute(request);
                            Console.WriteLine(response.Content);
                            //if(response != null)
                            //{
                            //    Log.WriteLog(_module, "IsLoginValid(OTP=" + OTP + ", mobileNumber=" + completeMobileNumber + ",sender:" + sender + ")", "response.Content:" + response.Content, "");
                            //}

                            Console.WriteLine(body);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(username))
                            _jsonMessage = new JsonMessage(false, Resource.lbl_msg_invalidEmailAddress, Resource.lbl_msg_invalidEmailAddress, KeyEnums.JsonMessageType.DANGER);
                        else if (string.IsNullOrWhiteSpace(password))
                            _jsonMessage = new JsonMessage(false, Resource.lbl_msg_invalidPassowrd, Resource.lbl_msg_invalidPassowrd, KeyEnums.JsonMessageType.DANGER);
                        else
                        {
                            objUserEntity = objUsersBusinessFacade.AuthenticateAdmin(username, password, deviceID);
                        }
                    }

                    if (objUserEntity != null)
                    {
                        if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Active)
                        {
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_OTPGeneratedMessage, KeyEnums.JsonMessageType.SUCCESS, "strUrl", "true", objUserEntity);

                            if (objUserEntity.DeviceID == "1")
                            {
                                _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, "Device ID Different", KeyEnums.JsonMessageType.SUCCESS, "", "deviceiddiff", objUserEntity);
                            }
                        }
                        else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Pending)
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_accountNotActivated, KeyEnums.JsonMessageType.FAILURE, "/Users/Login");
                        }
                        else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Deleted)
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_accountDeleted, KeyEnums.JsonMessageType.FAILURE, "/Users/Login");
                        }
                        else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Active && objUserEntity.IsVerified == true)
                        {
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, "StrUrl", "true", objUserEntity);
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_loginFailed, KeyEnums.JsonMessageType.ERROR);
                        }
                        if (!string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_OTPGeneratedMessage, KeyEnums.JsonMessageType.SUCCESS, "strUrl", "true", objUserEntity);
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_EmailLoginSuccessMessage, KeyEnums.JsonMessageType.SUCCESS, "strUrl", "true", objUserEntity);
                        }
                    }
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_invalidEmailAddressPassword, KeyEnums.JsonMessageType.ERROR);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_msg_internalServerErrorOccurred, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, ex.Message);
                Log.WriteLog(_module, "IsLoginValid(username=" + username + ", password=" + "" + ",deviceID:" + deviceID + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

        #endregion IsLoginValid

        #region IsValidPhoneNumber

        private static bool IsValidPhoneNumber(string number)
        {
            // Regex pattern to match India phone numbers
            string pattern = @"^(\+91[\-\s]?)?[0]?(91)?[6789]\d{9}$";

            // Match the pattern against the input number
            Match match = Regex.Match(number, pattern);

            // If the pattern matches, it's a valid India phone number
            return match.Success;
        }

        #endregion IsValidPhoneNumber

        #region SendMail

        public JsonResult SendMail(string phoneNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    CommonData _CommonData = new CommonData();
                    objUserEntity = objUserBusinessFacade.GetUserDetailsByUsername(phoneNumber);

                    // when role approval or campaign manager password reset.
                    //if (objUserEntity.ID == 0 && objUserEntity.AlternateEmail == null)
                    //{
                    //    _jsonMessage = objUsersBusinessFacade.IsUserExistAdmin(phoneNumber);

                    //    objUserEntity = (Users)_jsonMessage.Data;

                    //}

                    if (objUserEntity.ID > 0 && objUserEntity.PhoneNumber != "")
                    {
                        switch (objUserEntity.StatusId)
                        {
                            case (byte)StateEnums.Statuses.Active:
                            case (byte)StateEnums.Statuses.Pending:
                                string UId = objUserEntity.ID.ToString();
                                string userEmail = objUserEntity.UserName.ToString();

                                string FullName = !string.IsNullOrWhiteSpace(objUserEntity.FullName) ? objUserEntity.FullName : "";
                                // temporary base this field read the otp
                                string OTP = !string.IsNullOrWhiteSpace(objUserEntity.CompanyName) ? objUserEntity.CompanyName : "";
                                FullName = FullName.Trim();
                                string hostAddress = YatraConstants.CoreDomain; //URLDetails.GetSiteRootUrl(); //Request.UrlReferrer.Host.ToString();
                                string token = CommonUtilities.RandomGenerator.Generate(6);
                                string Carbon_Copy = YatraConstants.Account_Confirmation;
                                string url = hostAddress + "Users/ResetPassword?ui=" + UId + "&rd=" + token;
                                ShortUrlBusinessFacade objShortUrlBusinessFacade = new ShortUrlBusinessFacade();

                                string shortAddress = objShortUrlBusinessFacade.MakeShortURL(url);
                                shortAddress += "Users/ResetPassword?ui=" + UId + "&rd=" + token;
                                string ResetPassLink = "<a href='" + shortAddress + "'>" + shortAddress + "</a>";

                                string WEB_LINK = "<a href=\"" + YatraConstants.shortURL.TrimEnd('/') + "\">" + YatraConstants.shortURL.TrimEnd('/') + "</a>";
                                string tempPath = null;
                                string mailTemplate = null;
                                string EmailAddress = phoneNumber;
                                // find this is number or email address
                                if (EmailAddress.Contains("@"))
                                {
                                    //if (objUserEntity.RoleID == 3)
                                    //{
                                    //    tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\EN\\" + "CampaignManagerPasswordSharing.html";
                                    //    FullName = objUserEntity.FullName;

                                    //    mailTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);
                                    //    mailTemplate = mailTemplate.Replace("[NAME]", FullName).Replace("[RESET_PASS_LINK]", ResetPassLink).Replace("[APP]", AdhilabhansahConstants.AppName);

                                    //}
                                    //else if(objUserEntity.RoleID == 4)
                                    //{
                                    //    tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\EN\\" + "RoleApprovalPasswordSharing.html";
                                    //    FullName = objUserEntity.FullName;

                                    //    mailTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);
                                    //    mailTemplate = mailTemplate.Replace("[NAME]", FullName).Replace("[RESET_PASS_LINK]", ResetPassLink).Replace("[APP]", AdhilabhansahConstants.AppName);
                                    //}
                                }
                                else
                                {
                                    FullName = objUserEntity.FullName;
                                    tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\EN\\" + "OTP.html";
                                    mailTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);
                                    mailTemplate = mailTemplate.Replace("[NAME]", FullName).Replace("[PHONENUMBER]", phoneNumber).Replace("[OTP]", OTP).Replace("[APP]", YatraConstants.AppName);
                                    EmailAddress = phoneNumber + "@wits.bz";
                                }

                                Email email = new Email(YatraConstants.DefaultmailID, EmailAddress);
                                email.ReplyTo = YatraConstants.ReplyToEmail;
                                email.BCC = YatraConstants.Account_Confirmation;
                                email.Subject = email.GetSubject(mailTemplate);
                                email.IsBodyHTML = true;
                                email.Body = mailTemplate;

                                if (email.Send())
                                {
                                    _jsonMessage = new JsonMessage(true, @Resources.Resource.lbl_Cap_information, @Resources.Resource.lbl_msg_emailPasswordRequired, KeyEnums.JsonMessageType.INFO);
                                }
                                else
                                    _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_emailPasswordRequired, KeyEnums.JsonMessageType.ERROR);
                                break;

                            case (byte)StateEnums.Statuses.InActive:
                                _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_accountDisabled, KeyEnums.JsonMessageType.FAILURE);
                                break;

                            case (byte)StateEnums.Statuses.Deleted:
                                _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_accountNotActivated, KeyEnums.JsonMessageType.FAILURE);
                                break;

                            default:
                                _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_invalidEmailAddress, KeyEnums.JsonMessageType.ERROR);
                                break;
                        }
                    }
                    else
                        _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_accountDoesNotExit, KeyEnums.JsonMessageType.ERROR);
                }
                else
                    _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_emailPasswordRequired, KeyEnums.JsonMessageType.ERROR);
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, @Resources.Resource.lbl_error, @Resources.Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", @Resources.Resource.lbl_exception, ex.Message);
                Log.WriteLog(_module, "SendMail(username=" + phoneNumber + ")", ex.Source, ex.Message, ex);
            }
            return Json(_jsonMessage);
        }

        #endregion SendMail

        #region InsertAccessMember

        public decimal InsertAccessMember(Int64 ID, string clickedby, AccessMember objAccessMember)
        {
            try
            {
                AccessMember objAM = new AccessMember();
                objAM.UserID = Convert.ToInt64(ID);
                objAM.Url = objAccessMember.Url;
                objAM.ReferrerURL = objAccessMember.ReferrerURL;
                objAM.Port = objAccessMember.Port;
                objAM.Host = objAccessMember.Host;
                objAM.RemoteAddrIP = objAccessMember.RemoteAddrIP;
                objAM.UserAgent = objAccessMember.UserAgent;
                objAM.BrowserType = objAccessMember.BrowserType;
                objAM.BrowserVersion = objAccessMember.BrowserType;
                objAM.Platform = objAccessMember.Platform;
                objAM.DeviceName = objAccessMember.DeviceName;
                objAM.DeviceType = objAccessMember.DeviceType;
                objAM.OperatingSystem = objAccessMember.OperatingSystem;
                objAM.DeviceModel = objAccessMember.DeviceModel;
                objAM.Build = objAccessMember.Build;
                objAM.Version = objAccessMember.Version;

                AccessMemberBusinessFacade objAccessMemberBusinessFacade = new AccessMemberBusinessFacade();
                objAccessMemberBusinessFacade.Save(objAM);
                return objAM.ID;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "InsertAccessMember(ID: " + ID + ")", ex.Source, ex.Message);
            }
            return 0;
        }

        #endregion InsertAccessMember

        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime > 0)
                option.Expires = DateTime.Now.AddDays(double.Parse(expireTime.ToString()));
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
    }
}