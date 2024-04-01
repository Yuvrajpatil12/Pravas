//using System.Web.Mvc;

namespace Adhilabhansah.Models
{
    public class CommonModel
    {
        private readonly string _module = "Adhilabhansah.Models.CommonModel";

    }

    public class dynamicallObject
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }

    public class LoginDataObject
    {
        public string txtUserName { get; set; }
    }
}
