﻿using PatientPortal.Domain.Models.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CORE
{
    public interface IUserRepo
    {
        Task<List<User>> Query(Dictionary<string, object> param);
        Task<int> Transaction(User data, char action);
        Task<User> SingleQuery(Dictionary<string, object> param);
        Task<List<User>> GetUserHaveScheduleExamine(Dictionary<string, object> param);
        Task<List<User>> GetUsersByGroupType(Dictionary<string, object> param);
        Task<string> GetUserId(Dictionary<string, object> param);
    }
}