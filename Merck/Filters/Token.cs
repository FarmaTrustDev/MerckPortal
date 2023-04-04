using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Filters
{
    public class Token
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Token(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetAccessTokenAsync()
        {
            string accessToken = null;
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                // First, check the Authorization header
                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
                {
                    accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    // If the access token is not in the Authorization header, try to read it from a cookie
                    accessToken = context.Request.Cookies["jwt"];
                }
            }
            return accessToken;
        }
    }
}
