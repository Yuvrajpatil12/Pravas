

using Microsoft.Extensions.Configuration;

namespace Yatra.Utility.Common
{
    public class YatraConstants
    {
        private static IConfiguration Configuration;
        public static string GetAppSetting(string appSettingKey)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();

            string[] SplittedKey = appSettingKey.Split(":");

            string PureKey = SplittedKey[(SplittedKey.Length) - 1];

            bool a = Configuration.GetChildren().Any(item => item.Key == appSettingKey);
            string appSettingValue = Configuration.GetValue<string>(appSettingKey);

            return appSettingValue;
        }
        //Recording Paths:
        public static readonly string RootPath = GetAppSetting("AppSettings:RootPath");
        public static readonly string PhyPath = GetAppSetting("AppSettings:PhyPath");
        public static readonly string AudioPath = GetAppSetting("AppSettings:AudioPath");
        public static readonly string VideoPath = GetAppSetting("AppSettings:VideoPath");
        public static readonly string CallBackURI = GetAppSetting("AppSettings:CallBackURI");
        public static readonly string CRMBaseAddress = GetAppSetting("AppSettings:CRMBaseAddress");

        /// <summary>
        /// /
        /// </summary>
        public static readonly string AdhilabhansahQRDomain = GetAppSetting("AppSettings:AdhilabhansahQRDomain");

        //SMTP details
        public static readonly string LOG_FOLDER_PATH = GetAppSetting("AppSettings:LOG_FOLDER_PATH");
        public static readonly string LOG_EMAIL_SENDER = GetAppSetting("AppSettings:LOG_EMAIL_SENDER");
        public static readonly string LOG_EMAIL_RECEIVER = GetAppSetting("AppSettings:LOG_EMAIL_RECEIVER");
        public static readonly string LOG_EMAIL_SUBJECT = GetAppSetting("AppSettings:LOG_EMAIL_SUBJECT");
        public static readonly string LOG_EMAIL_IS_SEND = GetAppSetting("AppSettings:LOG_EMAIL_IS_SEND");
        public static readonly string LOG_EMAIL_CC = GetAppSetting("AppSettings:LOG_EMAIL_CC");
        public static readonly string LOG_EMAIL_BCC = GetAppSetting("AppSettings:LOG_EMAIL_BCC");
        public static readonly string CareEmail = GetAppSetting("AppMailer:CareEmail");

        /// <summary>
        /// 
        /// </summary>
        public static readonly string shortURL = GetAppSetting("AppSettings:shortURL");
        public static readonly string Cachedate = GetAppSetting("AppSettings:Cachedate");


        public static readonly string DefaultmailID = GetAppSetting("AppMailer:DefaultmailID");
        public static readonly string MasterCardMailID = GetAppSetting("AppMailer:MasterCardMailID");
        public static readonly string Account_Confirmation = GetAppSetting("AppMailer:Account_Confirmation");
        public static readonly string ReplyToEmail = GetAppSetting("AppMailer:ReplyToEmail");
        public static readonly string MasterReplyToEmail = GetAppSetting("AppMailer:MasterReplyToEmail");
        public static readonly string CCMasterCard = GetAppSetting("AppMailer:CCMasterCard");
        public static readonly string BCCMasterCard = GetAppSetting("AppMailer:BCCMasterCard");
        public static readonly string MasterCardSubject = GetAppSetting("AppMailer:MasterCardSubject");

        // Default Domain controller and View:
        public static readonly string CoreDomain = GetAppSetting("AppSettings:CoreDomain");
        public static readonly string SuperAdminDefaultController = GetAppSetting("AppSettings:SuperAdminDefaultController");
        public static readonly string AdminDefaultController = GetAppSetting("AppSettings:AdminDefaultController");
        public static readonly string SuperAdminDefaultView = GetAppSetting("AppSettings:AdminDefaultView");
        public static readonly string AdminDefaultView = GetAppSetting("AppSettings:AdminDefaultView");

        //Encryption Constants:
        public static readonly string AESUserEncrryptKey = GetAppSetting("AppEncryption:AESUserEncrryptKey");
        public static readonly string AESUserVector = GetAppSetting("AppEncryption:AESUserVector");
        public static readonly string AESUserSalt = GetAppSetting("AppEncryption:AESUserSalt");

        public static readonly int SQLCommandTimeOut = GetAppSetting("AppSettings:SQLCommandTimeOut") != "" ? Convert.ToInt32(GetAppSetting("AppEncryption:SQLCommandTimeOut")) : 0;

        public static readonly string SubcategoryCode = GetAppSetting("AppSettings:SubcategoryCode");
        public static readonly string CaseTypeCode = GetAppSetting("AppSettings:CaseTypeCode");

        public static readonly string AppName = GetAppSetting("AppSettings:AppName");

        public static readonly string ProfilePicture = GetAppSetting("AppSettings:ProfilePicture");
        public static readonly string CompanyLogo = GetAppSetting("AppSettings:CompanyLogo");
        public static readonly string AadharPicture= GetAppSetting("AppSettings:AadharPicture");
        public static readonly string PanCardPicture = GetAppSetting("AppSettings:PanCardPicture");
        public static readonly string CampaignPicture = GetAppSetting("AppSettings:CampaignPicture");
        public static readonly string QRCodePicture = GetAppSetting("AppSettings:QRCodePicture");
        public static readonly string Documents = GetAppSetting("AppSettings:Documents");

        public static readonly string SHORTURL_key_size = GetAppSetting("AppSettings:SHORTURL_key_size");
        public static readonly string WebPQuality = GetAppSetting("AppSettings:WebPQuality");
        public static readonly string ApplicationPath = GetAppSetting("AppSettings:ApplicationPath");

        public static readonly string UseSmtpCredentials = GetAppSetting("AppMailerSettings:UseSmtpCredentials");
        public static readonly string UseDefaultCredentials = GetAppSetting("AppMailerSettings:UseDefaultCredentials");
        public static readonly string SmtpUsername = GetAppSetting("AppMailerSettings:SmtpUsername");
        public static readonly string SmtpPassword = GetAppSetting("AppMailerSettings:SmtpPassword");
        public static readonly string SmtpHost = GetAppSetting("AppMailerSettings:SmtpHost");
        public static readonly string SmtpPort = GetAppSetting("AppMailerSettings:SmtpPort");
        public static readonly string EnableSsl = GetAppSetting("AppMailerSettings:EnableSsl");
        public static readonly string DefaultHost = GetAppSetting("AppMailerSettings:DefaultHost");

        public static readonly string MSG91Key = GetAppSetting("AppMessenger:MSG91Key");
        public static readonly string MSG91SenderId = GetAppSetting("AppMessenger:MSG91SenderId");
        public static readonly string MSG91Route = GetAppSetting("AppMessenger:MSG91Route");
        public static readonly string MSG91APIUrl = GetAppSetting("AppMessenger:MSG91APIUrl");

        public static readonly string LoginCookie = GetAppSetting("AppSettings:LoginCookie");

        public static readonly string QRMaxSize = GetAppSetting("QRCode:QRMaxSize");
        public static readonly string Bulk_Customer_XL_Path = GetAppSetting("AppSettings:Bulk_Customer_XL_Path");
        public static readonly string QRExcelPath = GetAppSetting("AppSettings:QRExcelPath");


    }
}
