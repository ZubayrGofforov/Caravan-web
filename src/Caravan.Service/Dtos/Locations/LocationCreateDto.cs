using Caravan.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

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
