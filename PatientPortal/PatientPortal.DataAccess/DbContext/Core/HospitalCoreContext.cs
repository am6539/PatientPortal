using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.EntityFramework;

namespace PatientPortal.DataAccess.DbContext
{
    public partial class HospitalCoreContext : Core_BaseContext<HospitalCoreContext>, IHospitalCoreContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual IDbSet<Appointment> Appointment { get; set; }
        public virtual IDbSet<Article> Article { get; set; }
        public virtual IDbSet<ArticleComment> ArticleComment { get; set; }
        public virtual IDbSet<Group> Group { get; set; }
        public virtual IDbSet<MailSetting> MailSetting { get; set; }
        public virtual IDbSet<Message> Message { get; set; }
        public virtual IDbSet<MessageContent> MessageContent { get; set; }
        public virtual IDbSet<MessageFolder> MessageFolder { get; set; }
        public virtual IDbSet<MessageRecipient> MessageRecipient { get; set; }
        public virtual IDbSet<Module> Module { get; set; }
        public virtual IDbSet<OfferAdvise> OfferAdvise { get; set; }
        public virtual IDbSet<Organization> Organization { get; set; }
        public virtual IDbSet<Permission> Permission { get; set; }
        public virtual IDbSet<Role> Role { get; set; }
        public virtual IDbSet<Setting> Setting { get; set; }
        public virtual IDbSet<User> User { get; set; }
        public virtual IDbSet<UserGroup> UserGroup { get; set; }
        public virtual IDbSet<UserRole> UserRole { get; set; }
    }
}
