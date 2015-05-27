using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.API;
using System.Data.EntityClient;
using System.Configuration;

namespace Data
{
    public class ContextFactory
    {

        public static SizeUpContext SizeUpContext
        {
            get
            {
                var conn = new EntityConnection(ConfigurationManager.ConnectionStrings["SizeUpContext"].ConnectionString);
                var context = new SizeUpContext(conn);
                return context;
            }
        }

        public static APIContext APIContext
        {
            get
            {
                var context = new APIContext();
                return context;
            }
        }
    }
}