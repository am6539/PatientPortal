using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;

namespace PatientPortal.API.Identity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string PatientId { get; set; }
        public DateTime? DoB { get; set; }
        public byte Gender { get; set; }
        public byte[] Image { get; set; }
        public int OrganizationId { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsAdmin { get; set; }
        public string Tags { get; set; }
        public string Address { get; set; }
        public string PersonalId { get; set; }
        public string InsuranceId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Hospital.Identity", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        // Add the PermissionRole property:
        public virtual IDbSet<Permission> Permissions { get; set; }
        public virtual IDbSet<PermissionRole> PermissionRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            //modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<Permission>();

            modelBuilder.Entity<PermissionRole>()
                .HasKey(p => new
                {
                    PermissionId = p.PermissionId,
                    RoleId = p.RoleId
                })
                .HasRequired(p => p.Permission).WithMany(d => d.PermissionRoles)
                .HasForeignKey(p => p.PermissionId)
                .WillCascadeOnDelete(false);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}