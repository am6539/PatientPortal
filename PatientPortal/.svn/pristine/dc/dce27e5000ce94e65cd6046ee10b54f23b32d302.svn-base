using PatientPortal.IRepository.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class LinkBuildingRepoImpl : ILinkBuildingRepo
    {
        /// <summary>
        /// declare variables
        /// </summary>
        ILinkBuilding _link;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="link"></param>
        public LinkBuildingRepoImpl(ILinkBuilding link)
        {
            this._link = link;
        }


        public async Task<LinkBuilding> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _link.SingleQuery(para);
        }
        public async Task<IEnumerable<LinkBuilding>> Query(Dictionary<string, dynamic> para)
        {
            return await _link.Query(para);
        }
        public async Task<bool> Transaction(LinkBuilding data, char action)
        {
            return await _link.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _link.CheckExist(para);
        }
    }
}
