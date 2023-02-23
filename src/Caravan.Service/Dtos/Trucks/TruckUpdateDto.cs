using Caravan.Service.Common.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Trucks
{
    public class TruckUpdateDto
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required]
        [CheckNumber]
        public double? MaxLoad { get; set; }

        public string? LocationName { get; set; }

        public string? Description { get; set; }

        [Required]
        public string TruckNumber { get; set; } = string.Empty;

        [Required]
        public bool IsEmpty { get; set; } = true;
    }
}
