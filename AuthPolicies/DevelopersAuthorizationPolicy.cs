using Microsoft.AspNetCore.Authorization;

namespace Lee.AADGroupClaims.Policies
{
    public static class DevelopersAuthorizationPolicy
    {
        public static string Name => "Developers";

        public static void Build(AuthorizationPolicyBuilder builder) => 
            builder.RequireClaim("groups", "1cd7ecd6-a081-418b-8a81-b2eaac7d647e");
    }
}