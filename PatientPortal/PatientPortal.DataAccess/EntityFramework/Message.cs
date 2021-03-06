//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientPortal.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            this.MessageRecipients = new HashSet<MessageRecipient>();
        }
    
        public int Id { get; set; }
        public byte FolderId { get; set; }
        public string Subject { get; set; }
        public System.DateTime Date { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        public bool IsSend { get; set; }
        public bool IsPriority { get; set; }
    
        public virtual MessageFolder MessageFolder { get; set; }
        public virtual MessageContent MessageContent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }
    }
}
