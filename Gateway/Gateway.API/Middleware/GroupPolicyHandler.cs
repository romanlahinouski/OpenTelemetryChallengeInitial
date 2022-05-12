using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gateway.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Gateway.Infrastructure.Configuration
{
    public class GroupPolicyHandler : AuthorizationHandler<GroupPolicyRequirenment>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public GroupPolicyHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupPolicyRequirenment requirement)
        {
            if(IsOverageAccured(context.User))
            {                      
                 var groups = GraphHelper.GetUserGroupsFromSession(httpContextAccessor.HttpContext.Session);

                // Checks if required group exists in Session.
                if (groups?.Count > 0 && groups.Contains(requirement.Group.Id))
                {
                   context.Succeed(requirement);
                }
            }
            else  if (context.User.Claims
            .Any(claim => claim.Type == "groups" && claim.Value == requirement.Group.Id))
                context.Succeed(requirement);{

             context.Succeed(requirement);
      
            }
            
     

            return Task.CompletedTask;
        }


        private bool IsOverageAccured(ClaimsPrincipal identity){
            return identity.Claims.Any(x => x.Type == "hasgroups" || (x.Type == "_claim_names" && x.Value == "{\"groups\":\"src1\"}"));
        }
    }

    public class GroupPolicyRequirenment : IAuthorizationRequirement
    {
       
        public Group Group { get; }

        public GroupPolicyRequirenment(Group group)
        {          
            Group = group;
        }
    }
}