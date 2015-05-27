using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Data;
using Core.Analytics;
using System.Web;

namespace Core.Diagnostics
{
    public class HandleErrorAndLogAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //var e = filterContext.Exception;
            //if ((e is HttpException && ((HttpException)e).GetHttpCode() != 404) || !(e is HttpException))
            //{
            //    Data.Analytics.Exception reg = new Data.Analytics.Exception()
            //    {

            //        RequestUrl = HttpContext.Current.Request.Url.OriginalString,
            //        ExceptionText = e.Message,
            //        InnerExceptionText = e.InnerException != null ? e.InnerException.Message : null,
            //        StackTrace = e.StackTrace
            //    };
            //    if (!filterContext.ExceptionHandled)
            //    {
            //        Singleton<Tracker>.Instance.Exception(reg);
            //    }
            //}
            base.OnException(filterContext);
        }
    }

}
