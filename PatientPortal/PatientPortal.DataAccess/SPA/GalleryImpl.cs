using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.DataAccess.Repo.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;

namespace PatientPortal.DataAccess.SPA
{
    public class GalleryImpl: IGallery
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public GalleryImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<Gallery> Get(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Gallery>(para, "usp_spa_Gallery");
        }

        public async Task<IEnumerable<Gallery>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Gallery>(para, "usp_spa_Gallery");
        }
    }
}
