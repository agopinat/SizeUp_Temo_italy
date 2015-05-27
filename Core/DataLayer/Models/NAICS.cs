using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.DataLayer.Models
{
    public class NAICS
    {
        public long? Id { get; set; }
        public string NAICSCode { get; set; }
        public string Name { get; set; }
    }
}