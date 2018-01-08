using PatientPortal.CMS.Models;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.Provider.Common;
using PatientPortal.Utility.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PatientPortal.Utility.Application.ApplicationGenerator;

namespace PatientPortal.CMS.Controllers
{
    [Authorize]
    [AppHandleError]
    public class RedisController : Controller
    {
        private RedisCacheService redisCache = new RedisCacheService();
        // GET: Redis
        public async Task<ActionResult> Index()
        {
            var infoServer = await redisCache.ServerInfoAsync();
            var redisKeys = redisCache.Objects();

            //ViewBag
            ViewBag.InfoServer = infoServer;
            ViewBag.RedisKeys = redisKeys;

            return View();
        }

        public async Task<ActionResult> Flush(string key)
        {
            var ret = await redisCache.FlushDBAsync(key);
            if(ret) TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_DELETE, ApplicationGenerator.TypeResult.SUCCESS));
            else TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_DELETE, ApplicationGenerator.TypeResult.FAIL));

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> FlushAll()
        {
            var ret = await redisCache.FlushDBAsync();
            if (ret) TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_DELETE, ApplicationGenerator.TypeResult.SUCCESS));
            else TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_DELETE, ApplicationGenerator.TypeResult.FAIL));

            return RedirectToAction("Index");
        }
    }
}