using PatientPortal.DataAccess.Repo.Authorize;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.Authorize;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PatientPortal.Repositoty.Authorize
{
    public class UserAuthorizationRepoImpl : IUserAuthorizationRepo
    {
        private readonly IUserAuthorization _auth;

        public UserAuthorizationRepoImpl(IUserAuthorization auth)
        {
            this._auth = auth;
        }

        public Task<bool> CheckPermission(Dictionary<string, dynamic> para)
        {
            return _auth.CheckPermission(para);
        }
    }
}
