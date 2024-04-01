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
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Yatra.Controllers
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class TransactionsController : Controller
    {

        private static string _module = "Yatra.Controllers.TransactionsController";
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

       private List<Transactions> _list = new List<Transactions>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;



        public TransactionsController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor = null, IMemoryCache cache = null)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _helper = new Helper(_httpContextAccessor);
            _userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;
            _role = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "";
            isValidUser = _helper.IsValidUser(_userId, RoleEnums.SuperAdmin + "," + RoleEnums.Admin);



            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuId = KeyEnums.MenuKeys.liTransaction.ToString();
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

        public List<Transactions> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, string startDate = "", string toDate = "", Int64 _userId = 0, bool isLoad = true, string ListType = "", Int64 companyID = 0, Int64 locationId = 0)
        {
          
            try
            {
                //List<Transactions> _list = new List<Transactions>();
                dynamic _Dlist = new List<dynamic>();
                TransactionsBusinessFacade _userBusinessFacade = new TransactionsBusinessFacade();

                

                _cacheKey = _cacheKey + ListType + _httpContextAccessor.HttpContext.Session.Id;
                if (isLoad || _cache.Get(_cacheKey) == null)
                {
                  
                    Int64 userId = _userId;
                    if (_role.ToLower() == RoleEnums.Admin.ToString().ToLower() || _role.ToLower() == RoleEnums.SuperAdmin.ToString().ToLower())
                        userId = 0;
                    TransactionsBusinessFacade objBusinessFacade = new TransactionsBusinessFacade();
                    _list = _userBusinessFacade.getUsersList(userId);
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                    _cache.Set(_cacheKey, _list, cacheEntryOptions);
                }
                else
                {
                    _list = (List<Transactions>)_cache.Get(_cacheKey);
                    flag = !string.IsNullOrEmpty(flag) ? flag : "";
                }

 

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.UserName.ToLower().Trim().Contains(query.Trim())
                                                    || a.DriverName.ToLower().Trim().Contains(query.Trim())
                                                    || a.PickupLocation.ToLower().Trim().Contains(query.Trim())
                                                    || a.DropLocation.ToString().ToLower().Trim().Contains(query.Trim())
                                                     || a.JourneyStatusDateTime.ToString().ToLower().Trim().Contains(query.Trim())
                                                       || a.ActionBy.ToString().ToLower().Trim().Contains(query.Trim())
                                                     || a.DropLocation.ToString().ToLower().Trim().Contains(query.Trim())
                                                        || a.JourneyStartDateTime.ToString().ToLower().Trim().Contains(query.Trim())
                                                     || a.JourneyEndDateTime.ToString().ToLower().Trim().Contains(query.Trim())
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
                            case "name":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.UserName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.UserName).ToList();
                                break;
                            case "drivername":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.DriverName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.DriverName).ToList();
                                break;
                            case "pickup":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.PickupLocation).ToList();
                                else
                                    _list = _list.OrderBy(p => p.PickupLocation).ToList();
                                break;
                            case "drop":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.DropLocation).ToList();
                                else
                                    _list = _list.OrderBy(p => p.DropLocation).ToList();
                                break;
                            case "status":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.JourneyStatusDateTime).ToList();
                                else
                                    _list = _list.OrderBy(p => p.JourneyStatusDateTime).ToList();
                                break;
                            case "actionby":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.ActionBy).ToList();
                                else
                                    _list = _list.OrderBy(p => p.ActionBy).ToList();
                                break;
                            case "journeystartdatetime":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.JourneyStartDateTime).ToList();
                                else
                                    _list = _list.OrderBy(p => p.JourneyStartDateTime).ToList();
                                break;
                            case "journeyenddatetime":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.JourneyEndDateTime).ToList();
                                else
                                    _list = _list.OrderBy(p => p.JourneyEndDateTime).ToList();
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
            ViewBag.MenuId = KeyEnums.MenuKeys.liTransaction.ToString();
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



        



      




    }
}
