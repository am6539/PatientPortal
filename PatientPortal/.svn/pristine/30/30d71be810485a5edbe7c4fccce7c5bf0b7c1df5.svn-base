using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface IConfiguration
    {
        Task<CMSConfiguration> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(CMSConfiguration data, char action);
    }
}
