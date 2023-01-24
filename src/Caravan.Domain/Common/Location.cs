using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Domain.Common
{
    public class Location : BaseEntity
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
