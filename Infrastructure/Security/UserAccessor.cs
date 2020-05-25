namespace Infrastructure.Security
{
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using System;
    using System.Security.Claims;

    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserName()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

            return userName;
        }
    }
}
