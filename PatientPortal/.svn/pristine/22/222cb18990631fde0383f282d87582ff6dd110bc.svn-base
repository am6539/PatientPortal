using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.SPA
{
    public class QAImpl : IQA
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public QAImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<Tuple<IEnumerable<QA>, int>> Query(Dictionary<string, dynamic> para)
        {
            Tuple<IEnumerable<QA>, int> data = await _adapterPattern.ExecuteQueryOut<QA>(para, "usp_spa_QA", "totalItem", DataConfiguration.instanceCore);
            return data;
        }
    }
}