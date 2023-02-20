using Caravan.Service.Common.Attributes;
using Caravan.Service.Dtos.Locations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Orders
{
    public class OrderCreateDto
    {
        [Required(ErrorMessage = "Please enter valid name")]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required]
        [CheckNumber]
        public double Weight { get; set; }

        public double? Size { get; set; }

        [Required]
        public bool IsTaken { get; set; } = false;

        [Required]
        public LocationCreateDto CurrentlyLocation { get; set; } = default!;

        [Required]
        public LocationCreateDto TransferLocation { get; set; } = default!;

        public string? LocationName { get; set; }

        public double? Price { get; set; }
    }
}
