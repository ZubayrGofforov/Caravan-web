using Caravan.Domain.Common;

namespace Caravan.Domain.Entities
{
    public class Order : Auditable
    {
        public string Name { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public double Weight { get; set; }

        public double? Size { get; set; }

        public bool IsTaken { get; set; } = false;

        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public long TakenLocationId { get; set; }
        public virtual Location TakenLocation { get; set; } = default!;

        public double? Price { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public long DeliveryLocationId { get; set; }
        public virtual Location DeliveryLocation { get; set; } = default!;
    }
}
