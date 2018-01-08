using PatientPortal.DataAccess.Repo.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.CORE
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
        public async Task<IEnumerable<QA>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<QA>(para, "usp_QA", DataConfiguration.instanceCore);
        }

        public async Task<QA> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<QA>(para, "usp_QA", DataConfiguration.instanceCore);
        }

        public async Task<bool> Transaction(QA data, char action)
        {
            return await _adapterPattern.SingleTransaction<QA, bool>(data, "usp_QA_Transaction", action, DataConfiguration.instanceCore);
        }
    }
}
