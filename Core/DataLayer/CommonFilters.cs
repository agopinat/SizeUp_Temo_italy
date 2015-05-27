using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Core.DataLayer
{
    public class CommonFilters
    {
        public static class TimeSlice
        {

            public static class Industry
            {
                public static int Year { get { return int.Parse(ConfigurationManager.AppSettings["TimeSlice.Industry.Year"]); } }
                public static int Quarter { get { return int.Parse(ConfigurationManager.AppSettings["TimeSlice.Industry.Quarter"]); } }
            }

        }

        public static int MinimumBusinessCount
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Data.MinimumBusinessCount"]);
            }
        }
    }
}