using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Core.Serialization;
using Core.Web;
using Data;
using Api = Web.Areas.Api;
namespace Web.Controllers
{
    public class CompetitionController : BaseController
    {
        //
        // GET: /Competition/

        public ActionResult Index()
        {
            if (CurrentInfo.CurrentPlace.Id == null || CurrentInfo.CurrentIndustry == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Header.ActiveTab = NavItems.Competition;
            return View();
        }

    }
}
