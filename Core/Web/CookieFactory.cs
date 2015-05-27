using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Core.Web
{
    public static class CookieFactory
    {
        public static HttpCookie Create(string name)
        {
            HttpCookie c = new HttpCookie(name);
            c.Domain = "." + WebContext.Current.Domain;
            c.Name = name;
            return c;
        }

        public static HttpCookie Create(string name, string value)
        {
            HttpCookie c = Create(name);
            c.Value = value;
            return c;
        }
    }
}
