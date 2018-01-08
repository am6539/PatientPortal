using AutoMapper;
using PatientPortal.API.Core.Models;
using PatientPortal.IRepository.CORE;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.Core.Controllers
{
    [AuthorizeRoles]
    public class UserNotificationController : ApiController
    {
        private readonly IUserNotificationRepo _userNotificationRepo;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="survey"></param>
        public UserNotificationController(IUserNotificationRepo userNotificationRepo)
        {
            this._userNotificationRepo = userNotificationRepo;
        }

        [HttpGet]
        public async Task<UserNotificationModel> GetByUser(string userId, byte pageIndex = 0, byte numberInPage = 0, byte numTop = 0)
        {
            try
            {
                var list = new List<string> { "Id", "UserId", "NumTop", "pageIndex", "numberInPage" };
                var para = APIProvider.APIDefaultParameter(list, "", userId, numTop, pageIndex, numberInPage);

                var source = await _userNotificationRepo.QueryPaging(para);
                var dest = Mapper.Map<List<UserNotificationViewModel>>(source.Item1);

                dest = dest == null ? new List<UserNotificationViewModel>() : dest;

                var result = new UserNotificationModel();
                result.lstUserNotificationViewModel = dest;
                result.TotalItem = source.Item2;

                return result;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        [HttpGet]
        public async Task<UserNotificationViewModel> Get(string id)
        {
            try
            {
                var list = new List<string> { "Id", "UserId" };
                var para = APIProvider.APIDefaultParameter(list, id, "");

                var source = await _userNotificationRepo.SingleQuery(para);
                var dest = Mapper.Map<UserNotificationViewModel>(source);

                return dest;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        [HttpPost]
        public async Task<bool> Transaction(UserNotificationViewModel userNotification, char action)
        {
            var obj = Mapper.Map<Domain.Models.CORE.UserNotification>(userNotification);
            return await _userNotificationRepo.Transaction(obj, action);
        }

        [HttpPost]
        public async Task<bool> UpdateStatus(List<string> ids, bool status)
        {
            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    var data = new Domain.Models.CORE.UserNotification() { Id = ids[i], IsRead = status };
                    await _userNotificationRepo.UpdateStatus(data, 'U');
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
