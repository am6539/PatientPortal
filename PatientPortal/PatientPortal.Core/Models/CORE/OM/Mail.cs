using System.ComponentModel.DataAnnotations;

namespace PatientPortal.Domain.Models.CORE
{
    public class Mail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}