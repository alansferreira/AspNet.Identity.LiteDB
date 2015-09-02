using LiteDB;
using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.LiteDB {
    public class IdentityRole : IRole<string> {

        [BsonId]
        public string Id { get; private set; }

        public string Name { get; set; }

        public IdentityRole() {
            this.Id = ObjectId.NewObjectId().ToString();
        }

        public IdentityRole(string roleName)
            : this() {
            this.Name = roleName;
        }
    }
}
