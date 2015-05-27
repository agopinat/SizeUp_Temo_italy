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
    public class CostEffectivenessController : BaseController
    {
        //

        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Chart(int industryId, int geographicLocationId)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.CostEffectiveness.Chart(context, industryId, geographicLocationId);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Percentage(int industryId, int geographicLocationId, int revenue, int employees, int salary)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var ce = revenue / (double)(employees * salary);
                var obj = Core.DataLayer.CostEffectiveness.Percentage(context, industryId, geographicLocationId, ce);
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Bands(long industryId, long boundingGeographicLocationId, int bands, Core.DataLayer.Granularity granularity)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.CostEffectiveness.Bands(context, industryId, boundingGeographicLocationId, bands, granularity);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
