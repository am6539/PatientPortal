using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Common
{
    public class DataConfiguration
    {
        public const byte instanceCMS = 1;
        public const byte instanceCore = 2;
        public enum DapperQueryOption: byte
        {
            Query = 1,
            FirstOrDefault = 2,
            First = 3,
            SingleOrDefault = 4,
            Single = 5
        }
    }
}
