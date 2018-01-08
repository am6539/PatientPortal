using PatientPortal.Domain.Models.SPA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para);

        Task<IEnumerable<Category>> QueryPostCategory(Dictionary<string, dynamic> para);

        Task<IEnumerable<Category>> QueryPostCategoryDept(Dictionary<string, dynamic> para);
    }
}
