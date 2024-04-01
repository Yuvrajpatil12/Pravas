using Microsoft.Extensions.Configuration;

namespace Core.Utility.Common
{
    public class CoreConstants
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
        public static readonly string TeacherDefaultController = GetAppSetting("AppSettings:TeacherDefaultController");
        public static readonly string TeacherDefaultView = GetAppSetting("AppSettings:TeacherDefaultView");
        public static readonly string TeacherToClass = GetAppSetting("AppSettings:TeacherToClass");
        public static readonly string StudentToClass = GetAppSetting("AppSettings:StudentToClass");

        public static readonly string SuperAdminDefaultController = GetAppSetting("AppSettings:SuperAdminDefaultController");
        public static readonly string SuperAdminDefaultView = GetAppSetting("AppSettings:SuperAdminDefaultView");
        public static readonly string AdminDefaultController = GetAppSetting("AppSettings:AdminDefaultController");
        public static readonly string AdminDefaultView = GetAppSetting("AppSettings:AdminDefaultView");
        public static readonly string SchoolDefaultController = GetAppSetting("AppSettings:SchoolDefaultController");
        public static readonly string SchoolDefaultView = GetAppSetting("AppSettings:SchoolDefaultView");

        public static readonly string HQAdminDefaultController = GetAppSetting("AppSettings:HQAdminDefaultController");
        public static readonly string HQAdminDefaultView = GetAppSetting("AppSettings:HQAdminDefaultView");

        public static readonly string LoginCookie = GetAppSetting("AppSettings:LoginCookie");
        public static readonly string GeocodingAPIURL = GetAppSetting("AppSettings:GeocodingAPIURL");
        public static readonly string GeocodingAPIKey = GetAppSetting("AppSettings:GeocodingAPIKey");
        public static readonly string ProfilePicture = GetAppSetting("AppSettings:ProfilePicture");

        //
        public static readonly string UploadTeacher = GetAppSetting("AppSettings:UploadTeacher");

        public static readonly string UploadStudent = GetAppSetting("AppSettings:UploadStudent");
        //

        public static readonly string SchoolStamp = GetAppSetting("AppSettings:SchoolStamp");
        public static readonly string SchoolSignature = GetAppSetting("AppSettings:SchoolSignature");
        public static readonly string MealIcon = GetAppSetting("AppSettings:MealIcon");
        public static readonly string ReceiptSignature = GetAppSetting("AppSettings:ReceiptSignature");
        public static readonly string QualificationDoc = GetAppSetting("AppSettings:QualificationDoc");
        public static readonly string Attendance = GetAppSetting("AppSettings:Attendance");
        public static readonly string Event = GetAppSetting("AppSettings:Event");
        public static readonly string SHORTURL_key_size = GetAppSetting("AppSettings:SHORTURL_key_size");
        public static readonly string PictureQuality = GetAppSetting("AppSettings:PictureQuality");
        public static readonly string WebPQuality = GetAppSetting("AppSettings:WebPQuality");
        public static readonly string ApplicationPath = GetAppSetting("AppSettings:ApplicationPath");
        public static readonly string ClassInstaIMGPath = GetAppSetting("AppSettings:ClassInstaIMGPath");
        public static readonly string ClassInstaVIDPath = GetAppSetting("AppSettings:ClassInstaVIDPath");
        public static readonly string SchoolDocumentsPath = GetAppSetting("AppSettings:SchoolDocumentsPath");
        public static readonly string SchoolAttendancePath = GetAppSetting("AppSettings:SchoolAttendancePath");
        public static readonly string LessonPlanPath = GetAppSetting("AppSettings:LessonPlanPath");
        public static readonly string Bulk_Stduent_XL_Path = GetAppSetting("AppSettings:Bulk_Stduent_XL_Path");
        public static readonly string CurriculumPath = GetAppSetting("AppSettings:CurriculumPath");
        public static readonly string MobileAppRoot = GetAppSetting("AppSettings:MobileAppRoot");
        public static readonly string DefaultEmailPrefix = GetAppSetting("AppSettings:DefaultEmailPrefix");
        public static readonly string ToondemyLessonPlanPath = GetAppSetting("AppSettings:ToondemyLessonPlanPath");
        public static readonly string ToondemyCurriculumPath = GetAppSetting("AppSettings:ToondemyCurriculumPath");

        //
        public static readonly string ClassReportPath = GetAppSetting("AppSettings:ClassReportPath");

        public static readonly string TeacherReportPath = GetAppSetting("AppSettings:TeacherReportPath");
        public static readonly string ResultSummaryExportPath = GetAppSetting("AppSettings:ResultSummaryExportPath");

        public static readonly string MixPanelProjectKey = GetAppSetting("AppSettings:MixPanelProjectKey");

        //

        // teacher bluk upload path
        public static readonly string BulkUpload_Teacher_Path = GetAppSetting("AppSettings:BulkUpload_Teacher_Path");

        public static readonly string BulkUpload_Class_Path = GetAppSetting("AppSettings:BulkUpload_Class_Path");
        public static readonly string BulkUpload_Student_Path = GetAppSetting("AppSettings:BulkUpload_Student_Path");

        //Assign Students to Class
        public static readonly string AssignStudentsToClassLimit = GetAppSetting("AppSettings:AssignStudentsLimit");

        public static readonly string AssignTeachersToClassLimit = GetAppSetting("AppSettings:AssignTeachersLimit");

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
        public static readonly string Assessment_Approval_Subject = GetAppSetting("AppMailerSettings:Assessment_Approval_Subject");
        public static readonly string Assessment_Approved_Subject = GetAppSetting("AppMailerSettings:Assessment_Approved_Subject");
        public static readonly string Assessment_Rejection_Subject = GetAppSetting("AppMailerSettings:Assessment_Rejection_Subject");
        public static readonly string Portfolio_Approval = GetAppSetting("AppMailerSettings:Portfolio_Approval");
        public static readonly string Portfolio_Approved = GetAppSetting("AppMailerSettings:Portfolio_Approved");
        public static readonly string Portfolio_Rejection = GetAppSetting("AppMailerSettings:Portfolio_Rejection");
        public static readonly string BulkStudentUpload = GetAppSetting("AppMailerSettings:BulkStudentUpload");

        #endregion AppMailerSettings

        #region AppMailer

        public static readonly string DefaultmailID = GetAppSetting("AppMailer:DefaultmailID");
        public static readonly string Account_Confirmation = GetAppSetting("AppMailer:Account_Confirmation");
        public static readonly string ReplyToEmail = GetAppSetting("AppMailer:ReplyToEmail");
        public static readonly string CareEmail = GetAppSetting("AppMailer:CareEmail");
        public static readonly string EmailForBulkUploadConsole = GetAppSetting("AppMailer:EmailForBulkUploadConsole");

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

        #region CG

        public static readonly string CGAPIKey = GetAppSetting("CG:CGAPIKey");
        public static readonly string CGRegisterParent = GetAppSetting("CG:CGRegisterParent");
        public static readonly string CGRegisterKid = GetAppSetting("CG:CGRegisterKid");
        public static readonly string CGAddAssignment = GetAppSetting("CG:CGAddAssignment");
        public static readonly string CGUrl = GetAppSetting("CG:CGUrl");
        public static readonly string CGAddAssg_ShortUrl = GetAppSetting("CG:CGAddAssg_ShortUrl");
        public static readonly string CGApiToken = GetAppSetting("CG:CGApiToken");

        #endregion CG

        #region JWTSettings

        public static readonly string JWT_expires = GetAppSetting("JWTSettings:expires");
        public static readonly string JWT_issuer = GetAppSetting("JWTSettings:issuer");
        public static readonly string JWT_audience = GetAppSetting("JWTSettings:audience");

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

        //Paths
        public static readonly string UploadFetchVir = @"/ALLContent/User/[UserID]/UploadFetch/";

        public static readonly string UploadFetchPhy = @"\ALLContent\User\[UserID]\UploadFetch\";
        public static readonly string UploadFetchTemplateVir = @"/Templates/Excel/UploadFetch.xls";
        public static readonly string UploadFetchTemplatePhy = @"\Templates\Excel\TD-Academy-Student-Details-Upload-Template.xlsx";

        public static readonly string UploadFetchTempVir = @"/ALLContent/Temp/";
        public static readonly string UploadFetchTempPhy = @"\ALLContent\Temp\";

        public static readonly string ContentNoLogoPathVir = "/Content/images/no-logo.jpg";
    }
}