using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace OcelotAPIGateway.Authentication
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;

            if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "resource_access"))
            {
                var userRole = claimsIdentity.FindFirst((claim) => claim.Type == "resource_access");

                var content = Newtonsoft.Json.Linq.JObject.Parse(userRole.Value);

                foreach (var role in content["MyApp"]["roles"])
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                }
            }

            return Task.FromResult(principal);
        }
    }
}
