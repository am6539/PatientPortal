using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface IAdvertise
    {
        Task<IEnumerable<Advertise>> Query(Dictionary<string, dynamic> para);

        Task<Advertise> SingleQuery(Dictionary<string, dynamic> para);

        Task<bool> Transaction(Advertise data, char action);

        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
