using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class FeatureRepoImpl : IFeatureRepo
    {
        IFeature _feature;
        public FeatureRepoImpl(IFeature feature)
        {
            this._feature = feature;
        }

        public async Task<Feature> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _feature.SingleQuery(para);
        }
        public async Task<IEnumerable<Feature>> Query(Dictionary<string, dynamic> para)
        {
            return await _feature.Query(para);
        }
        public async Task<bool> Transaction(Feature data, char action)
        {
            return await _feature.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _feature.CheckExist(para);
        }
    }
}
