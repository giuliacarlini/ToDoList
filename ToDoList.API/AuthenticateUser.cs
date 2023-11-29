using System.Security.Claims;

namespace ToDoList.API
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
        public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;

        public IEnumerable<Claim> GetClaimsIdentity() => _accessor.HttpContext.User.Claims;
    }
}
