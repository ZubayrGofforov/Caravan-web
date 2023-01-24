using Caravan.Domain.Common;
using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.ViewModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public double Weight { get; set; }

        public double? Size { get; set; }

        public bool IsTaken { get; set; } = false;

        public double? Price { get; set; }

        public UserViewModel User { get; set; } = default!;

        public LocationViewModel TakenLocation { get; set; } = default!;

        public LocationViewModel DeliveryLocation { get; set; } = default!;

        public string? LocationName { get; set; }
    }
}
