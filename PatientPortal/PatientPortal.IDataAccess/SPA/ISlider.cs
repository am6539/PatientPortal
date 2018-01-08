using PatientPortal.Domain.Models.SPA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface ISlider
    {
        Task<List<Slider>> GetAll();
    }
}
