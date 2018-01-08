﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.Internal.Models.Survey
{
    [ProtoContract]
    public class SurveyQuestionsModel
    {
        public SurveyQuestionsModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [ProtoMember(1)]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Id khảo sát")]
        public string SurveyId { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Câu hỏi")]
        public string Question { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Loại câu hỏi")]
        public byte Type { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Bắt buộc")]
        public bool? IsRequireds { get; set; }
        [ProtoMember(6)]
        [Display(Name = "Ngẫu nhiên")]
        public bool IsRandomize { get; set; }
        [ProtoMember(7)]
        public List<SurveyAnswersModel> SurveyAnswersModel { get; set; }
    }
}