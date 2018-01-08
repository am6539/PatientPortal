using System;
using System.Collections.Generic;
using System.Linq;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.Domain.Utilities;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.DataAccess.Repo.CMS;
using PatientPortal.DataAccess.Repo.Wrapper;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.CMS
{
    public class SliderImpl : ISlider
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public SliderImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Slider> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Slider>(para, "usp_Slider");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Slider>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Slider>(para, "usp_Slider");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Slider data, char action)
        {
            return await _adapterPattern.SingleTransaction<Slider, bool>(data, "usp_Slider_Transaction", action);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Slider_CheckExistTitle");
        }
    }
}
