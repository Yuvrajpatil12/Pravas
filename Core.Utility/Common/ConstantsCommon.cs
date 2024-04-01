using Microsoft.Extensions.Configuration;

namespace Core.Utility.Common
{
    public class ConstantsCommon
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

        #region AppSettings

        public static readonly string OnAuthorizationController = GetAppSetting("AppSettings:OnAuthorizationController");
        public static readonly string OnAuthorizationAction = GetAppSetting("AppSettings:OnAuthorizationAction");
        public static readonly string AppName = GetAppSetting("AppSettings:AppName");
        public static readonly string RootPath = GetAppSetting("AppSettings:RootPath");
        public static readonly string PhyPath = GetAppSetting("AppSettings:PhyPath");
        public static readonly string CoreDomain = GetAppSetting("AppSettings:CoreDomain");
        public static readonly string DeepLinkEncodePrefix = GetAppSetting("AppSettings:DeepLinkEncodePrefix");
        public static readonly string shortURL = GetAppSetting("AppSettings:shortURL");
        public static readonly string Cachedate = GetAppSetting("AppSettings:Cachedate");
        public static readonly string DefaultController = GetAppSetting("AppSettings:DefaultController");
        public static readonly string DefaultView = GetAppSetting("AppSettings:DefaultView");

        public static readonly string SuperAdminDefaultController = GetAppSetting("AppSettings:SuperAdminDefaultController");
        public static readonly string SuperAdminDefaultView = GetAppSetting("AppSettings:SuperAdminDefaultView");
        public static readonly string AdminDefaultController = GetAppSetting("AppSettings:AdminDefaultController");
        public static readonly string AdminDefaultView = GetAppSetting("AppSettings:AdminDefaultView");

        #endregion AppSettings

        #region AppMailerSettings

        public static readonly string UseSmtpCredentials = GetAppSetting("AppMailerSettings:UseSmtpCredentials");
        public static readonly string UseDefaultCredentials = GetAppSetting("AppMailerSettings:UseDefaultCredentials");
        public static readonly string SmtpUsername = GetAppSetting("AppMailerSettings:SmtpUsername");
        public static readonly string SmtpPassword = GetAppSetting("AppMailerSettings:SmtpPassword");
        public static readonly string SmtpHost = GetAppSetting("AppMailerSettings:SmtpHost");
        public static readonly string SmtpPort = GetAppSetting("AppMailerSettings:SmtpPort");
        public static readonly string EnableSsl = GetAppSetting("AppMailerSettings:EnableSsl");
        public static readonly string DefaultHost = GetAppSetting("AppMailerSettings:DefaultHost");

        public static readonly string ResetPassword_Subject = GetAppSetting("AppMailerSettings:ResetPassword_Subject");
        public static readonly string WelcomeEmail_Subject = GetAppSetting("AppMailerSettings:WelcomeEmail_Subject");

        #endregion AppMailerSettings

        #region AppMailer

        public static readonly string DefaultmailID = GetAppSetting("AppMailer:DefaultmailID");
        public static readonly string Account_Confirmation = GetAppSetting("AppMailer:Account_Confirmation");
        public static readonly string ReplyToEmail = GetAppSetting("AppMailer:ReplyToEmail");
        public static readonly string CareEmail = GetAppSetting("AppMailer:CareEmail");

        #endregion AppMailer

        #region Logging

        public static readonly string LOG_FOLDER_PATH = GetAppSetting("Logging:LOG_FOLDER_PATH");
        public static readonly string LOG_EMAIL_SENDER = GetAppSetting("Logging:LogMailer:LOG_EMAIL_SENDER");
        public static readonly string LOG_EMAIL_RECEIVER = GetAppSetting("Logging:LogMailer:LOG_EMAIL_RECEIVER");
        public static readonly string LOG_EMAIL_SUBJECT = GetAppSetting("Logging:LogMailer:LOG_EMAIL_SUBJECT");
        public static readonly string LOG_EMAIL_IS_SEND = GetAppSetting("Logging:LogMailer:LOG_EMAIL_IS_SEND");
        public static readonly string LOG_EMAIL_CC = GetAppSetting("Logging:LogMailer:LOG_EMAIL_CC");
        public static readonly string LOG_EMAIL_BCC = GetAppSetting("Logging:LogMailer:LOG_EMAIL_BCC");
        public static readonly string ErrorLogEmailSubject = GetAppSetting("Logging:LogMailer:ErrorLogEmailSubject");

        #endregion Logging

        #region AppEncryption

        public static readonly string AESUserEncrryptKey = GetAppSetting("AppEncryption:AESUserEncrryptKey");
        public static readonly string AESUserVector = GetAppSetting("AppEncryption:AESUserVector");
        public static readonly string AESUserSalt = GetAppSetting("AppEncryption:AESUserSalt");

        #endregion AppEncryption

        #region AppMessenger

        public static readonly string MSG91Key = GetAppSetting("AppMessenger:MSG91Key");
        public static readonly string MSG91SenderId = GetAppSetting("AppMessenger:MSG91SenderId");
        public static readonly string MSG91Route = GetAppSetting("AppMessenger:MSG91Route");
        public static readonly string MSG91APIUrl = GetAppSetting("AppMessenger:MSG91APIUrl");

        #endregion AppMessenger

        #region JWTSettings

        public static readonly string JWT_expires = GetAppSetting("JWTSettings:expires");
        public static readonly string JWT_issuer = GetAppSetting("JWTSettings:issuer");
        public static readonly string JWT_audience = GetAppSetting("JWTSettings:audience");
        public static readonly string JWT_secret = GetAppSetting("JWTSettings:secret");

        #endregion JWTSettings

        #region FirebaseSettings

        public static readonly string FirebaseServerKey = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string FirebaseOrganizationId = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasecontent_available = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasepriority = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasesound = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasebadge = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string FIRESTORE_KEY = GetAppSetting("FirebaseSettings:FIRESTORE_KEY");
        public static readonly string FIRESTORE_Project_ID = GetAppSetting("FirebaseSettings:FIRESTORE_Project_ID");

        #endregion FirebaseSettings

        #region Notifications

        public static readonly string NotificationAppName = GetAppSetting("PushNotification:AppName");
        public static readonly string ClassInsta_SubTitle = GetAppSetting("PushNotification:ClassInsta_SubTitle");
        public static readonly string ClassInsta_OpeartionalURL = GetAppSetting("PushNotification:ClassInsta_OpeartionalURL");

        public static readonly string Assignment_SubTitle = GetAppSetting("PushNotification:Assignment_SubTitle");
        public static readonly string Assignment_OpeartionalURL = GetAppSetting("PushNotification:Assignment_OpeartionalURL");

        public static readonly string Evaluation_SubTitle = GetAppSetting("PushNotification:Evaluation_SubTitle");
        public static readonly string Evaluation_OpeartionalURL = GetAppSetting("PushNotification:Evaluation_OpeartionalURL");

        public static readonly string Portfolio_SubTitle = GetAppSetting("PushNotification:Portfolio_SubTitle");
        public static readonly string Portfolio_OpeartionalURL = GetAppSetting("PushNotification:Portfolio_OpeartionalURL");

        public static readonly string Worksheet_SubTitle = GetAppSetting("PushNotification:Worksheet_SubTitle");
        public static readonly string Worksheet_OpeartionalURL = GetAppSetting("PushNotification:Worksheet_OpeartionalURL");

        public static readonly string DocumentPermission_SubTitle = GetAppSetting("PushNotification:DocumentPermission_SubTitle");
        public static readonly string DocumentPermission_OpeartionalURL = GetAppSetting("PushNotification:DocumentPermission_OpeartionalURL");

        #endregion Notifications

        #region Reports

        public static readonly string EvaluationReportsPath = GetAppSetting("Reports:Evaluation");
        public static readonly string PortfolioReportsPath = GetAppSetting("Reports:Portfolio");
        public static readonly string AttendanceReportsPath = GetAppSetting("Reports:Attendance");
        public static readonly string InvoiceReportsPath = GetAppSetting("Reports:Invoice");
        public static readonly string PaymentReceiptPath = GetAppSetting("Reports:Receipt");
        public static readonly string DepositPath = GetAppSetting("Reports:Deposit");

        #endregion Reports

        public static readonly string CoreDomainSiteRUL = URLDetails.GetSiteRootUrl().TrimEnd('/');

        public static readonly int SQLCommandTimeOut = GetAppSetting("ConnectionStrings:SQLCommandTimeOut") != "" ? Convert.ToInt32(GetAppSetting("SQLCommandTimeOut")) : 0;

        public static readonly string ContentNoLogoPathVir = "/Content/images/no-logo.jpg";
    }
}