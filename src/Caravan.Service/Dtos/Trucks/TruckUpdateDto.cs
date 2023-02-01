using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Trucks
{
    public class TruckUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public double? MaxLoad { get; set; }

        public string? LocationName { get; set; }

        public string? Description { get; set; }

        public string TruckNumber { get; set; } = string.Empty;
    }
}
