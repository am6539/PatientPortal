﻿using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Models.SPA;

namespace PatientPortal.DataAccess.SPA
{
    public class CategoryImpl : ICategory
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public CategoryImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Category>(para, "usp_spa_Category");
        }

        public async Task<IEnumerable<Category>> QueryPostCategory(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Category>(para, "usp_spa_Category");
        }

        public async Task<IEnumerable<Category>> QueryPostCategoryDept(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Category>(para, "usp_spa_CategoryDept");
        }
    }
}