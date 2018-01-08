using PatientPortal.Domain.Models.SPA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface IFeature
    {
        Task<Feature> SingleQuery(Dictionary<string, object> param);
        Task<List<Feature>> Query(Dictionary<string, object> param);
    }
}
