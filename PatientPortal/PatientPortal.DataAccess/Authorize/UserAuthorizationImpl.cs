using PatientPortal.DataAccess.Repo.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.Authorize
{
    public class UserAuthorizationImpl : IUserAuthorization
    {
        private readonly IAdapterPattern _adapterPattern;

        public UserAuthorizationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public Task<bool> CheckPermission(Dictionary<string, dynamic> para)
        {
            return _adapterPattern.SingleExecuteQuery<bool>(para, "usp_CheckPermission", DataConfiguration.instanceCore);
        }
    }
}
