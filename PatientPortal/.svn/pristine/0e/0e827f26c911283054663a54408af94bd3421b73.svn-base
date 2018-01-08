using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CMS
{
    public interface IPostTranRepo
    {
        Task<PostTran> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(PostTran data, char action);
    }
}
