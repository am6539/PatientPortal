using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface ICategory
    {
        Task<Category> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Category data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
        Task<bool> CheckIsUsed(Dictionary<string, dynamic> para);
    }
}
