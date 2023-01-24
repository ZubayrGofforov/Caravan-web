using Caravan.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Locations
{
    public class LocationCreateDto
    {
        [Required]
        [CheckNumber]
        public double Latitude { get; set; }

        [Required]
        [CheckNumber]
        public double Longitude { get; set; }
    }
}
