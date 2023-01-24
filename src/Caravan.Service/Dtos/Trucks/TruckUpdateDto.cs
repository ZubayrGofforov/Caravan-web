using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Trucks
{
    public class TruckUpdateDto
    {
        [Required]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }

        [Required]
        public double? MaxLoad { get; set; }

        public string? LocationName { get; set; }

        public string? Description { get; set; }

        [Required]
        public string TruckNumber { get; set; } = string.Empty;
    }
}
