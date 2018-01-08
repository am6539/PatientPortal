using PatientPortal.Core.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface IPostStateHistory
    {
        List<PostStateHistory> GetAll();
    }
}
