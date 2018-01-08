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
    public class SystemNotificationController : ApiController
    {
        private readonly ISystemNotificationRepo _iSystemNotificationRepo;

        public SystemNotificationController(ISystemNotificationRepo iSystemNotificationRepo)
        {
            this._iSystemNotificationRepo = iSystemNotificationRepo;
        }

        [HttpGet]
        public async Task<SystemNotificationModel> GetByUser(string userId, string sendFrom, byte numTop = 0, byte pageIndex = 0, byte numberInPage = 0)
        {
            try
            {
                if (sendFrom == null) sendFrom = "";
                var list = new List<string> { "Id", "UserId", "SendFrom", "NumTop", "pageIndex", "numberInPage" };
                var para = APIProvider.APIDefaultParameter(list, 0, userId, sendFrom, numTop, pageIndex, numberInPage);

                var source = await _iSystemNotificationRepo.QueryPaging(para);
                var dest = Mapper.Map<List<SystemNotificationViewModel>>(source.Item1);

                dest = dest == null ? new List<SystemNotificationViewModel>() : dest;

                var result = new SystemNotificationModel();
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
        public async Task<SystemNotificationViewModel> Get(int id)
        {
            try
            {
                var list = new List<string> { "Id", "SendFrom" };
                var para = APIProvider.APIDefaultParameter(list, id, "");

                var source = await _iSystemNotificationRepo.SingleQuery(para);
                var dest = Mapper.Map<SystemNotificationViewModel>(source);

                return dest;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        [HttpPost]
        public async Task<bool> Transaction(SystemNotificationViewModel userNotification, char action)
        {
            var obj = Mapper.Map<Domain.Models.CORE.OM.SystemNotification>(userNotification);
            return await _iSystemNotificationRepo.Transaction(obj, action);
        }
    }
}
