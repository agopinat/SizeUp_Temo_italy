using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core.Web;
using Core.Geo;
using Microsoft.SqlServer.Types;
using System.Data.Objects;
using System.Data.Spatial;
using Core;
using Core.API;

namespace Web.Areas.Api.Controllers
{
    public class PlaceController : BaseController
    {
        //
        // GET: /Api/Place/

        public ActionResult Detected()
        {
            var id = GeoCoder.GetPlaceIdByIPAddress(WebContext.Current.ClientIP);
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Place.Get(context, id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
