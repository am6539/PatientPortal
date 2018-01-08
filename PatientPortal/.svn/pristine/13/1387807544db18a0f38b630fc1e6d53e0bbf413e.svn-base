using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.IRepository.SPA;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.SPA.Controllers
{
    public class ScheduleController : ApiController
    {
        private readonly IScheduleRepo _iSchedule;
        public ScheduleController(IScheduleRepo iSchedule)
        {
            this._iSchedule = iSchedule;
        }

        [HttpGet]
        public async Task<List<ScheduleViewModel>> QueryScheduleExamine(string userId, long startTime)
        {
            DateTime date = new DateTime(1970, 1, 1);
            //DateTime start = date.AddMilliseconds(startTime).ToLocalTime();
            DateTime startDate = date.AddMilliseconds(startTime);
            //var start = Convert.ToDateTime(startTime);
            var lstAvaiableTime = new List<string>();

            if (startDate == DateTime.MinValue && startDate == DateTime.MinValue)
            {
                startDate = DateTime.Now.AddDays(-2);
            }

            IList<string> list = new List<string> { "userId", "start", "End" };
            var start = startDate.ToString("yyyy-MM-dd");
            var end = startDate.AddDays(2).ToString("yyyy-MM-dd");
            var para = APIProvider.APIDefaultParameter(list, userId, start, end);

            var source = await _iSchedule.QueryScheduleExamine(para);
            var dest = Mapper.Map<List<ScheduleViewModel>>(source);

            return dest;
        }

        [HttpGet]
        public async Task<List<string>> GetScheduleExamine(string userId, long startTime)
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime start = date.AddMilliseconds(startTime).ToLocalTime().Date;
            //var start = Convert.ToDateTime(startTime);
            var lstAvaiableTime = new List<string>();

            if (start == DateTime.MinValue && start == DateTime.MinValue)
            {
                start = DateTime.Now.AddDays(-2);
            }

            IList<string> list = new List<string> { "userId", "start" };
            var para = APIProvider.APIDefaultParameter(list, userId, start);

            var source = await _iSchedule.GetScheduleExamine(para);
            if (source != null)
            {
                var timeSchedule = source;
                lstAvaiableTime.Add(timeSchedule.Start.Hour.ToString() + ":" + timeSchedule.Start.Minute.ToString());
                while (timeSchedule.Start <= timeSchedule.End)
                {
                    timeSchedule.Start = timeSchedule.Start.AddMinutes(15);
                    lstAvaiableTime.Add(timeSchedule.Start.Hour.ToString() + ":" + timeSchedule.Start.Minute.ToString());
                }
            }
            return lstAvaiableTime;
        }
    }
}
