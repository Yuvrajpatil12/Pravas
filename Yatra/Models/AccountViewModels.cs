using Core.Entity;

namespace Yatra.Models
{
    public class AccountViewModels
    {
        public class APILogin
        {
            //public string username { get; set; }
            //public string password { get; set; }
            public string PhoneNumber { get; set; }
            public string DeviceID { get; set; }
            //public string LoginFromType { get; set; }
            //public Int64 GuestUserID { get; set; }
            public AccessMember? AccessMember { get; set; }
        }

        public class VerifyModel
        {
            public string? PhoneNumber { get; set; }
            public string? DeviceID { get; set; }
            public string? OTP { get; set; }
            public string? FCMToken { get; set; }


        }
    }
}
