﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public byte WorkflowStateId { get; set; }
        public byte CategoryId { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public byte LanguageId { get; set; }
        public byte Priority { get; set; }
        public DateTime ExpiredDate { get; set; }
        public byte Type { get; set; }

        // Post SEO
        public string TitleSEO { get; set; }
        public string DescriptionSEO { get; set; }
        public string Canonical { get; set; }
        public byte MetaRobotIndex { get; set; }
        public byte MetaRobotFollow { get; set; }
        public byte MetaRobotAdvanced { get; set; }
        public string BreadcrumbsTitle { get; set; }

        // PostTrans
        public string TitleTrans { get; set; }
        public string CategoryName { get; set; }
        public string DescriptionTrans { get; set; }
        public string Detail { get; set; }
        public string Tag { get; set; }
    }
}