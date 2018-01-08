using PatientPortal.Domain.Models.SPA;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface IConfiguration
    {
        Configuration GetById(byte id);
    }
}
