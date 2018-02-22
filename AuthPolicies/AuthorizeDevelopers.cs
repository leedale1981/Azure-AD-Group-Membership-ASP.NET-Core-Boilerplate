using Lee.AADGroupClaims.Policies;
using Microsoft.AspNetCore.Authorization;

namespace Lee.AADGroupClaims.Authorization
{
    public class AuthorizeDevelopers : AuthorizeAttribute
    {
        public AuthorizeDevelopers() : base(DevelopersAuthorizationPolicy.Name)
        {
        }
    }
}