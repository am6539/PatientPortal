﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.API.SPA.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string TitleTran { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string DescriptionTrans { get; set; }
        public string CategoryName { get; set; }
        public byte WorkflowStateId { get; set; }
        public string WorkflowStateName { get; set; }
        public byte Priority { get; set; }
    }
}