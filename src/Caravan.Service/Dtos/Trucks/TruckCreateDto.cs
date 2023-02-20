using Caravan.Service.Common.Attributes;
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

        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required]
        [CheckNumber]
        public double? MaxLoad { get; set; }

        public bool IsEmpty { get; set; } = true;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public string TruckNumber { get; set; } = string.Empty;

        [Required]
        public LocationCreateDto TruckLocation { get; set; } = default!;

        [Required]
        public string? LocationName { get; set; }
    }
}
