﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class ConfigurationViewModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Hotline { get; set; }
        public string GoogleMap { get; set; }
        public string GoogleEngineScript { get; set; }
        public bool IsSendEmailWF { get; set; }
        public string OpeningHours { get; set; }
        public string Email { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Slogan { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string SEOKeyword { get; set; }
    }
}