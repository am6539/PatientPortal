using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface ISlider
    {
        Task<Slider> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Slider>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Slider data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
