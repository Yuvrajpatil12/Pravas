using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;

using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using X.PagedList;
using Yatra.Models;
using Yatra.Resources;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Yatra.Controllers
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class deleteUserController : Controller
    {
        private static string _module = "Yatra.Controllers.deleteUserController";
        private Int64 _userId = 0;
        private Int64 _schoolId = 0;
        private string _role = "";
        private Int64 _companyid = 0;
        private Int64 _locationid = 0;
        private string _cacheKey = "deleteUserController_";
        private JsonMessage _jsonMessage = null;
        private int page = 1, size = 10;
        private bool isValidUser = false;
        private IMemoryCache _cache;
        private Helper _helper;

        private List<Users> _list = new List<Users>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public deleteUserController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor = null, IMemoryCache cache = null)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _helper = new Helper(_httpContextAccessor);
            _userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;
            _role = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "";

            //Log.WriteLog("UserID:" + _userId, "_role:" + _role, "", "");
            //isValidUser = _helper.IsValidUser(_userId, RoleEnums.SuperAdmin + "," + RoleEnums.Admin);

            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuId = KeyEnums.MenuKeys.liViews.ToString();
            var startDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.AddDays(-30), TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString("yyyy-MM-dd");
            var toDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString("yyyy-MM-dd");

            if (isValidUser)
            {
                try
                {
                    //_list = GetList("", "", "asc", ref page, ref size, "sort", startDate, toDate, _userId, true, ViewBag.RequestList);
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "Index", ex.Source, ex.Message, ex);
                }
            }
            return View(_list.ToPagedList(1, 10));
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult DeleteUsers(IFormCollection objForm)
        {
            var revsponse = JsonConvert.SerializeObject(new { objForm });
            try
            {
                Log.WriteInfoLogWithoutMail(_module, "DeleteUsers()", "INFOLOG ", revsponse);
            }
            catch (Exception ex)
            { }

            try
            {
                Users objEntity = new Users();
                objEntity.ID = !string.IsNullOrWhiteSpace(objForm["ID"]) ? Convert.ToInt64(objForm["ID"].ToString().Trim()) : 0;
                objEntity.PhoneNumber = !string.IsNullOrWhiteSpace(objForm["PhoneNumber"]) ? Convert.ToString(objForm["PhoneNumber"].ToString().Trim()) : "";

                _jsonMessage = new UsersBusinessFacade().IsUserExist(objEntity.PhoneNumber);
                objEntity = (Users)_jsonMessage.Data;

                if (objEntity != null)
                {
                    _jsonMessage = new UsersBusinessFacade().UpdateUser(objEntity.ID, objEntity.PhoneNumber);
                }
                else
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, " Phone number does not exist", KeyEnums.JsonMessageType.FAILURE);
                }
                return Json(_jsonMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}