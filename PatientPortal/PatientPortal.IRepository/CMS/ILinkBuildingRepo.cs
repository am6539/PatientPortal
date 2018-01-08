using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CMS
{
    public interface ILinkBuildingRepo
    {
        Task<LinkBuilding> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<LinkBuilding>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(LinkBuilding data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
