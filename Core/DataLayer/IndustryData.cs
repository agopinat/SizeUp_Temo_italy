using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Core.DataLayer.Models;

namespace Core.DataLayer
{
    public class IndustryData
    {
        public static IQueryable<Data.IndustryData> Get(SizeUpContext context)
        {
            return context.IndustryDatas
                .Where(i => i.Year == CommonFilters.TimeSlice.Industry.Year && i.Quarter == CommonFilters.TimeSlice.Industry.Quarter);
        }
    }
}