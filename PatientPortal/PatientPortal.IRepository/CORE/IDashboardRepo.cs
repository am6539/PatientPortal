using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CORE
{
    public interface IDashboardRepo
    {
        Task<IEnumerable<int>> Internal_Counter();
    }
}
