//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Http;
//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

//namespace Core.Utility.Common
//{
//    public class GetJWTUserAuthentication
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly IHostingEnvironment _hostingEnvironment;

//        // private readonly Helper _helper;
//        private readonly string _role;

//        private readonly string _module = "Core.Controllers.App.TokenController";

//        private ISession _session => _httpContextAccessor.HttpContext.Session;

//        public GetJWTUserAuthentication(IHttpContextAccessor httpContextAccessor, IHostingEnvironment environment = null)
//        {
//            _hostingEnvironment = environment;
//            _httpContextAccessor = httpContextAccessor;

//            //  _helper = new Helper(_httpContextAccessor);
//        }

//        private string GetJWTUserAuthenticationHeaderValue()
//        {
//            string nameValue = null;

//            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeaderValue))
//            {
//                // Authorization header value is available

//                var authorizationHeaderValue = authHeaderValue.ToString();
//                if (authorizationHeaderValue.StartsWith("Bearer "))
//                {
//                    authorizationHeaderValue = authorizationHeaderValue.Substring("Bearer ".Length);
//                }
//                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//                JwtSecurityToken parsedToken = tokenHandler.ReadJwtToken(authorizationHeaderValue);

//                // Print out all claims
//                Console.WriteLine("Claims in the JWT token:");
//                foreach (var claim in parsedToken.Claims)
//                {
//                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
//                }

//                // Example: Retrieving a specific claim by type
//                Claim nameClaim = parsedToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");

//                if (nameClaim != null)
//                {
//                    nameValue = nameClaim.Value;
//                    Console.WriteLine($"Name: {nameValue}");
//                }
//            }

//            return nameValue;
//        }
//    }
//}