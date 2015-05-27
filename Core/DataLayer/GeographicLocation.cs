using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Core.DataLayer.Models;
using System.Data.Spatial;
using Core.Geo;
using System.Data.Objects.SqlClient;


namespace Core.DataLayer
{
    public class GeographicLocation
    {
        public static IQueryable<Data.GeographicLocation> Get(SizeUpContext context)
        {
            return context.GeographicLocations;
        }
    }
}
