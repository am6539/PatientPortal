using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class CategoryRepoImpl: ICategoryRepo
    {
        ICategory _category;
        public CategoryRepoImpl(ICategory category)
        {
            this._category = category;
        }

        public async Task<Category> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _category.SingleQuery(para);
        }
        public async Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para)
        {
            return await _category.Query(para);
        }
        public async Task<bool> Transaction(Category data, char action)
        {
            return await _category.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _category.CheckExist(para);
        }
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _category.CheckIsUsed(para);
        }
    }
}
