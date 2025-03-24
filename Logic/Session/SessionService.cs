using Helpers;
using Logic.Tools;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public long GetUserId()
        {
            var token = httpContextAccessor?.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
                throw new NotAuthorizedException("no access token");

            var user = JwtService.GetPrincipalFromExpiredToken(token);

            return user;
        }
    }
}
