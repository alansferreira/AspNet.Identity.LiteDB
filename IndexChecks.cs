using LiteDB;
using System;
using System.Threading;

namespace AspNet.Identity.LiteDB {
    public class IndexChecks {
        public static void EnsureUniqueIndexOnUserName<TUser>(LiteCollection<TUser> users) where TUser : IdentityUser, new() {
            users.EnsureIndex<string>(q => q.UserName, true);
        }

        public static void EnsureUniqueIndexOnRoleName<TRole>(LiteCollection<TRole> roles) where TRole : IdentityRole, new() {
            roles.EnsureIndex<string>(q => q.Name, true);
        }

        public static void EnsureUniqueIndexOnEmail<TUser>(LiteCollection<TUser> users) where TUser : IdentityUser, new() {
            users.EnsureIndex<string>(q => q.Email, true);
        }
    }
}
