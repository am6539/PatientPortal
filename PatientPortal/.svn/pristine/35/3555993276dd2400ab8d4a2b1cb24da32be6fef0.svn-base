using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PatientPortal.API.Identity.Models
{
    public class PermissionRoleStoreBase
    {
        public DbContext Context { get; private set; }
        public DbSet<PermissionRole> DbEntitySet { get; private set; }


        public IQueryable<PermissionRole> EntitySet
        {
            get
            {
                return this.DbEntitySet;
            }
        }

        public PermissionRoleStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<PermissionRole>();
        }

        public void Create(PermissionRole entity)
        {
            this.DbEntitySet.Add(entity);
        }

        public void Create(List<PermissionRole> entity)
        {
            this.DbEntitySet.AddRange(entity);
        }

        public void Delete(PermissionRole entity)
        {
            this.DbEntitySet.Attach(entity);
            this.DbEntitySet.Remove(entity);
        }

        public void DeleteByRole(List<PermissionRole> data)
        {
            this.DbEntitySet.RemoveRange(data);
        }


        public virtual List<PermissionRole> GetAll()
        {
            return this.DbEntitySet.ToList();
        }

        public virtual Task<List<PermissionRole>> GetAllAsync()
        {
            return this.DbEntitySet.ToListAsync();
        }

        public virtual Task<List<PermissionRole>> GetByIdAsync(string roleId)
        {
            return this.DbEntitySet.Where(x => x.RoleId.Equals(roleId)).ToListAsync();
        }


        public virtual List<PermissionRole> GetById(string roleId)
        {
            return this.DbEntitySet.Where(x => x.RoleId.Equals(roleId)).ToList();
        }


        public virtual void Update(PermissionRole entity)
        {
            if (entity != null)
            {
                this.Context.Entry<PermissionRole>(entity).State = EntityState.Modified;
            }
        }
    }
}