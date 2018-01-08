using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Repositoty.SPA
{
    public class QARepoImpl: IQARepo
    {
        private readonly IQA _iQA;

        public QARepoImpl(IQA iQA)
        {
            this._iQA = iQA;
        }

        public async Task<Tuple<IEnumerable<QA>, int>> Query(Dictionary<string, dynamic> para)
        {
            return await _iQA.Query(para);
        }
    }
}
