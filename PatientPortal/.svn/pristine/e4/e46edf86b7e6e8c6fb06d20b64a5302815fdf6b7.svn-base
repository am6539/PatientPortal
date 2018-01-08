using PatientPortal.IRepository.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class QARepoImpl : IQARepo
    {
        IQA _iQA;
        public QARepoImpl(IQA iQA)
        {
            this._iQA = iQA;
        }
        public async Task<IEnumerable<QA>> Query(Dictionary<string, dynamic> para)
        {
            return await _iQA.Query(para);
        }

        public async Task<QA> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _iQA.SingleQuery(para);
        }

        public async Task<bool> Transaction(QA data, char action)
        {
            return await _iQA.Transaction(data, action);
        }
    }
}
