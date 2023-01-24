using Caravan.Domain.Common;
using Caravan.Service.Dtos.Locations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Trucks
{
    public class TruckCreateDto
    {
        [Required]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }

        [Required]
        public double? MaxLoad { get; set; }

        public bool IsEmpty { get; set; } = true;

        public string? Description { get; set; }

        [Required]
        public string TruckNumber { get; set; } = string.Empty;

        [Required]
        public LocationCreateDto TruckLocation { get; set; } = default!;

        public string? LocationName { get; set; }
    }
}
