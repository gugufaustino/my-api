using Business.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Identity
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public User(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;
        
        public string Id => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string Email => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        public string UserName => _httpContextAccessor.HttpContext.User.Identity.Name;
    }
}
