﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.SPA
{
    public class Feature
    {
        public byte Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Handler { get; set; }
        public bool IsUsed { get; set; }
    }
}
