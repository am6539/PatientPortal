using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;

namespace PatientPortal.IRepository.CMS
{
    public interface IFeatureRepo
    {
        Task<Feature> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Feature>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Feature data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
