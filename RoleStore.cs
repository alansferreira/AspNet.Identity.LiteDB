using Microsoft.AspNet.Identity;
using LiteDB;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNet.Identity.LiteDB {

    public class RoleStore<TRole> : IRoleStore<TRole>, IRoleStore<TRole, string>, IDisposable where TRole : IdentityRole, new() {
        private readonly LiteCollection<TRole> _Roles;

        public RoleStore(LiteCollection<TRole> roles) {
            this._Roles = roles;
        }

        public virtual void Dispose() {
        }

        public virtual Task CreateAsync(TRole role) {
            return Task.FromResult(this._Roles.Insert(role));
        }

        public virtual Task UpdateAsync(TRole role) {
            return new Task(() => { this._Roles.Update(role.Id, role); });
        }

        public virtual Task DeleteAsync(TRole role) {
            return Task.FromResult(this._Roles.Delete(role.Id));
        }

        public virtual Task<TRole> FindByIdAsync(string roleId) {
            return Task.FromResult(this._Roles.FindById(roleId));
        }

        public virtual Task<TRole> FindByNameAsync(string roleName) {
            return Task.FromResult(this._Roles.FindOne(q=>q.Name==roleName));
        }
    }
}
