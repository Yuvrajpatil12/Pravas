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
    public class AdminController : Controller
    {

        private static string _module = "Yatra.Controllers.AdminController";
        private Int64 _userId = 0;
        private Int64 _schoolId = 0;
        private string _role = "";
        private Int64 _companyid = 0;
        private Int64 _locationid = 0;
        private string _cacheKey = "AdminController_";
        private JsonMessage _jsonMessage = null;
        private int page = 1, size = 10;
        private bool isValidUser = false;
        private IMemoryCache _cache;
        private Helper _helper;

       private List<Users> _list = new List<Users>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;



        public AdminController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor = null, IMemoryCache cache = null)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _helper = new Helper(_httpContextAccessor);
            _userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;
            _role = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "";

            //Log.WriteLog("UserID:" + _userId, "_role:" + _role, "", "");
            isValidUser = _helper.IsValidUser(_userId, RoleEnums.SuperAdmin + "," + RoleEnums.Admin);



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
                    _list = GetList("", "", "asc", ref page, ref size, "sort", startDate, toDate, _userId, true, ViewBag.RequestList);

                   
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "Index", ex.Source, ex.Message, ex);
                }
            }
            return View(_list.ToPagedList(1, 10));
        }


        #region GetList

        public List<Users> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, string startDate = "", string toDate = "", Int64 _userId = 0, bool isLoad = true, string ListType = "", Int64 companyID = 0, Int64 locationId = 0)
        {
          
            try
            {
                //List<Users> _list = new List<Users>();
                dynamic _Dlist = new List<dynamic>();
                UsersBusinessFacade _userBusinessFacade = new UsersBusinessFacade();

                

                _cacheKey = _cacheKey + ListType + _httpContextAccessor.HttpContext.Session.Id;
                if (isLoad || _cache.Get(_cacheKey) == null)
                {
                  
                    Int64 userId = _userId;
                    if (_role.ToLower() == RoleEnums.Admin.ToString().ToLower() || _role.ToLower() == RoleEnums.SuperAdmin.ToString().ToLower())
                        userId = 0;
                    UsersBusinessFacade objBusinessFacade = new UsersBusinessFacade();
                    _list = _userBusinessFacade.getUsersList(userId);
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                    _cache.Set(_cacheKey, _list, cacheEntryOptions);
                }
                else
                {
                    _list = (List<Users>)_cache.Get(_cacheKey);
                    flag = !string.IsNullOrEmpty(flag) ? flag : "";
                }

 

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.UserName.ToLower().Trim().Contains(query.Trim())
                                                    || a.FirstName.ToLower().Trim().Contains(query.Trim())
                                                    || a.LastName.ToLower().Trim().Contains(query.Trim())
                                                    || a.CreatedDate.ToString().ToLower().Trim().Contains(query.Trim())
                                                    ).ToList();

                        if (flag.ToLower() == "search")
                        {
                            page = 1;
                        }
                    }

                    if (flag.ToLower() == "size")
                        page = 1;

                    if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortOrder))
                    {
                        if (flag.ToLower() == "sort")
                            sortOrder = sortOrder.ToLower().Trim() == "asc" ? "desc" : "asc";

                        switch (sortColumn.ToLower().Trim())
                        {
                            case "srno":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.RowNumber).ToList();
                                else
                                    _list = _list.OrderBy(p => p.RowNumber).ToList();
                                break;

                            case "username":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.UserName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.UserName).ToList();
                                break;

                            case "firstname":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.FirstName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.FirstName).ToList();
                                break;

                            case "lastname":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.LastName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.LastName).ToList();
                                break;                       

                            case "createddate":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.CreatedDate).ToList();
                                else
                                    _list = _list.OrderBy(p => p.CreatedDate).ToList();
                                break;

                            default:
                                break;
                        }
                    }

                    ViewBag.SortColumn = sortColumn == null ? "" : sortColumn.ToLower();
                    ViewBag.SortOrder = sortOrder == null ? "" : sortOrder.ToLower();
                    ViewBag.Page = page;
                    ViewBag.Size = size;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetList(query=" + query + "sortColumn=" + sortColumn + "," + "sortOrder=" + sortOrder + "," + "page=" + page + "," + "size=" + size + ", flag=" + flag + ")", ex.Source, ex.Message, ex);
            }

            if (_list == null)
                return _list;
            else
                return _list;
        }

        #endregion GetList

        #region Search

        public ActionResult Search(string query, string sortColumn, string sortOrder, int page, int size, string flag, bool ISLOAD = false, string ListType = "", Int64 CompanyID = 0, Int64 LocationID = 0, string startDate = "", string toDate = "")
        {
            ViewBag.MenuId = KeyEnums.MenuKeys.liViews.ToString();
            if (isValidUser)
            {
                try
                {
                    ViewBag.RequestList = ListType;
                    if (ListType == KeyEnums.ListType.AllViews.ToString())
                    {
                        if (query != "")
                            _list = GetList(query, sortColumn, sortOrder, ref page, ref size, flag, startDate, toDate, _userId, ISLOAD, ListType, CompanyID, LocationID);
                        else
                        {
                            ViewBag.SortColumn = "";
                            ViewBag.SortOrder = "desc";
                            ViewBag.Page = 1;
                            ViewBag.Size = 10;
                        }
                    }
                    else
                        _list = GetList(query, sortColumn, sortOrder, ref page, ref size, flag, startDate, toDate, _userId, ISLOAD, ListType, CompanyID, LocationID);
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "Search(query=" + query + ", sortColumn=" + sortColumn + ", sortOrder=" + sortOrder + ", page=" + page + ", size=" + size + ", flag=" + flag + ", ISLOAD=" + ISLOAD + ",ListType:" + ListType + ")", ex.Source, ex.Message, ex);
                }
            }
            return PartialView("_ListPartial", _list.ToPagedList(page, size));
        }

        #endregion Search

        public IActionResult AddEdit(String id)
        {
            ViewBag.MenuId = KeyEnums.MenuKeys.liAdmin.ToString();
            //List<Users> objSM = new List<Users>();
            Users objUser = new Users();
            if (isValidUser)
            {
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {

                       Int64 userId = Convert.ToInt64(id);
                        UsersBusinessFacade _userBusinessFacade = new UsersBusinessFacade();
                        objUser = _userBusinessFacade.GetUserByIdDetails(userId);                       
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "AddEdit(id=" + id + ")", ex.Source, ex.Message, ex);
                }
            }
            return View(objUser);
        }

        public IActionResult SaveUser(IFormCollection objForm)
        {
            var revsponse = JsonConvert.SerializeObject(new { objForm });
            try
            {
                Log.WriteInfoLogWithoutMail(_module, "SaveUser()", "INFOLOG ", revsponse);
            }
            catch (Exception ex)
            { }

            try
            {
                Users objEntity = new Users();
                RandomStringGenerator randomStringGenerator = new RandomStringGenerator();

                objEntity.ID = !string.IsNullOrWhiteSpace(objForm["ID"]) ? Convert.ToInt64(objForm["ID"].ToString().Trim()) : 0;
                objEntity.UserName = !string.IsNullOrWhiteSpace(objForm["UserName"]) ? Convert.ToString(objForm["UserName"].ToString().Trim()) : "";
                objEntity.AlternateEmail = !string.IsNullOrWhiteSpace(objForm["AlternateEmail"]) ? Convert.ToString(objForm["AlternateEmail"].ToString().Trim()) : "";
                objEntity.FirstName = !string.IsNullOrWhiteSpace(objForm["FirstName"]) ? Convert.ToString(objForm["FirstName"].ToString().Trim()) : "";
                objEntity.LastName = !string.IsNullOrWhiteSpace(objForm["LastName"]) ? Convert.ToString(objForm["LastName"].ToString().Trim()) : "";


                objEntity.RoleId = 3;
                objEntity.ParentId = 2;
                objEntity.LanguageId = 1;
                objEntity.StatusId = 1;



                string OperationMode = null;

                if (objEntity.ID == 0)
                {
                    OperationMode = "I";
                }
                else
                {
                    OperationMode = "U";
                }

                // Save the user details 

                UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();


                if (OperationMode == "I")
                {
                  
                   
                    Int64 resultId = 0;                   
                    resultId = usersBusinessFacade.Save(objEntity);

                    if (resultId > 0)
                    {
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS);
                     

                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_error, KeyEnums.JsonMessageType.FAILURE);
                    }
                }
                else
                {
                    Int64 updateResultId = 0;
                    updateResultId = usersBusinessFacade.Save(objEntity);

                    if (updateResultId > 0)
                    {
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS);
                    }
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_error, KeyEnums.JsonMessageType.FAILURE);
                    }
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
