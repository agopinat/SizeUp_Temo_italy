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
    public class Place
    {
        //public static IQueryable<Data.GeographicLocation> Get(SizeUpContext context)
        //{
        //    return context.GeographicLocations.Where(i => i.GranularityId == 1);
        //}


        public static IQueryable<Data.Place> Get(SizeUpContext context)
        {
            //return context.Places.Where(i => i.City.CityType.IsActive && i.City.IsActive);
            return context.Places;
        }




        public static Models.Place Get(SizeUpContext context, long? id)
        {
            return Get(context)
                .Where(i => i.Id == id)
                .Select(new Projections.Place.Default().Expression)
                .FirstOrDefault();
        }

        public static Models.Place Get(SizeUpContext context, string stateSEOKey, string countySEOKey, string citySEOKey)//, string metroSEOKey = null)
        {
            Models.Place output = null;
            if (!string.IsNullOrEmpty(stateSEOKey) && !string.IsNullOrEmpty(countySEOKey) && !string.IsNullOrEmpty(citySEOKey))
            {
                output = Get(context)
                    .Where(i => i.County.SEOKey == countySEOKey && i.County.State.SEOKey == stateSEOKey && i.City.SEOKey == citySEOKey)
                    .Select(new Projections.Place.Default().Expression)
                    .FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(stateSEOKey) && !string.IsNullOrEmpty(countySEOKey))
            {
                output = Get(context)
                    .Where(i => i.County.SEOKey == countySEOKey && i.County.State.SEOKey == stateSEOKey)
                    .Select(new Projections.Place.County().Expression)
                    .FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(stateSEOKey))
            {
                output = Get(context)
                   .Where(i => i.County.State.SEOKey == stateSEOKey)
                   .Select(new Projections.Place.State().Expression)
                   .FirstOrDefault();
            }
            //else if (!string.IsNullOrEmpty(metroSEOKey))
            //{
            //    output = Get(context)
            //        .Where(i => i.County.Metro.SEOKey == metroSEOKey)
            //        .Select(new Projections.Place.Metro().Expression)
            //        .FirstOrDefault();
            //}
            return output != null ? output : new Models.Place() { 
                City = new Models.City(), 
                County = new Models.County(), 
                //Metro = new Models.Metro(), 
                State = new Models.State() };
        }

        //public static IQueryable<Models.Place> Search(SizeUpContext context, string term)
        //{
        //    var qs = term.Split(',').ToList();
        //    string city = qs[0].Trim();
        //    string state = qs.Count > 1 ? qs[1].Trim() : string.Empty;
        //    var places = Get(context);
        //    return places
        //            .Select(i => new
        //             {
        //                 GeographicLocation = new Models.Place
        //                 {
        //                     Id = i.Id,
        //                     ShortName = i.ShortName,
        //                     LongName = i.LongName

        //                 }
        //             })
        //            .Where(i => qs.All(d => i.GeographicLocation.ShortName.Contains(d)))
        //            .Select(i => i.GeographicLocation)
        //            .OrderBy(i => i.ShortName);
        //}


        public static IQueryable<Models.Place> Search(SizeUpContext context, string term)
        {
            var qs = term.Split(',').ToList();
            string city = qs[0].Trim();
            string county = qs.Count > 1 ? qs[1].Trim() : string.Empty;
            var places = Get(context);


            //var test = places
            //                .Select(i => new
            //        {
            //            Place = i,
            //            Search = i.City.Name
            //        })
            //        .Where(i => i.Search.StartsWith(city))
            //        .Where(i => i.Place.County.Abbreviation.StartsWith(county))
            //        .Select(i => i.Place);

            return places
                    .Select(i => new
                    {
                        Place = i,
                        Search = i.City.Name
                    })
                    .Where(i => i.Search.StartsWith(city))
                    .Where(i => i.Place.County.Abbreviation.StartsWith(county))
                    .OrderBy(i => i.Place.City.Name)
                    .ThenBy(i => i.Place.City.County.Abbreviation)
                    //.ThenByDescending(i => i.Place.City.GeographicLocation.Demographics.AsQueryable().Where(d => d.Year == CommonFilters.TimeSlice.Demographics.Year && d.Quarter == CommonFilters.TimeSlice.Demographics.Quarter).FirstOrDefault().TotalPopulation)
                    .Select(i => i.Place)
                    .Select(new Projections.Place.Default().Expression);
        }



        public static IQueryable<Models.DistanceEntity<Models.Place>> ListNear(SizeUpContext context, Core.Geo.LatLng latLng)
        {
            var distanceFilter = new DistanceEntity<Data.Place>.DistanceEntityFilter(latLng);
            return Get(context)
                .Select(i => new KeyValue<Data.Place, Geo.LatLng>
                {
                    Key = i,
                    Value = i.GeographicLocation.Geographies.AsQueryable()//.Where(g => g.GeographyClass.Name == Geo.GeographyClass.Calculation)
                    .Select(g => new Geo.LatLng { Lat = g.CenterLat.Value, Lng = g.CenterLong.Value })
                    .FirstOrDefault()
                })
                .Select(distanceFilter.Projection)
                .Select(new Projections.Place.Distance().Expression);
        }
    }
}