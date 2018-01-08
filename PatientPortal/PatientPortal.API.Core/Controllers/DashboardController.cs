using AutoMapper;
using PatientPortal.API.Core.Models;
using PatientPortal.API.Core.Models.QA;
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
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        private readonly IDashboardRepo _iDashboard;
        public DashboardController(IDashboardRepo iDashboard)
        {
            this._iDashboard = iDashboard;
        }

        [HttpGet]
        [Route("InternalCounter")]
        public async Task<IEnumerable<int>> Get()
        {
            return await _iDashboard.Internal_Counter();
        }
    }
}
