using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;
using Yatra.Resources;
using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Yatra.Controllers;

namespace Yatra.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMemoryCache _cache;

        // private readonly Helper _helper;
        private readonly string _role;

        private readonly string _module = "Core.Controllers.App.TokenController";

        private JsonString jsonString = null;

        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public TokenController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment environment = null, IMemoryCache cache = null)
        {
            _hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
            //  _helper = new Helper(_httpContextAccessor);
        }

        [HttpGet]
        public string gettoken(string apiKey)
        {
            string strErrorMessage = "Invalid Key";
            string strErrorCode = "";

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, apiKey),
            };

            Users objEntity = new Users();
            
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConstantsCommon.JWT_secret));
            _ = int.TryParse(ConstantsCommon.JWT_expires, out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: ConstantsCommon.JWT_issuer,
                audience: ConstantsCommon.JWT_audience,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}