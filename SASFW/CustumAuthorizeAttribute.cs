using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SASFW
{
    public class UserEmailRequirement : IAuthorizationRequirement
    {
        protected internal string UserName { get; set; }

        public UserEmailRequirement(string userName)
        {
            UserName = userName;
        }
    }
    public class CustumAuthorizeAttributeByUserEmail : AuthorizationHandler<UserEmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserEmailRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated && context.User.Identity.Name == requirement.UserName)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
