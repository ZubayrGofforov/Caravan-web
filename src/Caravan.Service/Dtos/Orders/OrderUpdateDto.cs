using Caravan.Service.Common.Attributes;
using Caravan.Service.Dtos.Locations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Orders
{
    public class OrderUpdateDto
    {

        [Required(ErrorMessage = "Please enter valid name")]
        [MaxLength(50), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }

        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required]
        [CheckNumber]
        public double Weight { get; set; }

        public double? Size { get; set; }

        public string? LocationName { get; set; }

        [Required]
        public LocationCreateDto CurrentlyLocation { get; set; } = default!;

        [Required]
        public LocationCreateDto TransferLocation { get; set; } = default!;

        [Required]
        public bool IsTaken { get; set; } = false;
    }
}
