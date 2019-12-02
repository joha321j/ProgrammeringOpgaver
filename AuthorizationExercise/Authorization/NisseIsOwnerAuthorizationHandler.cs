using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using AuthorizationExercise.Data;
using AuthorizationExercise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationExercise.Authorization
{
    public class NisseIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Nisse>
    {
        private UserManager<IdentityUser> _userManager;

        public NisseIsOwnerAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Nisse resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (!string.Equals(requirement.Name, NisseConstants.CreateOperationName) &&
                !string.Equals(requirement.Name, NisseConstants.ReadOperationName) &&
                !string.Equals(requirement.Name, NisseConstants.UpdateOperationName) &&
                !string.Equals(requirement.Name, NisseConstants.DeleteOperationName))
            {
                return Task.CompletedTask;
            }

            if (resource.OwnerID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
