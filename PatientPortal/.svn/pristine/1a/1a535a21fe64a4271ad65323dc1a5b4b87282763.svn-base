using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.SPA;

namespace PatientPortal.Repositoty.SPA
{
    public class AdvertiseRepoImpl : IAdvertiseRepo
    {
        private IAdvertise _iAdvertise;

        public AdvertiseRepoImpl(IAdvertise iAdvertise)
        {
            this._iAdvertise = iAdvertise;
        }
        public List<Advertise> GetAll()
        {
            return _iAdvertise.GetAll();
        }
    }
}
