using System.Security.Claims;

namespace Blauhaus.Common.TestHelpers.Hotchocolate.Builders
{
    public class ClaimsPrincipalBuilder
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly ClaimsIdentity _claimsIdentity;

        public ClaimsPrincipalBuilder()
        {
            _claimsPrincipal = new ClaimsPrincipal();
            _claimsIdentity = new ClaimsIdentity();
        }

        public ClaimsPrincipalBuilder With_NameIdentifier(string nameIdentifier)
        {
            _claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
            return this;
        }

        public ClaimsPrincipal Build()
        {
            _claimsPrincipal.AddIdentity(_claimsIdentity);
            return _claimsPrincipal;
        }
    }
}