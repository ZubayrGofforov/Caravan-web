using Caravan.Domain.Common;
using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.ViewModels
{
    public class TruckViewModel
    {
        public long Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public double? MaxLoad { get; set; }

        public bool IsEmpty { get; set; } = true;

        public string? Description { get; set; }

        public string TruckNumber { get; set; } = string.Empty;

        public UserViewModel User { get; set; } = default!;
        
        public LocationViewModel TruckLocation { get; set; } = default!;
        
        public string? LocationName { get; set; }
    }
}
