﻿using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IAppointmentLogRepo
    {
        Task<bool> Transaction(AppointmentLogEdit data, char action);
        Task<List<Schedule>> GetScheduleExamine(Dictionary<string, object> param);
    }
}
