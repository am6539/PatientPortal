using PatientPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.IRepository.Wrapper;

namespace PatientPortal.Repositoty.Wraper
{
    public class AdapterPatternRepoImpl: IAdapterPatternRepo
    {
        private IAdapterPattern _adapterPattern;
        public AdapterPatternRepoImpl(IAdapterPattern adapterPattern)
        {
            _adapterPattern = adapterPattern;
        }

        public async Task<Q> SingleTransaction<T, Q>(T obj, string proc, char action, byte instance , string ignoreParas, DataConfiguration.DapperQueryOption queryOption)
        {
            return await _adapterPattern.SingleTransaction<T, Q>(obj, proc, action, instance, ignoreParas, queryOption);
        }

        public async Task<IEnumerable<Q>> Transaction<T, Q>(T obj, string proc, byte instance, string ignoreParas)
        {
            return await _adapterPattern.Transaction<T, Q>(obj, proc, instance, ignoreParas);
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(Dictionary<string, dynamic> obj, string proc, byte instance)
        {
            return await _adapterPattern.ExecuteQuery<T>(obj, proc, instance);
        }

        public async Task<T> SingleExecuteQuery<T>(Dictionary<string, dynamic> obj, string proc, byte instance, DataConfiguration.DapperQueryOption queryOption)
        {
            return await _adapterPattern.SingleExecuteQuery<T>(obj, proc, instance, queryOption);
        }
    }
}
