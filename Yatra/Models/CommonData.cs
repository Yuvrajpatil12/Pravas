//using Adhilabhansah.Utility.Common;
using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Enums;
using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Yatra.Models
{
    public class CommonData
    {
        private readonly string _module = "Core.Models.CommonData";
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Int64 _userId = 0;

        public CommonData(IHttpContextAccessor httpContextAccessor = null)
        {
            //_userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SelectListItem> LanguageList(long SelectedLang = 0)
        {
            List<SelectListItem> _LanguageList = new List<SelectListItem>();
            LanguageMasterBusinessFacade _LanguageMasterBusinessFacade = new LanguageMasterBusinessFacade();
            try
            {
                List<LanguageMaster> _List = _LanguageMasterBusinessFacade.GetAllRecordsList();

                for (int i = 0; i < _List.Count; i++)
                {
                    SelectListItem _SelectListItem = new SelectListItem();
                    _SelectListItem.Text = _List[i].Language;
                    _SelectListItem.Value = Convert.ToString(_List[i].Id);
                    if (_List[i].Id == SelectedLang && SelectedLang > 0)
                    {
                        _SelectListItem.Selected = true;
                    }
                    _LanguageList.Add(_SelectListItem);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "LanguageList()", ex.Source, ex.Message, ex);
            }
            return _LanguageList;
        }

        public string LanguageNameFromId(string SelectedLang)
        {
            string LanguageName = "";
            try
            {
                List<SelectListItem> ListSelectListItem = LanguageList();

                if (ListSelectListItem.FindAll(X => X.Value == SelectedLang).Count > 0)
                {
                    LanguageName = ListSelectListItem.FindAll(X => X.Value == SelectedLang)[0].Text;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "LanguageNameFromId(SelectedLang:" + SelectedLang + ")", ex.Source, ex.Message, ex);
            }

            return LanguageName.ToLower();

        }


        public List<SelectListItem> GetPageSizes()
        {
            List<SelectListItem> pageSizes = new List<SelectListItem>();
            try
            {
                pageSizes = new List<SelectListItem>
                {
                    //new SelectListItem { Text = "5", Value = "5"} ,
                    new SelectListItem { Text = "10", Value = "10"} ,
                    new SelectListItem { Text = "25", Value = "25"} ,
                    new SelectListItem { Text = "50", Value = "50" },
                    new SelectListItem { Text = "100", Value = "100" }
                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPageSizes()", ex.Source, ex.Message, ex);
            }
            return pageSizes;
        }

        public List<SelectListItem> GetAges()
        {
            List<SelectListItem> ages = new List<SelectListItem>();
            try
            {
                ages = new List<SelectListItem>
                {
                    new SelectListItem { Text = "bis 18", Value = "bis 18"},
                    new SelectListItem { Text = "19 - 25", Value = "19 - 25"},
                    new SelectListItem { Text = "26 - 30", Value = "26 - 30" },
                    new SelectListItem { Text = "31 - 35", Value = "31 - 35" },
                    new SelectListItem { Text = "36 - 40", Value = "36 - 40" },
                    new SelectListItem { Text = "41 - 50", Value = "41 - 50" },
                    new SelectListItem { Text = "51 - 60", Value = "51 - 60" },
                    new SelectListItem { Text = "61 - 70", Value = "61 - 70" },
                    new SelectListItem { Text = "über 70", Value = "über 70" },


                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAges()", ex.Source, ex.Message, ex);
            }
            return ages;
        }


    }
}
