using PatientPortal.IRepository.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class AdvertiseRepoImpl : IAdvertiseRepo
    {
        IAdvertise _advertise;
        public AdvertiseRepoImpl(IAdvertise advertise)
        {
            this._advertise = advertise;
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _advertise.CheckExist(para);
        }

        public async Task<Advertise> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _advertise.SingleQuery(para);
        }

        public async Task<IEnumerable<Advertise>> Query(Dictionary<string, dynamic> para)
        {
            return await _advertise.Query(para);
        }

        public async Task<bool> Transaction(Advertise data, char action)
        {
            return await _advertise.Transaction(data, action);
        }
    }
}
