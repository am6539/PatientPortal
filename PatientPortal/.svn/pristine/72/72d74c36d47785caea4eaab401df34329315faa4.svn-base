using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.EntityFramework;

namespace PatientPortal.DataAccess.DbContext
{
    interface IHospitalCoreContext : IDisposable
    {
        IDbSet<Appointment> Appointment { get; set; }
        IDbSet<Article> Article { get; set; }
        IDbSet<ArticleComment> ArticleComment { get; set; }
        IDbSet<Group> Group { get; set; }
        IDbSet<MailSetting> MailSetting { get; set; }
        IDbSet<Message> Message { get; set; }
        IDbSet<MessageContent> MessageContent { get; set; }
        IDbSet<MessageFolder> MessageFolder { get; set; }
        IDbSet<MessageRecipient> MessageRecipient { get; set; }
        IDbSet<Module> Module { get; set; }
        IDbSet<OfferAdvise> OfferAdvise { get; set; }
        IDbSet<Organization> Organization { get; set; }
        IDbSet<Permission> Permission { get; set; }
        IDbSet<Role> Role { get; set; }
        IDbSet<Setting> Setting { get; set; }
        IDbSet<User> User { get; set; }
        IDbSet<UserGroup> UserGroup { get; set; }
        IDbSet<UserRole> UserRole { get; set; }
    }
}
