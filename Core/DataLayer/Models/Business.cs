﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataLayer.Models
{
    public class Business
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public bool IsFirm { get; set; }
        public bool IsHomeBased { get; set; }
        public bool IsPublic { get; set; }
        public int? YearsInBusiness { get; set; }
        public long? IndustryId { get; set; }
        public string SEOKey { get; set; }
        public string Address
        {
            get
            {
                if (!string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State) && !string.IsNullOrEmpty(Zip))
                {
                    return string.Format("{0}, {1}, {2}, {3}", Street, City, State, Zip);
                }
                else { return null; };
            }
        }
        public string PhoneFormatted
        {
            get
            {
                long i = 0;
                if (long.TryParse(Phone, out i))
                {
                    return string.Format("{0:###-###-####}", i);
                }
                else
                {
                    return Phone;
                }
            }
        }
    }
}
