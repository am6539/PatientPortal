using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PatientPortal.Repositoty.CORE
{
    public class DoctorProfileRepoImpl : IDoctorProfileRepo
    {
        private readonly IDoctorProfile _user;

        public DoctorProfileRepoImpl(IDoctorProfile user)
        {
            this._user = user;
        }

        public async Task<List<DoctorProfile>> Query(Dictionary<string, object> param)
        {
            return await _user.Query(param);
        }

        public async Task<DoctorProfile> SingleQuery(Dictionary<string, object> param)
        {
            return await _user.SingleQuery(param);
        }

        public async Task<bool> Transaction(DoctorProfileEdit data, char action)
        {
            return await _user.Transaction(data, action);
        }
    }
}
