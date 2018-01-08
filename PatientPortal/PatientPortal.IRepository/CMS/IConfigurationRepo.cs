using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;

namespace PatientPortal.IRepository.CMS
{
    public interface IConfigurationRepo
    {
        Task<CMSConfiguration> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(CMSConfiguration data, char action);
    }
}
