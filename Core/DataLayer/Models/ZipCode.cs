using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataLayer.Models
{
    public class ZipCode : GeographicLocation
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
    }
}
