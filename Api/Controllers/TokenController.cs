using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core;
using Core.Web;
using Core.API;

namespace Api.Controllers
{
    public class TokenController : BaseController
    {
        public ActionResult Index()
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var token = APIToken.Create(APIContext.Current.ApiToken.APIKeyId);
                var data = token.GetToken();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
