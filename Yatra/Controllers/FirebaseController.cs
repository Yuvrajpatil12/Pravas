using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Yatra.Utility.Common;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Shiksha.Controllers
{
    public class FirebaseController : Controller
    {
        //  private IHostingEnvironment _hostingEnvironment;
        private readonly string _module = "Yatra.Controllers.FirebaseController";

        private IHostingEnvironment _hostingEnvironment;

        public FirebaseController(IHostingEnvironment environment = null)
        {
            _hostingEnvironment = environment;
        }

        public async Task<int> SendFirebaseNotification(List<string> fcms, string VerificationCode, string notificationType = "", Int64 id = 0, string pickup = "", string drop = "")
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");

                string tempPath = null;
                string NotificationTemplate = null;

                if (notificationType == "DRIVER")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationDrivers.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[PICKUP]", pickup).Replace("[DROP]", drop).Replace("[id]", id.ToString());//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "PASSENGER")
                {
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationPassenger.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "DRIVERACTIVE")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationDriverActive.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "DRIVERINACTIVE")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationDriverInactive.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "RIDECOMPLETEDBYDRIVER")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationRideCompleted.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "RIDECOMPLETEDBYUSER")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationRideCompleted.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "RIDESTARTED")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationRideStarted.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode).Replace("[ID]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "DRIVERCANCELBOOKING")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationDriverCancelBooking.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }
                if (notificationType == "PASSENGERCANCELBOOKING")
                {
                    //string tempPath = _hostingEnvironment.WebRootPath + "\\Templates\\" + _CommonData.LanguageNameFromId(Convert.ToString(objUserEntity.LanguageId)) + "\\" + "PasswordReset.html";
                    tempPath = YatraConstants.PhyPath + "\\Templates\\EN\\" + "PushNotificationPassengerCancelBooking.json";
                    NotificationTemplate = CommonUtilities.CommonHelper.LoadHTML(tempPath);

                    NotificationTemplate = NotificationTemplate.Replace("[CODE]", VerificationCode);//.Replace("[URL]", OpeartionalURL);
                }

                var json_NotificationTemplate = JObject.Parse(NotificationTemplate);

                request.Headers.Add("Authorization", "Bearer " + ConstantsCommon.FirebaseServerKey);

                var joinedTokens = "\"" + string.Join("\", \"", fcms) + "\"";

                request.Content = new StringContent("{" +
                    "\"registration_ids\": [" + joinedTokens + "]," +
                    "\"notification\": {" +
                        "\"body\": \"" + json_NotificationTemplate["body"] + "\"," +
                        "\"OrganizationId\": \"" + ConstantsCommon.FirebaseOrganizationId + "\"," +
                        "\"content_available\": true," +
                        "\"priority\": \"high\"," +
                        "\"title\": \"" + json_NotificationTemplate["title"] + "\"," +
                        "\"sound\": \"default\"," +
                        "\"badge\": \"1\"," +
                        "\"image\": \"" + json_NotificationTemplate["image"] + "\"" +
                    "},                " +
                    "\"data\": {" +
                        "\"subtitle\": \"" + json_NotificationTemplate["subtitle"] + "\"," +
                        "\"subHeading\": \"" + json_NotificationTemplate["subheading"] + "\"," +
                        "\"priority\": \"high\"," +
                        "\"sound\": \"default\"," +
                        "\"content_available\": true," +
                        "\"url\": \"" + json_NotificationTemplate["url"] + "\"" +
                    "}" +
                "}");

                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var jsonString = JObject.Parse(responseBody);

                int fail_count = int.Parse(jsonString["failure"].ToString());
                return fail_count;
            }
            catch (Exception ex)
            {
                var joinedTokens = "\"" + string.Join("\", \"", fcms) + "\"";

                Log.WriteLog(_module, "SendFirebaseNotification(FCMs:" + joinedTokens + ")", ex.Source, ex.Message, ex);
            }

            return 0;
        }
    }
}