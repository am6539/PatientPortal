using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para);
        Task<IEnumerable<Category>> QueryPostCategory(Dictionary<string, dynamic> para);
        Task<IEnumerable<Category>> QueryPostCategoryDept(Dictionary<string, dynamic> para);
    }
}
