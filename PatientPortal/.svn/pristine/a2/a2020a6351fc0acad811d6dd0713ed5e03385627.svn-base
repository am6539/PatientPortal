using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PatientPortal.API.Identity.Models
{
    public class PermissionRoleManager
    {
        private readonly PermissionRoleStore _permissionRoleStore;
        private readonly ApplicationDbContext _db;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public PermissionRoleManager()
        {
            _db = HttpContext.Current
                .GetOwinContext().Get<ApplicationDbContext>();
            _userManager = HttpContext.Current
                .GetOwinContext().GetUserManager<ApplicationUserManager>();
            _roleManager = HttpContext.Current
                .GetOwinContext().Get<ApplicationRoleManager>();
            _permissionRoleStore = new PermissionRoleStore(_db);
        }

        public IQueryable<PermissionRole> PermissionRoles
        {
            get
            {
                return _permissionRoleStore.PermissionRoles;
            }
        }

        /// <summary>
        /// Create new Permission Role Async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreatePermissionRoleAsync(PermissionRole obj)
        {
            await _permissionRoleStore.CreateAsync(obj);
            return IdentityResult.Success;
        }


        /// <summary>
        /// Create new Permission Role
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IdentityResult CreatePermissionRole(PermissionRole obj)
        {
            _permissionRoleStore.Create(obj);
            return IdentityResult.Success;
        }

        public List<PermissionRole> GetAll()
        {
            return _permissionRoleStore.GetAll();
        }

        public async Task<List<PermissionRole>> GetAllAsync()
        {
            return await _permissionRoleStore.GetAllAsync();
        }

        public async Task<List<PermissionRole>> FindByIdAsync(string id)
        {
            return await _permissionRoleStore.FindByIdAsync(id);
        }

        /// <summary>
        /// Find by Permission Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<PermissionRole> FindById(string roleId)
        {
            return _permissionRoleStore.FindById(roleId);
        }
        
        /// <summary>
        /// Delete Permission Async
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IdentityResult> DeletePermissionRoleAsync(string roleId)
        {
            var ret = await this._permissionRoleStore.DeleteByRoleAsync(roleId);
            return ret ? IdentityResult.Success : IdentityResult.Failed("Lỗi không xóa được chi tiết quyền.");
        }

        /// <summary>
        /// Delete Permission
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IdentityResult DeletePermissionRole(string roleId)
        {
            var ret =  this._permissionRoleStore.DeleteByRole(roleId);
            return ret ? IdentityResult.Success : IdentityResult.Failed("Lỗi không xóa được chi tiết quyền.");
        }

        public async Task<IdentityResult> InsertPermissionRoleAsync(List<PermissionRole> permissionRoles)
        {
            var ret = await this._permissionRoleStore.CreateAsync(permissionRoles);
            return ret ? IdentityResult.Success : IdentityResult.Failed("Lỗi không xóa được chi tiết quyền.");
        }

        /// <summary>
        /// Check Exist Permission
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool IsExistInRoles(string roleId)
        {
            var ret = (from p in this.PermissionRoles where p.RoleId.Equals(roleId) select p.RoleId).Any();
            return ret;
        }

    }
}