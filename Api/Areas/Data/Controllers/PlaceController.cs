using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core.Web;
using Core.DataLayer;
using Core.API;
using Api.Controllers;

namespace Api.Areas.Data.Controllers
{
    public class PlaceController : BaseController
    {
        //
        // GET: /Data/Place/

        [APIAuthorize(Role = "Place")]
        public ActionResult Search(string term, int maxResults = 35)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Place.Search(context, term).Take(maxResults).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
