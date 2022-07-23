using Business.Interface;
using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Identity
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public User(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;
        
        public string UserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string Email => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        public string UserName => _httpContextAccessor.HttpContext.User.Identity.Name;
        public int? IdAgencia
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.FindFirst(nameof(Usuario.IdAgencia));
                return string.IsNullOrEmpty(claim.Value) ? default : int.Parse(claim.Value);
            }
        }
    }
}
