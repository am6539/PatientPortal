﻿using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IUserRole
    {
        Task<List<UserRole>> Query(Dictionary<string, object> param);
        Task<int> Transaction(UserRole data, char action);
        
    }
}