using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Identity.Common
{
    public class ValueConstant
    {
        // Value action in tracsaction
        public const string DefaultRoleInitial = "Admin";
  
    }

    public enum UserStatus
    {
        Success = 1,
        IsUsed = 2,
    }
}