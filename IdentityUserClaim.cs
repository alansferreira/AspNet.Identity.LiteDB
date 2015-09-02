using System;
using System.Security.Claims;

namespace AspNet.Identity.LiteDB {
    public class IdentityUserClaim {
        public string Type { get; set; }

        public string Value { get; set; }

        public IdentityUserClaim() { }

        public IdentityUserClaim(Claim claim) {
            this.Type = claim.Type;
            this.Value = claim.Value;
        }

        public Claim ToSecurityClaim() {
            return new Claim(this.Type, this.Value);
        }
    }
}
