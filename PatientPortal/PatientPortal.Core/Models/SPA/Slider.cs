using System;

namespace PatientPortal.Domain.Models.SPA
{
    public class Slider
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
