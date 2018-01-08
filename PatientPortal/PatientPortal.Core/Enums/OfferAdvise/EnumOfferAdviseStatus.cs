using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Enums.OfferAdvise
{
    public enum EnumOfferAdviseStatus : byte
    {
        ViewAll = 0,
        New = 1,
        Approve = 2,
        NotApprove = 3
    }
}
