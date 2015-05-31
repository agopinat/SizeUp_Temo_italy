using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core;
using Core.Web;
using Core.Geo;
using Core.Extensions;
using Core.DataLayer;
using Core.API;
using Api.Controllers;
namespace Api.Areas.Data.Controllers
{
    public class YearStartedController : BaseController
    {
        //
        // GET: /Api/YearStarted/
        
        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Chart(long industryId, long geographicLocationId, int startYear, int endYear)
        {
            if (startYear < 1986)
            {
                startYear = 1986;
            }
            using (var context = ContextFactory.SizeUpContext)
            {
                var obj = Core.DataLayer.YearStarted.Chart(context, industryId, geographicLocationId, startYear, endYear);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        
        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Percentile(long industryId, long geographicLocationId, int value)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var obj = Core.DataLayer.YearStarted.Percentile(context, industryId, geographicLocationId, value);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
