using   Core.Entity;
using Core.Entity.Enums;
using Core.Entity.ViewModel;
using Core.Utility;
using Core.Utility.Common;
using Newtonsoft.Json;

namespace Yatra.Models
{
    public class Helper
    {
        private readonly string _module = "Adhilabhansah.Models.Helper";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private bool _IsRegisterProcess = false;

        public bool IsRegisterProcess
        {
            get { return _IsRegisterProcess; }
            set { _IsRegisterProcess = value; }
        }

        public void KillSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public LoginVM GetSession()
        {
            LoginVM loginVM = new LoginVM();

            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()) != null)
                {
                    loginVM = JsonConvert.DeserializeObject<LoginVM>(_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }


        public LoginVM UpdateSession(LoginVM _LoginVM)
        {
            LoginVM loginVM = new LoginVM();
            try
            {
                _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(loginVM));
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }

        public void SetUserLanguage(long LanguageId)
        {
            _session.SetString(KeyEnums.SessionKeys.LanguageId.ToString(), LanguageId.ToString());
        }

        public void SetSession(Users user)
        {
            try
            {
                if (user != null)
                {
                    //  LoginVM loginVM = new LoginVM();
                    //  loginVM.SessionId = _session.Id;

                    //  loginVM.Id = user.ID;
                    //  loginVM.UserName = user.UserName;
                    //  loginVM.Password = user.Password;

                    //  loginVM.RoleId = (byte)user.RoleId;
                    // // loginVM.UserRole = (int)user.RoleID;
                    //  loginVM.ParentId = user.ParentId;

                    //  loginVM.IsVerified = user.IsVerified;
                    //  loginVM.VerficationCode = user.VerficationCode;
                    //  loginVM.VerficationDate = user.VerficationDate;
                    //  loginVM.StatusId = user.StatusId;
                    //  loginVM.CreatedDate = user.CreatedDate;
                    //  //loginVM.LogoName = user.LogoName;
                    ////  loginVM.LanguageId = user.LanguageId;

                    //  if (IsRegisterProcess)
                    //  {
                    //      loginVM.IsFirstTimeLogin = true;
                    //  }

                    LoginVM loginVM = new LoginVM();
                    loginVM.SessionId = _session.Id;

                    loginVM.Id = user.ID;
                    loginVM.UserName = user.UserName;
                    loginVM.Password = user.Password;
                    loginVM.FirstName = user.FullName;
                    loginVM.RoleId = (byte)user.RoleId;
                    //loginVM.UserRole = (int)user.RoleID;
                    loginVM.ParentId = user.ParentId;

                    loginVM.IsEmailVerified = user.IsVerified;
                    loginVM.EmailVerficationCode = user.VerficationCode;

                    loginVM.StatusId = user.StatusId;
                    loginVM.CreatedDate = user.CreatedDate;
                    //loginVM.LogoName = user.LogoName;

                    if(!string.IsNullOrEmpty(user.AlternateEmail))
                    {
                        loginVM.AlternateEmail = user.AlternateEmail;
                    }

                    if (IsRegisterProcess)
                    {
                        loginVM.IsFirstTimeLogin = true;
                    }

                    //if (!string.IsNullOrWhiteSpace(user.Profile_Logo))
                    //    loginVM.Profile_Logo = SandeshakamConstants.RegistrationVir + user.Profile_Logo;
                    //else
                    //    loginVM.Profile_Logo = SandeshakamConstants.ContentNoLogoPathVir;

                    if (!string.IsNullOrWhiteSpace(loginVM.FirstName))
                        loginVM.Initial = StringFilter.GetInitialChar(loginVM.FirstName);

                    if ((!string.IsNullOrWhiteSpace(loginVM.FirstName)) && (!string.IsNullOrWhiteSpace(loginVM.LastName)))
                        loginVM.InitialChars = StringFilter.GetInitials(loginVM.FirstName);

                    loginVM.ParentId = user.ParentId;

                    CommonData _CommonData = new CommonData();
                    //loginVM.ProfileLanguage = _CommonData.LanguageNameFromId(loginVM.LanguageId.ToString());
                    //loginVM.SelectedLanguage = _CommonData.LanguageNameFromId(loginVM.LanguageId.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserId.ToString(), loginVM.Id.ToString());
                   // _session.SetString(KeyEnums.SessionKeys.FirstName.ToString(), loginVM.FirstName.ToString());

                  //  _session.SetString(KeyEnums.SessionKeys.AlternateEmailID.ToString(), loginVM.AlternateEmail.ToString());

                    _session.SetString(KeyEnums.SessionKeys.UserRole.ToString(), loginVM.RoleId.ToString());

                    if (!string.IsNullOrWhiteSpace(loginVM.UserName))
                        _session.SetString(KeyEnums.SessionKeys.UserEmailID.ToString(), loginVM.UserName.ToString());
                 //   _session.SetString(KeyEnums.SessionKeys.UserLogo.ToString(), loginVM.Profile_Logo.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(loginVM));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "SetSession(User user)", ex.Source, ex.Message, ex);
            }
        }

        public bool IsValidUser(Int64 UserID, string RoleIDs)
        {
            bool isAllowed = false;
            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) == null)
                    isAllowed = false;
                else if (RoleIDs.ToLower().Contains(_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()).ToString().ToLower()))
                    isAllowed = true;

                if (!isAllowed)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/Users/Login", true);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsValidUser(UserID:" + UserID + ",RoleIDs:" + RoleIDs + ")", ex.Source, ex.Message, ex);
            }
            return isAllowed;
        }
    }
}
