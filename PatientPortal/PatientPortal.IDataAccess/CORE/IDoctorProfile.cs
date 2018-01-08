using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IDoctorProfile
    {
        Task<List<DoctorProfile>> Query(Dictionary<string, object> param);
        Task<DoctorProfile> SingleQuery(Dictionary<string, object> param);
        Task<bool> Transaction(DoctorProfileEdit data, char action);
    }
}
