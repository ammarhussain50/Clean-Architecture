using Application.Interfaces;
using System.Security.Claims;

namespace clean_webapi.SharedServices
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public AuthenticatedUser(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue("uid");
        }

        public string UserId { get; set; }
    }
}
