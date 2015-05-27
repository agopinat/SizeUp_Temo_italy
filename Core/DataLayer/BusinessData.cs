using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Core.DataLayer.Models;

namespace Core.DataLayer
{
    public class BusinessData
    {
        public static IQueryable<Data.BusinessData> Get(SizeUpContext context)
        {
            return context.BusinessDatas
                .Where(i => i.Year == CommonFilters.TimeSlice.Industry.Year && i.Quarter == CommonFilters.TimeSlice.Industry.Quarter);
        }
    }
}
