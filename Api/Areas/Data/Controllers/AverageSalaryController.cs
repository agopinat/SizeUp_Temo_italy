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
    public class AverageSalaryController : BaseController
    {
        //
        // GET: /Api/AverageSalary/


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Chart(int industryId, int geographicLocationId)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.AverageSalary.Chart(context, industryId, geographicLocationId);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Percentage(int industryId, int geographicLocationId, int value)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var obj = Core.DataLayer.AverageSalary.Percentage(context, industryId, geographicLocationId, value);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Bands(long industryId, long boundingGeographicLocationId, int bands, Core.DataLayer.Granularity granularity)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.AverageSalary.Bands(context, industryId, boundingGeographicLocationId, bands, granularity);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
